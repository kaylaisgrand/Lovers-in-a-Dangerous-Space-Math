using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class BossFightClickHandler : MonoBehaviour {

	public GameObject Master;
	public GameObject Spawn;
	private SpawnerScript SpwnScript;
	private BossFightMasterObject MstrScript;
	public int LifeCount;
	private int CorrectCount;
	private int BossHealth = 12;
	private int FirstStart = 1;


	public GameObject Txt;
	public GameObject Counter;
	public GameObject WaveCount;
	public GameObject Timer;
	public GameObject Button1;
	public GameObject Button2;
	public GameObject Button3;
	public GameObject Button4;
	public GameObject Button5;



	public GameObject GDShip;

	public Animator AnimateShip;

		// Use this for initialization




	public void Reset()
	{
		MstrScript = Master.GetComponent<BossFightMasterObject>();
		MstrScript.NewMultiplyProblem();
		MstrScript.RandomlySetAnswers();
	}

	public void ButtonAnswer()
	{
		MstrScript = Master.GetComponent<BossFightMasterObject>();
		SpwnScript = Spawn.GetComponent<SpawnerScript>();

		BossHealth = 11 - CorrectCount;
		MstrScript.WaveCount.GetComponent<Text>().text = "The Great Divider \n Health: " + BossHealth.ToString() +" / 12";

		string theButtonValue = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

		if (theButtonValue == MstrScript.b.ToString())
		{
			SpwnScript.PlayerBossFire();
			CorrectCount++;
			MstrScript.WaveCount.GetComponent<Text>().text = "The Great Divider Health: " + BossHealth.ToString() +" / 12";
			if (CorrectCount <= 8) {
				//Correct 1->8
				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			} 
			else if (CorrectCount == 9) {

				//Correct 9, reduces rows to three

				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(CorrectCount == 10)
			{
				//Correct 10 reduces rows to two

				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(CorrectCount == 11)
			{
				//Correct 11 reduces rows to one

				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);

			}
			else if(CorrectCount == 12)
			{
				//YOU WIN
				GDShip.GetComponent<BossFightDestroyByContact> ().CanDie = true;
				Master.SetActive (false);
				Txt.SetActive (false);
				Counter.SetActive (false);
				WaveCount.SetActive (false);
				Timer.SetActive (false);
				Button1.SetActive (false);
				Button2.SetActive (false);
				Button3.SetActive (false);
				Button4.SetActive (false);
				Button5.SetActive (false);
				Invoke ("YouWin", 2);

			}


		}
		else
		{
			SpwnScript.BossFire();
			Invoke ("DisplayIncorrect", 1);
			LifeCount = LifeCount - 1;
			MstrScript.Counter.GetComponent<Text>().text = "Lives: " + LifeCount.ToString();

			//  print("You now have " + LifeCount.ToString() + " lives left " );
			// print("TRY AGAIN.");

		}
		//Invoke("Reset", 1);
	}
	public void YouWin(){
		
	SceneManager.LoadScene("Level Completed");
	LoadingScreenManager.LoadScene ("Level Completed");
    MstrScript.ActivateTimer = false;
	PersistentManagerScript.Instance.SetNumCorrect (CorrectCount);  //store globally the number of correct answers
	PersistentManagerScript.Instance.SetNumWrong (3 - LifeCount);   // wrong count = 3 - lifecount; Store globally the number of incorrect answers
	PersistentManagerScript.Instance.SetQuestionCount();
	
	}
	public void DisplayIncorrect(){
		//Shows the incorrect screen and resets the timer back to 10 sec
		MstrScript = Master.GetComponent<BossFightMasterObject>();
		MstrScript.IncorrectScreen.GetComponentInChildren<Text>().text = "Incorrect. \n \n The correct answer to \n " + MstrScript.a.ToString() + " X " + MstrScript.b.ToString() + " is " + MstrScript.c.ToString();
		MstrScript.IncorrectScreen.SetActive (true);
		MstrScript.ActivateTimer = false;
	}

	public void CloseIncorrect(){
		//closes the window and resets timer
		if (FirstStart == 1) {
			
			AnimateShip = GDShip.GetComponent<Animator> ();
			AnimateShip.Play ("Moving");
			FirstStart++;
			Invoke ("EnabletoBegin", 4);

		}
		MstrScript = Master.GetComponent<BossFightMasterObject>();
		MstrScript.IncorrectScreen.SetActive (false);
		MstrScript.myCoolTimer = 10;
		MstrScript.ActivateTimer = true;
		Reset ();
	}

	public void EnabletoBegin(){
		Master.SetActive (true);
		Txt.SetActive (true);
		Counter.SetActive (true);
		WaveCount.SetActive (true);
		Button1.SetActive (true);
		Button2.SetActive (true);
		Button3.SetActive (true);
		Button4.SetActive (true);
		Button5.SetActive (true);
	
	}

	public void DisplayPause(){
		//Shows the pause screen and resets the timer back to 10 sec
		print("ya clicked me");
		MstrScript = Master.GetComponent<BossFightMasterObject>();
		MstrScript.PauseScreen.SetActive (true);
		MstrScript.ActivateTimer = false;
	}

	public void ClosePause(){
		//closes the window and resets timer
		MstrScript = Master.GetComponent<BossFightMasterObject>();
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
		LifeCount = 3;
		CorrectCount = 0;
		MstrScript = Master.GetComponent<BossFightMasterObject>();

		Master.SetActive (false);
		Txt.SetActive (false);
		Counter.SetActive (false);
		WaveCount.SetActive (false);
		Button1.SetActive (false);
		Button2.SetActive (false);
		Button3.SetActive (false);
		Button4.SetActive (false);
		Button5.SetActive (false);

	
	}


	public void Update()
	{

		if(LifeCount == 0)
		{
			SceneManager.LoadScene("Level Failed");
			LoadingScreenManager.LoadScene("Level Failed");
			MstrScript.ActivateTimer = false;

			PersistentManagerScript.Instance.SetNumCorrect (CorrectCount);  //store globally the number of correct answers
			PersistentManagerScript.Instance.SetNumWrong (3 - LifeCount);   // wrong count = 3 - lifecount; Store globally the number of incorrect answers
			PersistentManagerScript.Instance.SetQuestionCount();
		}
		if (MstrScript.myCoolTimer <= 0) {
			LifeCount = LifeCount - 1;
			MstrScript.Counter.GetComponent<Text>().text = "Lives: " + LifeCount.ToString();
			DisplayIncorrect ();



			MstrScript.myCoolTimer = 10000;


		}




	}
}
