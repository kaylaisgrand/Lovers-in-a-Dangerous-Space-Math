using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Level1ClickHandler : MonoBehaviour {

    public GameObject Master;
    public GameObject Spawn;
    private SpawnerScript SpwnScript;
    private Level1MasterScript MstrScript;
	public int LifeCount;
    private int CorrectCount;



    public void Reset()
    {
        MstrScript = Master.GetComponent<Level1MasterScript>();
        MstrScript.NewMultiplyProblem();
        MstrScript.RandomlySetAnswers();
    }

    public void ButtonAnswer()
    {
        MstrScript = Master.GetComponent<Level1MasterScript>();
        SpwnScript = Spawn.GetComponent<SpawnerScript>();

        string theButtonValue = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

        if (theButtonValue == MstrScript.c.ToString())
        {
            SpwnScript.PlayerFireFirstRow();
            CorrectCount++;
			MstrScript.WaveCount.GetComponent<Text>().text = "Waves \n Destroyed: " + CorrectCount.ToString() +"/12";
			if (CorrectCount <= 8) {
				//Correct 1->8
				SpwnScript.Invoke ("RemoveRowFour", 1);
				SpwnScript.Invoke ("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				SpwnScript.Invoke ("SpawnRowFour", 2);
				Invoke("Reset", 1);
			} 
			else if (CorrectCount == 9) {

				//Correct 9, reduces rows to three
		        SpwnScript.Invoke("RemoveRowFour", 1);
                SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(CorrectCount == 10)
			{
				//Correct 10 reduces rows to two
				SpwnScript.Invoke("RemoveRowThree", 1);
				SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(CorrectCount == 11)
			{
				//Correct 11 reduces rows to one
				SpwnScript.Invoke("RemoveRowTwo", 1);
				SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
				Invoke("Reset", 1);
			}
			else if(CorrectCount == 12)
			{
				//YOU WIN
				MstrScript.WinScreen.SetActive (true);
				MstrScript.ActivateTimer = false;

			}

           /* if(CorrectCount == 1)
            {
                //Correct 1
         /*       SpwnScript.Invoke("RemoveRowFour", 1);
                SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
            }
            else if(CorrectCount == 2)
            {
                //Correct 2
                SpwnScript.Invoke("RemoveRowThree", 1);
                SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
            }
            else if(CorrectCount == 3)
            {
                //Correct 3
                SpwnScript.Invoke("RemoveRowTwo", 1);
                SpwnScript.Invoke("SpawnRowOne", 1);
				MstrScript.myCoolTimer = 10;
            }
            else if(CorrectCount == 4)
            {
                //YOU WIN
				MstrScript.WinScreen.SetActive (true);
				MstrScript.ActivateTimer = false;

            }
		*/

        }
        else
        {
            SpwnScript.EnemyFire();
			Invoke ("DisplayIncorrect", 1);
            LifeCount = LifeCount - 1;
            MstrScript.Counter.GetComponent<Text>().text = "Lives: " + LifeCount.ToString();

			//  print("You now have " + LifeCount.ToString() + " lives left " );
           // print("TRY AGAIN.");

        }
		//Invoke("Reset", 1);
    }

	public void DisplayIncorrect(){
		//Shows the incorrect screen and resets the timer back to 10 sec
		MstrScript = Master.GetComponent<Level1MasterScript>();
		MstrScript.IncorrectScreen.GetComponentInChildren<Text>().text = "Incorrect. \n The correct answer to " + MstrScript.a.ToString() + " X " + MstrScript.b.ToString() + " is " + MstrScript.c.ToString();
		MstrScript.IncorrectScreen.SetActive (true);
		MstrScript.ActivateTimer = false;
	}

	public void CloseIncorrect(){
		//closes the window and resets timer
		MstrScript = Master.GetComponent<Level1MasterScript>();
		MstrScript.IncorrectScreen.SetActive (false);
		MstrScript.myCoolTimer = 10;
		MstrScript.ActivateTimer = true;
		Reset ();
	}
	public void DisplayPause(){
		//Shows the pause screen and resets the timer back to 10 sec
		MstrScript = Master.GetComponent<Level1MasterScript>();
		MstrScript.PauseScreen.SetActive (true);
		MstrScript.ActivateTimer = false;
	}

	public void ClosePause(){
		//closes the window and resets timer
		MstrScript = Master.GetComponent<Level1MasterScript>();
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
	}

	public void Start(){
		LifeCount = 3;
		CorrectCount = 0;
		MstrScript = Master.GetComponent<Level1MasterScript>();

	}


    public void Update()
    {

		if(LifeCount == 0)
        {
           
			MstrScript.LossScreen.SetActive (true);
			MstrScript.ActivateTimer = false;

        }
		if (MstrScript.myCoolTimer <= 0) {
			LifeCount = LifeCount - 1;
			MstrScript.Counter.GetComponent<Text>().text = "Lives: " + LifeCount.ToString();
			DisplayIncorrect ();



			MstrScript.myCoolTimer = 10000;


		}




    }
}
