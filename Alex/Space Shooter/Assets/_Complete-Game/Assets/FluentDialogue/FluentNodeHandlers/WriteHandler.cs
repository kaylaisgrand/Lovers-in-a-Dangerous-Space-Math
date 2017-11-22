using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

namespace Fluent
{
    [AddComponentMenu("Fluent / Write Handler")] 
    [RequireComponent(typeof(OptionsPresenter))]
    public class WriteHandler : FluentNodeHandler
    {
        public GameObject TextUI;
        public float CharacterPauseSeconds = 0.03f;
        public Button Button;

        bool isTyping = false;
        WriteNode currentNode;
        GameObject currentTextUI;

         private IEnumerator TypeText()
        {
            // Get the text component we are using to write 
            Text textTextUI = currentTextUI.GetComponent<Text>();
            List<string> tagStack = new List<string>();

            int currentPosition = 0;
            string allText = currentNode.Text;

            if (allText.Length > 0)
            {
                isTyping = true;
                while (true)
                {
                    if (allText[currentPosition] == '<')
                    {
                        string stringThatsLeft = allText.Substring(currentPosition);
                        int endBracketIndex = stringThatsLeft.IndexOf('>');
                        string element = stringThatsLeft.Substring(0, endBracketIndex + 1);
                        int spaceIndex = element.IndexOf(' ');
                        int equalsIndex = element.IndexOf('=');
                        string tagName = "";

                        if (equalsIndex != -1)
                            tagName = element.Substring(1, equalsIndex - 1);
                        else
                        {
                            if (spaceIndex != -1)
                                tagName = element.Substring(1, spaceIndex - 1);
                            else
                                tagName = element.Substring(1, element.Length - 2);
                        }

                        // If its a close tag
                        if (allText[currentPosition + 1] == '/')
                        {
                            tagStack.RemoveAt(tagStack.Count - 1);
                        }
                        else
                        {
                            // Store the end tag in the tag stack
                            tagStack.Add("</" + tagName + ">");
                        }

                        // Jump to close tag
                        currentPosition = currentPosition + endBracketIndex;
                    }

                    string currentString = allText.Substring(0, currentPosition + 1);
                    for (int i = tagStack.Count - 1; i >= 0; i--)
                        currentString += tagStack[i];

                    textTextUI.text = currentString;
                    yield return new WaitForSeconds(CharacterPauseSeconds);

                    currentPosition++;
                    if (currentPosition >= allText.Length)
                    {
                        RemoveSkipListener();
                        break;
                    }
                }
            }
            else
            {
                textTextUI.text = "";
            }

            isTyping = false;

            bool buttonRequestedButNotSpecified = currentNode.WaitForButtonPress && (Button == null);
            if (buttonRequestedButNotSpecified)
            {
                Debug.Log("You are trying to show a button for a Write() but you did not specify the Button UI element", gameObject);
            }

            if (!currentNode.WaitForButtonPress || buttonRequestedButNotSpecified)
            {
                StartCoroutine("Pause");
            }
            else
            {
                ShowButton();
            }
        }

        private void RemoveSkipListener()
        {
            currentTextUI.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        }

        private void ShowButton()
        {
            // Show the button
            Button.gameObject.SetActive(true);

            // Give it focus
            EventSystem.current.SetSelectedGameObject(Button.gameObject);

            // Hookup the event handlers
            Button.onClick.AddListener(() =>
            {
                // Hide the button
                Button.gameObject.SetActive(false);

                // Disconnect the event
                Button.onClick.RemoveAllListeners();

                //
                currentNode.Done();
            });
        }


        private IEnumerator Pause()
        {
            yield return new WaitForSeconds(currentNode.SecondsToPause);
            currentNode.Done();
        }

        void StopTyping()
        {
            // When we stop for the first time we just write out all the text
            if (isTyping)
            {
                isTyping = false;
                StopCoroutine("TypeText");
                currentTextUI.GetComponent<Text>().text = currentNode.Text;
                RemoveSkipListener();

                if (!currentNode.WaitForButtonPress)
                    StartCoroutine("Pause");
                else
                    ShowButton();

                return;
            }

            // The player needs to press a button to continue
            if (currentNode.WaitForButtonPress)
                return;

            // If the node is stopped again we stop the pausing
            StopCoroutine("Pause");
            currentNode.Done();
        }

        public override void HandleFluentNode(FluentNode fluentNode)
        {
            // Store current node
            currentNode = fluentNode as WriteNode;

            // Check if the UI element is defined on the 
            if (currentNode.TextUIElement != null)
                currentTextUI = currentNode.TextUIElement.gameObject;
            else
                currentTextUI = TextUI;

            // Get the text component we are using to write the text
            Text textTextUI = currentTextUI.GetComponent<Text>();

            if (!(currentTextUI).activeSelf)
            {
                Debug.LogError("Did you forget to call Show() before Write() in your node chain ? The Write Node needs the element on to which text is written to be visible", this);
                return;
            }

            // Add a button to the text if it doent have one
            if (currentTextUI.GetComponentInChildren<Button>() == null)
                currentTextUI.AddComponent<Button>();

            // Add the button listener so that text can be skipped
            currentTextUI.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            currentTextUI.GetComponentInChildren<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
            {
                // Do cleanup
                isTyping = false;
                StopCoroutine("TypeText");
                StopCoroutine("Pause");
                currentTextUI.GetComponent<Text>().text = currentNode.Text;
                RemoveSkipListener();

                // Write's that require a button press to continue cannot be interrupted
                if (currentNode.WaitForButtonPress)
                {
                    ShowButton();
                    return;
                }

                FluentNode prevNode = currentNode;
                currentNode.Done();
                prevNode.IWasInterrupted();
            }));

            // Set the text component to be the selected component
            EventSystem.current.SetSelectedGameObject(textTextUI.gameObject);

            // Check if this is an instant write
            if (CharacterPauseSeconds == 0)
            {
                currentTextUI.GetComponent<Text>().text = currentNode.Text;
                if (currentNode.SecondsToPause != 0)
                    StartCoroutine("Pause");
                else
                    currentNode.Done();

                return;
            }

            StartCoroutine("TypeText");
        }

        public override void Interrupt(FluentNode fluentNode)
        {
            Debug.Log("Interrupt write");
            // 

        }
    }
}
