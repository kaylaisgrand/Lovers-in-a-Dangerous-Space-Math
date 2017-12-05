using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class BossFightMasterObject : MonoBehaviour {


	public string LevelName;

	//public int MaxofRange;


	public GameObject[] ButtonArray = new GameObject[5];
	private int[] ShipValues = new int[5];

	public Text Txt;
	public Text Counter;
	public Text WaveCount;
	public Text TimerText;
	public GameObject IncorrectScreen;
	public GameObject PauseScreen;
	public bool ActivateTimer;
	public float myCoolTimer = 10;


	// public int LifeCount = 3; //if lifecount = 0, player loses, Game Over.
	public int a;
	public int b;
	public int c;


	public void NewMultiplyProblem()
	{
		a = Random.Range (1, 13);
		b = Random.Range (1, 13);
		c = a * b;


		Txt.GetComponent<Text>().text = a.ToString() + " X  ___ = " + c.ToString() ;



	}

	public int RandomNotb()
	{

		int x = Random.Range(1, 13);

		if (x != b) {
			return x;
		} 
		else {
			return RandomNotb ();
		}

	}

	public void RandomlySetAnswers()
	{
		int r = Random.Range(0, 5);  //Randomly picks array element number between 0 - 4;

		for (int i = 0; i < 5; i++) {
			ShipValues [i] = RandomNotb ();  //Sets all values to random and not equal to B;

			if (i == r) {
				ShipValues [r] = b; // Random ship is set to C;

				ButtonArray[r].GetComponentInChildren<Text>().text = b.ToString();   //Randomly selected button is set = C;
			}
			else
			{

				ButtonArray [i].GetComponentInChildren<Text>().text = ShipValues [i].ToString ();  //Set all other buttons to be random 

			}


		}



	}



	// Use this for initialization
	void Start()
	{

	PersistentManagerScript.Instance.LevelName = SceneManager.GetActiveScene ().name;



		PauseScreen.SetActive (false);


		IncorrectScreen.GetComponentInChildren<Text> ().text = "BOSS FIGHT: \n The Great Divider";

		Counter.GetComponent<Text>().text = "Lives: 3";



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
