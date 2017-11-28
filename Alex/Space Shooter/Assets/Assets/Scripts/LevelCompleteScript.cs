using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour {

	public Text ScoreBoard;



	// Use this for initialization
	void Start () {

		float percentage = (float)((float)PersistentManagerScript.Instance.NumCorrect / (float)PersistentManagerScript.Instance.QuestionCount * 100)  ;

		ScoreBoard.GetComponent<Text> ().text = PersistentManagerScript.Instance.NumCorrect.ToString () + 
			" Correct \n " + PersistentManagerScript.Instance.NumWrong.ToString () +" Wrong \n out of " +
		PersistentManagerScript.Instance.QuestionCount.ToString () + " questions \n " + percentage.ToString("f0") + "% Accuracy";


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
