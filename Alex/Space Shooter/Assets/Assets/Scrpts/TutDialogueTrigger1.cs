using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutDialogueTrigger1 : MonoBehaviour
{
  public Dialogue dialogue;
  public GameObject startext;
  public void TriggertutDialogue()
  {
    startext.SetActive(false);
    FindObjectOfType<Tutorialdialoguemanager1>().StartDialogue(dialogue);
  }
}
