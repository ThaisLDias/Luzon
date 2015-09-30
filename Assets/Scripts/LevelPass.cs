using UnityEngine;
using System.Collections;

public class LevelPass : MonoBehaviour {

	private int index;

	void Start(){
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> origin/master

		index = PlayerPrefs.GetInt ("lastLevel") + 1;

		if (index == 10) {
			index = 0;
		}

<<<<<<< HEAD
=======
=======
		index = PlayerPrefs.GetInt ("lastLevel") + 1;
>>>>>>> origin/master
>>>>>>> origin/master
		StartCoroutine (pass());
	}

	IEnumerator pass(){
		yield return new WaitForSeconds(.5f);
		Application.LoadLevel(index);
	}
}
