using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drop : MonoBehaviour {

    public Text output;
	public GameObject question;


    private void Start()
    {
        //nameInserter();
        this.GetComponent<Dropdown>().captionText.text = "Hint";
    }

    //public void nameInserter

    List<string> hints = new List<string> {

/*General*/"Odd times an odd number is always an odd number. Even times an even number is an even number. Even times an odd number is an even number. Order doesn’t matter in multiplication.",
/*2*/"Multiplying a number by 2 is the same as adding the number to itself.",
/*3*/"Digits of the answer added together will always be a multiple of 3",
/*4*/"The second digit is a pattern: 4,8,2,6,0.",
/*5*/"5 times an odd number will always end in 5, 5 times and even number will always end in 0",
/*6*/"The last digit of 6x (an even number) is that number. The last digit of 6 x (odd number) is the number + 5",
/*7*/" ",
/*8*/" ",
/*9*/"The two digits will always add up to 9. The first digit of the answer will be the other number minus 1",
/*10*/"The answer will be the number in the first digit and 0 in the second digit",
/*11*/"11 times a single digit number will be a two digit number where both digits are the number",
/*12*/"12 is made up of 10 +2. If you know 10 times the number and 2 times the number, you can add them to find the answer",
};
    public void Indexer (int val)
    {
        output.text = " " + hints[val];
		question.SetActive (false);
    }

}
