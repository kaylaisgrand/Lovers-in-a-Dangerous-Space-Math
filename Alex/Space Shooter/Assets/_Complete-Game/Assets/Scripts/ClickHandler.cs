using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour {

    public GameObject Master;
    public GameObject Spawn;
    private SpawnerScript SpwnScript;
    private MasterScript MstrScript;
    public int LifeCount = 3;


    //public void ButtonHey()
    //{
    //   string j = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

    //    print(j);
    //}


    public void Reset()
    {
        MstrScript = Master.GetComponent<MasterScript>();
        MstrScript.NewMultiplyProblem();
        MstrScript.RandomlySetAnswers();
    }

    public void ButtonAnswer()
    {
        MstrScript = Master.GetComponent<MasterScript>();
        SpwnScript = Spawn.GetComponent<SpawnerScript>();

        string theButtonValue = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

        if (theButtonValue == MstrScript.c.ToString())
        {
            SpwnScript.PlayerFireFirstRow();
            print("CORRECT!");
        }
        else
        {
            SpwnScript.EnemyFire();
            LifeCount = LifeCount - 1;
            print("Incorrect. The correct answer to " + MstrScript.a.ToString() + " X " + MstrScript.b.ToString() + " is " + MstrScript.c.ToString());
            print("You now have " + LifeCount.ToString() + " lives left " );
            print("TRY AGAIN.");
           
        }

        Reset();
    }

    public void Update()
    {
        if(LifeCount == 0)
        {
            print("Earth has been destroyed. GAME OVER, MAN! GAME OVER!");
            
        }
    }
}
