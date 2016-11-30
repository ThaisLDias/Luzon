using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour {
	public GameObject g;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		g = GameObject.Find ("Player");
		Player gravity = g.GetComponent<Player> ();

		if (gravity.gravityPlataform == true) {
			rb.isKinematic = false;
		} 
	}
}
