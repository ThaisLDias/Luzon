using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {


	
	void OnCollisionEnter2D (Collision2D colisor)
	{



		if (colisor.gameObject.tag == "Player" && GameObject.Find ("Player").GetComponent<Character>().hasKey == true) {
			Debug.Log("Passando de fase");
		} 
	
	}
}
