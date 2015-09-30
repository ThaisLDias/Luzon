using UnityEngine;
using System.Collections;

public class LevelManagment : MonoBehaviour {

	public int level;

	public void levelManager () {
		Application.LoadLevel (level); 	
	}
}
