using UnityEngine;
using System.Collections;

public class LevelManagment : MonoBehaviour {

	public int level;

	public void levelManager () {
		Application.LoadLevel (level); 	
<<<<<<< HEAD
	
	}

	void Update() 
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
			
		} 

	} 
=======
	}
>>>>>>> origin/master
}
