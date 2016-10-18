using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	Player player ;

	void Start(){
		try{
			player = GameObject.Find("Player").GetComponent<Player>();
		} catch{
			//print("LevelPass");
		}
	}

	void OnMouseDrag() {
		if (Application.loadedLevel == 6) {
			Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gameObject.transform.position = position;
		}
	}




}
