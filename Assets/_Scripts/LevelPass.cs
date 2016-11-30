using UnityEngine;
using System.Collections;

public class LevelPass : MonoBehaviour {

	private int index;

	void Start(){

		index = PlayerPrefs.GetInt ("lastLevel") + 1;

		if (index == 15) {
			index = 16;
		}

		StartCoroutine (pass());
	}

	IEnumerator pass(){
		yield return new WaitForSeconds(.5f);
		Application.LoadLevel(index);
	}
}
