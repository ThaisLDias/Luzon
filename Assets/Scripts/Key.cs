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

<<<<<<< HEAD
	void OnMouseDrag() {
		if (Application.loadedLevel == 6) {
			Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gameObject.transform.position = position;
		}
	}

=======
>>>>>>> origin/master
	void OnCollisionEnter2D (Collision2D colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			player.hasKey = true; 
			Destroy (gameObject);
		} 	
	}
}
