using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D colisor)
	{

		if (colisor.gameObject.tag == "Player" && colisor.gameObject.GetComponent<Character>().hasKey) {
			PlayerPrefs.SetInt("lastLevel", Application.loadedLevel);
			Application.LoadLevel("LevelComplete");
		} 
	
	}
}
