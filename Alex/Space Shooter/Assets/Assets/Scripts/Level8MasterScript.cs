using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level8MasterScript : MonoBehaviour
{
    public GameObject Spawn;
    public GameObject[] ButtonArray = new GameObject[5];
    private SpawnerScript SpwnScript;
    public Text Txt;


   // public int LifeCount = 3; //if lifecount = 0, player loses, Game Over.
    public int a;
    public int b;
    public int c;

   public void NewMultiplyProblem()
    {
        a = 9;
        b = Random.Range(1, 13);
        c = a * b;

        Txt.GetComponent<Text>().text = a.ToString() + " X " + b.ToString() + " = ?" ;


        
    }

    public int RandomNotC()
    {
        int x = Random.Range(1, 109);

        if(x == c)
        {
            RandomNotC();
        }
        
        return x;
        
    }

    public void RandomlySetAnswers()
    {
        int r = Random.Range(0, 5);  //Randomly picks array element number between 0 - 4;

        

        for(int i = 0; i < 5 ; i++)
        {
            

            if(i == r)
            {
                ButtonArray[r].GetComponentInChildren<Text>().text = c.ToString();   //Randomly selected button is set = C;
            }
            else
            {
                ButtonArray[i].GetComponentInChildren<Text>().text = RandomNotC().ToString(); //Set all other buttons to be random
            }

            
        }

    }

    

    // Use this for initialization
    void Start()
    {
        SpwnScript = Spawn.GetComponent<SpawnerScript>();

        
        SpwnScript.SpawnRowOne(); // Spawn Row 1
        SpwnScript.SpawnRowTwo();
        SpwnScript.SpawnRowThree();
        SpwnScript.SpawnRowFour();

        NewMultiplyProblem();

        RandomlySetAnswers();
      


    }

    // Update is called once per frame
    void Update()
    {

    }
}
