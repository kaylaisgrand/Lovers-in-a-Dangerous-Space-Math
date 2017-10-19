using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Level6ClickHandler : MonoBehaviour {

    public GameObject Master;
    public GameObject Spawn;
    private SpawnerScript SpwnScript;
    private Level6MasterScript MstrScript;
    public int LifeCount = 3;
    private int CorrectCount = 0;



    public void Reset()
    {
        MstrScript = Master.GetComponent<Level6MasterScript>();
        MstrScript.NewMultiplyProblem();
        MstrScript.RandomlySetAnswers();
    }

    public void ButtonAnswer()
    {
        MstrScript = Master.GetComponent<Level6MasterScript>();
        SpwnScript = Spawn.GetComponent<SpawnerScript>();

        string theButtonValue = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

        if (theButtonValue == MstrScript.c.ToString())
        {
            SpwnScript.PlayerFireFirstRow();            
            CorrectCount++;
            if(CorrectCount == 1)
            {
                print("CORRECT!");
                SpwnScript.Invoke("RemoveRowFour", 1);
                SpwnScript.Invoke("SpawnRowOne", 1);
            }
            else if(CorrectCount == 2)
            {
                print("CORRECT!");
                SpwnScript.Invoke("RemoveRowThree", 1);
                SpwnScript.Invoke("SpawnRowOne", 1);
            }
            else if(CorrectCount == 3)
            {
                print("CORRECT!");
                SpwnScript.Invoke("RemoveRowTwo", 1);
                SpwnScript.Invoke("SpawnRowOne", 1);
            }
            else if(CorrectCount == 4)
            {
                print("CORRECT!");
                print("YOU WIN!");
                SceneManager.LoadScene(0);
            }
            
          
        }
        else
        {
            SpwnScript.EnemyFire();
            LifeCount = LifeCount - 1;
            print("Incorrect. The correct answer to " + MstrScript.a.ToString() + " X " + MstrScript.b.ToString() + " is " + MstrScript.c.ToString());
            print("You now have " + LifeCount.ToString() + " lives left " );
            print("TRY AGAIN.");
           
        }

        Invoke("Reset", 2);
    }

    public void Update()
    {
        if(LifeCount == 0)
        {
            print("Earth has been destroyed. GAME OVER, MAN! GAME OVER!");
            SceneManager.LoadScene(0);

        }
    }
}
