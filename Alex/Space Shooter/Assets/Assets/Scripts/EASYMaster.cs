using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EASYMaster : MonoBehaviour
{
	public string LevelName;
	//public int MaxofRange;

	public GameObject Spawn;
	public GameObject[] ButtonArray = new GameObject[5];
	private int[] ShipValues = new int[5];
	private SpawnerScript SpwnScript;
	public Text Txt;
	public Text Counter;
	public Text WaveCount;
	public Text TimerText;
	public GameObject IncorrectScreen;
	public GameObject PauseScreen;
	public bool ActivateTimer;
	public float myCoolTimer = 10;

	public int a;
	public int b;
	public int c;

	public int Difficulty;

	public int[] EasyNums = new int[]{2, 5, 10};
	public int[] MedNums = new int[]{3, 4, 6, 11};
	public int[] HardNums = new int[]{7, 8, 9, 12};

	//array of size 3, with 2, 5, and 10.  then random 0-2 to select from that array

	public void NewMultiplyProblem()
	{
		
		if (Difficulty == 1) {
			int randy = Random.Range (0, 3);
			a = EasyNums [randy];
		} else if (Difficulty == 2) {
			int randy = Random.Range (0, 4);
			a = MedNums [randy];
		} else if (Difficulty == 3) {
			int randy = Random.Range (0, 4);
			a = HardNums [randy];
		}
		b = Random.Range (1, 13);
		c = a * b;


		Txt.GetComponent<Text>().text = a.ToString() + " X " + b.ToString() + " = ?" ;



	}

	public int RandomNotC()
	{

		int x = Random.Range(1, 145);

		if (x != c) {
			return x;
		} 
		else {
			return RandomNotC ();
		}

	}

	public void RandomlySetAnswers()
	{
		int r = Random.Range(0, 5);  //Randomly picks array element number between 0 - 4;

		for (int i = 0; i < 5; i++) {
			ShipValues [i] = RandomNotC ();  //Sets all values to random and not equal to C;

			if (i == r) {
				ShipValues [r] = c; // Random ship is set to C;

				ButtonArray[r].GetComponentInChildren<Text>().text = c.ToString();   //Randomly selected button is set = C;
			}
			else
			{

				ButtonArray [i].GetComponentInChildren<Text>().text = ShipValues [i].ToString ();  //Set all other buttons to be random 

			}


		}



	}

	public void PrintIntro(){

		IncorrectScreen.GetComponentInChildren<Text> ().text = "MARATHON MODE: \n Difficulty adjusts based on performance. Defeat 40 rows of enemies.";
		}


	// Use this for initialization
	void Start()
	{

	//	PersistentManagerScript.Instance.LevelName = SceneManager.GetActiveScene ().name;

		Difficulty = 1;

		PauseScreen.SetActive (false);
		SpwnScript = Spawn.GetComponent<SpawnerScript>();

		PrintIntro ();


		SpwnScript.SpawnRowOne(); // Spawn Row 1
		SpwnScript.SpawnRowTwo();
		SpwnScript.SpawnRowThree();
		SpwnScript.SpawnRowFour();

		NewMultiplyProblem();

		RandomlySetAnswers();


		TimerText.GetComponent<Text> ();
		ActivateTimer = false;

	}

	// Update is called once per frame
	void Update()
	{
		if (ActivateTimer == true) {
			myCoolTimer -= Time.deltaTime;
			if (myCoolTimer > 0) {
				TimerText.text = "Time: " + myCoolTimer.ToString ("f0");
			}
			if (myCoolTimer <= 0) {
				ActivateTimer = false;
			}
		}

	}
}
