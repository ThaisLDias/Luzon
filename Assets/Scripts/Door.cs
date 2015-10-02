using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    void Start()
    {
        if(Application.loadedLevel == 2)PlayerPrefs.SetInt("mortes", 200);
    }

	void OnCollisionEnter2D (Collision2D colisor)
	{

		if (colisor.gameObject.tag == "Player" && colisor.gameObject.GetComponent<Character>().hasKey) {
			PlayerPrefs.SetInt("lastLevel", Application.loadedLevel);
			Application.LoadLevel("LevelComplete");
		} 
	
	}
}
