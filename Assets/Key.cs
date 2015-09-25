using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D colisor)
	{
		
		
		if (colisor.gameObject.tag == "Player") {
			GameObject.Find("Player").GetComponent<Character> ().hasKey  = true; 
			Destroy(gameObject);
			Debug.Log("Ta");			
		} 


	
		

		
	}

}
