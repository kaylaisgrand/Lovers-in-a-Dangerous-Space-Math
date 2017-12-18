using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tutorialdialoguemanager1 : MonoBehaviour
{

  // public Text nameText;
  public Text dialogueText;

  public int count = -1;
  public Dialogue dialog;
  public List<GameObject> arrows;

  public GameObject backbutton;

  private Queue<string> sentences;
  // Use this for initialization
  public GameObject g;
  public GameObject m;

  public TutorialMaster tutorialm;
  public GameObject master;


  void Start()
  {
    sentences = new Queue<string>();
    arrows = new List<GameObject>();
    hideArrows(dialog);
  }

  // Update is called once per frame
  void Update() { }

  public void hideArrows(Dialogue di)
  {
    foreach (GameObject arr in di.arrows)
    {
      arr.SetActive(false);
      Debug.Log("hidden");
    }
    backbutton.SetActive(false);
  }

  public void showarrowclick(Dialogue d)
  {
    g = d.arrows[count - 1];
    g.SetActive(true);
  }
  public void lastarrowclick(Dialogue d)
  {
    m = d.arrows[count - 2];
    m.SetActive(false);

    if (count > 5)
    {
      hideArrows(d);
    }
  }

  public void gameplaydia()
  {

    if (count == 8)
    {
      tutorialm = master.GetComponent<TutorialMaster>();
      tutorialm.SetAnswers();
    }

    if (count == 12)
    {
      backbutton.SetActive(true);
    }
  }
  public void StartDialogue(Dialogue dialogue)
  {
    //nameText.text = dialogue.name;
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


    if (count > 0 && count < 6)
    {
      showarrowclick(dialog);

    }
    if (count > 1 && count < 7)
    {
      lastarrowclick(dialog);
    }
    count++;
    gameplaydia();

    Debug.Log(count);
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
