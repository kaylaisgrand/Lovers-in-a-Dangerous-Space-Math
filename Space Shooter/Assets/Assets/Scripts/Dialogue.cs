using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Dialogue : MonoBehaviour
{

  [TextArea(3, 10)]
  private Text textComponent;
  [TextArea(3, 10)]
  public string[] DialogueStrings;
  public float SecondsBetweenChars = 0.15f;
  public float CharacterRateMultiplier = 0.5f;

  public KeyCode DialogueInput = KeyCode.Return;

  private bool isStringBeingRevealed = false;
  private bool isDialoguePlaying = false;
  private bool isEndOfDialogue = false;

  public GameObject ContinueIcon;
  public GameObject StopIcon;



  public Text TextComponent
  {
    get
    {
      return TextComponent1;
    }

    set
    {
      TextComponent1 = value;
    }
  }

  public Text TextComponent1
  {
    get
    {
      return textComponent;
    }

    set
    {
      textComponent = value;
    }
  }


  // Use this for initialization
  void Start()
  {
    TextComponent1 = GetComponent<Text>();
    TextComponent1.text = "";

    HideIcons();

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Return))
    {
      if (!isDialoguePlaying)
      {
        isDialoguePlaying = true;
        StartCoroutine(StartDialogue());
      }

    }
  }

  private IEnumerator StartDialogue()
  {
    int dialogueLength = DialogueStrings.Length;
    int currentDialogueIndex = 0;

    while (currentDialogueIndex < dialogueLength || !isStringBeingRevealed)
    {
      if (!isStringBeingRevealed)
      {
        isStringBeingRevealed = true;
        StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

        if (currentDialogueIndex >= dialogueLength)
        {
          isEndOfDialogue = true;
        }
      }
      yield return 0;
    }
    while (true)
    {
      if (Input.GetKeyDown(DialogueInput))
      {
        break;
      }
      yield return 0;
    }

    HideIcons();
    isEndOfDialogue = false;
    isDialoguePlaying = false;
  }

  private IEnumerator DisplayString(string stringToDisplay)
  {
    int stringLength = stringToDisplay.Length;
    int currentCharIndex = 0;

    HideIcons();

    TextComponent1.text = "";

    while (currentCharIndex < stringLength)
    {
      TextComponent1.text += stringToDisplay[currentCharIndex];
      currentCharIndex++;

      if (currentCharIndex < stringLength)
      {
        if (Input.GetKey(DialogueInput))
        {
          yield return new WaitForSeconds(SecondsBetweenChars * CharacterRateMultiplier);
        }
        else
        {
          yield return new WaitForSeconds(SecondsBetweenChars);
        }
      }
      else break;
    }

    ShowIcon();

    while (true)
    {
      if (Input.GetKeyDown(DialogueInput))
      {
        break;
      }
      yield return 0;
    }

    HideIcons();

    isStringBeingRevealed = false;
    TextComponent1.text = "";
  }

  private void HideIcons()
  {
    ContinueIcon.SetActive(false);
    StopIcon.SetActive(false);
  }

  private void ShowIcon()
  {
    if (isEndOfDialogue)
    {
      StopIcon.SetActive(true);
      return;
    }
    ContinueIcon.SetActive(true);
  }

}

