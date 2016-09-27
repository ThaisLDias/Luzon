using UnityEngine;
using System.Collections;

public class Door:MonoBehaviour {

    void Start()
    {
        
    }

	void OnCollisionEnter2D (Collision2D colisor)
	{

		if (colisor.gameObject.tag == "Player" && colisor.gameObject.GetComponent<Character>().hasKey) {
			PlayerPrefs.SetInt("lastLevel", Application.loadedLevel);
			Application.LoadLevel("LevelComplete");
			PlayerPrefs.SetInt("globalDeaths", PlayerPrefs.GetInt("globalDeaths") + PlayerPrefs.GetInt("mortes"));
			PlayerPrefs.DeleteKey("mortes");
			Debug.Log (PlayerPrefs.GetInt("globalDeaths"));
		} 
	
	}
}
