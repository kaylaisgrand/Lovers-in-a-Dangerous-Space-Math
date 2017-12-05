using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterScript : MonoBehaviour
{

	public string LevelName;
	public int MultiplyValue;
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


   // public int LifeCount = 3; //if lifecount = 0, player loses, Game Over.
    public int a;
    public int b;
    public int c;


	public void NewMultiplyProblem(int value)
    {
		if (LevelName == "LEVEL 12") {
			a = Random.Range (1, 13);
			MultiplyValue = a;
		}
		else {
			a = value;
		}

		b = Random.Range (1, 13);
		c = a * b;


        Txt.GetComponent<Text>().text = a.ToString() + " X " + b.ToString() + " = ?" ;



    }

	public int RandomNotC(int val)
    {
		int maxrange = (val * 12) + 1;

        int x = Random.Range(1, maxrange);

		if (x != c) {
			return x;
		} 
		else {
			return RandomNotC (val);
		}

    }

	public void RandomlySetAnswers(int max)
    {
        int r = Random.Range(0, 5);  //Randomly picks array element number between 0 - 4;

		for (int i = 0; i < 5; i++) {
			ShipValues [i] = RandomNotC (max);  //Sets all values to random and not equal to C;

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

		if (LevelName == "LEVEL 12") {
			IncorrectScreen.GetComponentInChildren<Text> ().text = "LEVEL 12: \n Review Challenge";
		} 
		else {
			IncorrectScreen.GetComponentInChildren<Text> ().text = LevelName + ": \n Multiplying with " + MultiplyValue.ToString ();
		}
	}


    // Use this for initialization
    void Start()
    {
		
		PersistentManagerScript.Instance.LevelName = SceneManager.GetActiveScene ().name;

		if (LevelName == "LEVEL 12") {
			MultiplyValue = Random.Range (1, 13);

		}


		PauseScreen.SetActive (false);
        SpwnScript = Spawn.GetComponent<SpawnerScript>();

		PrintIntro ();

        Counter.GetComponent<Text>().text = "Lives: 3";

        SpwnScript.SpawnRowOne(); // Spawn Row 1
        SpwnScript.SpawnRowTwo();
        SpwnScript.SpawnRowThree();
        SpwnScript.SpawnRowFour();

		NewMultiplyProblem(MultiplyValue);

		RandomlySetAnswers(MultiplyValue);
	

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
