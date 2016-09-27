using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	Player player;
	bool hasGravity, canWallJump;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
}
