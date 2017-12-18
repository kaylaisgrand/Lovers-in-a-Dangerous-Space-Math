using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EASYClick : MonoBehaviour {

	public GameObject Master;
	public GameObject Spawn;


	private SpawnerScript SpwnScript;
	private EASYMaster MstrScript;
	public int IncorrectCount;
	public int CorrectCount;
	public int QuestionCount;
	public float Accuracy;
	public int localCorrect;
	public int localQcount;
	int gearshift;

	public void Reset()
	{
		MstrScript = Master.GetComponent<EASYMaster>();
		MstrScript.NewMultiplyProblem();
		MstrScript.RandomlySetAnswers();
	}
		

	public void ButtonAnswer()
	{

		MstrScript = Master.GetComponent<EASYMaster>();
		SpwnScript = Spawn.GetComponent<SpawnerScript>();
		
		string theButtonValue = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

		if (theButtonValue == MstrScript.c.ToString())
		{   
			SpwnScript.PlayerFireFirstRow();
			QuestionCount++;
			CorrectCount++;

			localCorrect++;
			localQcount++;

			Accuracy = (float)CorrectCount / QuestionCount;
			print (Accuracy);
			print ("waves destroyed/correct : " + CorrectCount);
			MstrScript.WaveCount.GetComponent<Text>().text = "Questions Completed: " + QuestionCount.ToString() +" / 40";
			if (QuestionCount <= 36) {
				//Correct 1->8
				SpwnScript.Invoke ("RemoveRowFour", 1);
				SpwnScript.Invoke ("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				SpwnScript.Invoke ("SpawnRowFour", 2);
				Invoke("Reset", 1);

			} 
			else if (QuestionCount == 37) {

				//Correct 9, reduces rows to three
				SpwnScript.Invoke("RemoveRowFour", 1);
				SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(QuestionCount == 38)
			{
				//Correct 10 reduces rows to two
				SpwnScript.Invoke("RemoveRowThree", 1);
				SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(QuestionCount == 39)
			{
				//Correct 11 reduces rows to one
				SpwnScript.Invoke("RemoveRowTwo", 1);
				SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(QuestionCount == 40)
			{
				//YOU WIN
				SceneManager.LoadScene("Boss Fight");
				LoadingScreenManager.LoadScene ("Boss Fight");
				MstrScript.ActivateTimer = false;
			//	PersistentManagerScript.Instance.SetNumCorrect (CorrectCount);  //store globally the number of correct answers
			//	PersistentManagerScript.Instance.SetNumWrong (3 - LifeCount);   // wrong count = 3 - lifecount; Store globally the number of incorrect answers
			//	PersistentManagerScript.Instance.SetQuestionCount();
			}


		}
		else
		{
			SpwnScript.EnemyFire();
			Invoke ("DisplayIncorrect", 1);
			IncorrectCount++;

			QuestionCount++;
			localQcount++;

			Accuracy = (float)CorrectCount / QuestionCount;
			print (Accuracy);

			//  print("You now have " + LifeCount.ToString() + " lives left " );
			// print("TRY AGAIN.");

		}
		//Invoke("Reset", 1);
	}

	public void DisplayIncorrect(){
		//Shows the incorrect screen and resets the timer back to 10 sec
		MstrScript = Master.GetComponent<EASYMaster>();
		MstrScript.IncorrectScreen.GetComponentInChildren<Text>().text = "Incorrect. \n \n The correct answer to \n " + MstrScript.a.ToString() + " X " + MstrScript.b.ToString() + " is " + MstrScript.c.ToString();
		MstrScript.IncorrectScreen.SetActive (true);
		MstrScript.ActivateTimer = false;
	}

	public void CloseIncorrect(){
		//closes the window and resets timer
		MstrScript = Master.GetComponent<EASYMaster>();
		MstrScript.IncorrectScreen.SetActive (false);
		MstrScript.myCoolTimer = 10;
		MstrScript.ActivateTimer = true;
		Reset ();
	}
	public void DisplayPause(){
		//Shows the pause screen and resets the timer back to 10 sec
		MstrScript = Master.GetComponent<EASYMaster>();
		MstrScript.PauseScreen.SetActive (true);
		MstrScript.ActivateTimer = false;
	}

	public void ClosePause(){
		//closes the window and resets timer
		MstrScript = Master.GetComponent<EASYMaster>();
		MstrScript.PauseScreen.SetActive (false);
		//MstrScript.myCoolTimer = 10;
		MstrScript.ActivateTimer = true;
		//MstrScript.Txt.SetActive (false);
	}


	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}
	public void LoadMainMenu(){
		SceneManager.LoadScene("Splash Screen");
		LoadingScreenManager.LoadScene("Splash Screen");

	}


	public void Start(){
		IncorrectCount = 0;
		CorrectCount = 0;
		QuestionCount = 0;
		localCorrect = 0;
		localQcount = 0;

		MstrScript = Master.GetComponent<EASYMaster>();
		Accuracy = (float)CorrectCount / QuestionCount;
	}


	public void Update()
	{
		

		if (MstrScript.myCoolTimer <= 0) {
			
			IncorrectCount++;
			QuestionCount++;
			localQcount++;

			print (Accuracy);
			DisplayIncorrect ();


			MstrScript.myCoolTimer = 10000;


		}

		if (localQcount == 8) {

			if (localCorrect <= 2) {
				gearshift = -1;
				print ("DEMOTED to: " + MstrScript.Difficulty);
				MstrScript = Master.GetComponent<EASYMaster> ();

				MstrScript.IncorrectScreen.GetComponentInChildren<Text> ().text = "Looks like you need some practice. Questions are now easier.";
				MstrScript.IncorrectScreen.SetActive (true);
				MstrScript.ActivateTimer = false;


			} 
			else if (3 <= localCorrect && localCorrect <= 5) {
				gearshift = 0;

			} 
			else if (6 <= localCorrect && localCorrect <= 8) {
				gearshift = 1;
				MstrScript = Master.GetComponent<EASYMaster>();
				MstrScript.IncorrectScreen.GetComponentInChildren<Text> ().text = "Nice Job! You're ready for more difficult questions!";
				MstrScript.IncorrectScreen.SetActive (true);
				MstrScript.ActivateTimer = false;
			}

			MstrScript.Difficulty = MstrScript.Difficulty + gearshift;
					
			if (MstrScript.Difficulty > 3) {

				MstrScript.Difficulty = 3;
			}
			if (MstrScript.Difficulty < 1) {

				MstrScript.Difficulty = 1;
			}

			print ("Difficulty number is: " + MstrScript.Difficulty);

			localQcount = 0;
			localCorrect = 0;

		}

				
	}





}
			
			

