using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Fluent
{
    [AddComponentMenu("Fluent/Yell Handler")]
    public class YellHandler : FluentNodeHandler
    {
        public GameObject YellUI;
        public Camera Camera;

        YellNode CurrentNode;

        void Update()
        {
            if (CurrentNode != null && CurrentNode.IsBillboard && YellUI != null)
            {
                // If this yell is a billboard but the camera isn't specified, assume the main camera
                if (Camera == null)
                    Camera = Camera.main;
                YellUI.transform.LookAt(YellUI.transform.position + Camera.transform.rotation * Vector3.forward, Camera.transform.rotation * Vector3.up);
            }
        }

        void ConnectClickCallback(GameObject go)
        {
            if (go.GetComponentInChildren<Button>() == null)
                go.AddComponent<Button>();

            // Add the button listener so that text can be skipped
            go.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            go.GetComponentInChildren<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
            {
                StopCoroutine("StartYell");
                CloseCanvas();
                FluentNode savedCurrentNode = CurrentNode;
                CurrentNode = null;
                savedCurrentNode.Done();
            }));

            // Focus the button so that keypresses work
            EventSystem.current.SetSelectedGameObject(go);
        }

        public override void HandleFluentNode(FluentNode fluentNode)
        {

            // We can only have one yell response for a given handler
            if (CurrentNode != null)
            {
                // Stop the current yell
                StopCoroutine("StartYell");

                // Make sure it tells whoever is interested that it completed
                CurrentNode.Done();                
            }

            // Save parameters
            CurrentNode = fluentNode as YellNode;

            if (CurrentNode == null)
                Debug.Log("CurrentNode is null");

            // Start yell
            StartCoroutine("StartYell");
        }

        private IEnumerator StartYell()
        {
            // Create an instance of a yell canvas
            if (YellUI == null)
            {
                Debug.LogError("Your Yell Handler does not have a yell dialog UI specified. Add a canvas that has a Text component as a child to this object", gameObject);
                yield break;
            }

            // Show the yell UI
            YellUI.SetActive(true);

            // Called now to orientate the yell to the camera otherwise there is a hak
            Update();

            // Set the yell canvas text
            Text text = YellUI.GetComponentInChildren<Text>();

            // 
            ConnectClickCallback(text.gameObject);

            if (text == null)
                throw new UnityException("Could not find a Text UI component in the specified Yell UI");

            text.text = CurrentNode.Text;

            // Show the canvas for x seconds
            yield return new WaitForSeconds(CurrentNode.SecondsToPause);

            //
            FluentNode tempCurrentNode = CurrentNode;

            // Close the canvas
            CloseCanvas();

            //
            CurrentNode = null;
            tempCurrentNode.Done();
        }

        private void CloseCanvas()
        {
            if (YellUI != null)
                YellUI.SetActive(false);
        }

        public override void Interrupt(FluentNode fluentNode)
        {
            StopCoroutine("StartYell");
            CloseCanvas();
            CurrentNode = null;
        }

    }
}
