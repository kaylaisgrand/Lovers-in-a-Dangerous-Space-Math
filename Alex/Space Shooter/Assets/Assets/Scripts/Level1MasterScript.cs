using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1MasterScript : MonoBehaviour
{
    public GameObject Spawn;
    public GameObject[] ButtonArray = new GameObject[5];
	private int[] ShipValues = new int[5];
    private SpawnerScript SpwnScript;
    public Text Txt;
    public Text Counter;
    public Text TimerText;
	public GameObject IncorrectScreen;
	public GameObject WinScreen;
	public GameObject LossScreen;
	public bool ActivateTimer;
	public float myCoolTimer = 10;


   // public int LifeCount = 3; //if lifecount = 0, player loses, Game Over.
    public int a;
    public int b;
    public int c;

   public void NewMultiplyProblem()
    {
        a = 2;
        b = Random.Range(1, 13);
        c = a * b;

        Txt.GetComponent<Text>().text = a.ToString() + " X " + b.ToString() + " = ?" ;



    }

    public int RandomNotC()
    {
        int x = Random.Range(1, 25);

        if(x == c)
        {
            RandomNotC();
        }

        return x;

    }

    public void RandomlySetAnswers()
    {
        int r = Random.Range(0, 5);  //Randomly picks array element number between 0 - 4;

		for (int i = 0; i < 5; i++) {
			ShipValues [i] = RandomNotC ();  //Sets all values to random and not equal to C;

			if (i == r) {
				ShipValues [r] = c; // Random ship is set to C;

				ButtonArray[r].GetComponentInChildren<Text>().text = c.ToString();   //Randomly selected 		button is set = C;
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

		WinScreen.SetActive (false);
		LossScreen.SetActive (false);
        SpwnScript = Spawn.GetComponent<SpawnerScript>();
		IncorrectScreen.GetComponentInChildren<Text> ().text = "LEVEL 1 \n Multiplying with 2";
        Counter.GetComponent<Text>().text = "Lives: 3";
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
				TimerText.text = myCoolTimer.ToString ("f2");
			}
			if (myCoolTimer <= 0) {
				ActivateTimer = false;
			}
		}
	
    }
}
