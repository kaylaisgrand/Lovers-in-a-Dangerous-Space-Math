using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
  public Dialogue dialogue;
	public GameObject startext;

  public void TriggerDialogue()
  {
		startext.SetActive (false);
    FindObjectOfType<dialoguemanager>().StartDialogue(dialogue);
  }
}
