using UnityEngine;
using System.Collections;

public class LevelPass : MonoBehaviour {

	private int index;

	void Start(){
<<<<<<< HEAD

		index = PlayerPrefs.GetInt ("lastLevel") + 1;

		if (index == 10) {
			index = 0;
		}

=======
		index = PlayerPrefs.GetInt ("lastLevel") + 1;
>>>>>>> origin/master
		StartCoroutine (pass());
	}

	IEnumerator pass(){
		yield return new WaitForSeconds(.5f);
		Application.LoadLevel(index);
	}
}
