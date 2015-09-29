using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	Character player ;

	void Start(){
		try{
			player = GameObject.Find("Player").GetComponent<Character>();
		} catch{
			print("LevelPass");
		}
	}

	void OnCollisionEnter2D (Collision2D colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			player.hasKey = true; 
			Destroy (gameObject);
		} 	
	}
}
