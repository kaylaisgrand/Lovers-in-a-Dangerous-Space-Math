using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightDestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public bool CanDie = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || this.tag == other.tag)
		{
			return;


		}


		if (other.tag == "Player") {
			
			Destroy (other.gameObject);
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			if (CanDie == true) {
				print ("can Die was true, GD killed");
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				Destroy(gameObject);
			}
		}
	}
}
