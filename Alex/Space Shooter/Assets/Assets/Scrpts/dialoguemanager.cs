using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dialoguemanager : MonoBehaviour
{

  public Text nameText;
  public Text dialogueText;

  private Queue<string> sentences;
  // Use this for initialization
  void Start()
  {
    sentences = new Queue<string>();
  }

  // Update is called once per frame
  void Update() { }

  public void StartDialogue(Dialogue dialogue)
  {
    nameText.text = dialogue.CHARname;
    sentences.Clear();

    foreach (string line in dialogue.sentences)
    {
      sentences.Enqueue(line);
    }

    DisplayNextSentence();
  }
  public void DisplayNextSentence()
  {
    if (sentences.Count == 0)
    {
      EndDialogue();
      return;
    }
    string line = sentences.Dequeue();
    StopAllCoroutines();
    StartCoroutine(TypeSentence(line));
  }

  IEnumerator TypeSentence(string line)
  {
    dialogueText.text = "";
    foreach (char letter in line.ToCharArray())
    {
      dialogueText.text += letter;
      yield return null;
    }
  }
  void EndDialogue()
  {
    Debug.Log("End of conversation");
  }

}
