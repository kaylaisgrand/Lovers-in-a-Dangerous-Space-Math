using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour {

	public static PersistentManagerScript Instance { get; private set; }

	public string LevelName = "LevelName";
	public int NumCorrect = 0;
	public int NumWrong = 0;
	public int QuestionCount;

	private void Awake()
	{
		if (Instance == null) 
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} 
		else 
		{
			Destroy(gameObject);
		}
	}

	public void SetLevelName(string name){

		LevelName = name;
	}
	public string GetLevelName(){

		return LevelName;
	}
	public void SetNumCorrect(int i){
		NumCorrect = i;
	}

	public void SetNumWrong(int j){
		NumWrong = j;
	}

	public void SetQuestionCount(){

		QuestionCount = NumCorrect + NumWrong;
	}
}
