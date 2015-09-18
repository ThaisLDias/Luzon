using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private float speed = 0.8f;
	private float Jump = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.D)) { 
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}  

		if (Input.GetKey(KeyCode.A)) { 
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		} 

		if (Input.GetKey(KeyCode.W)) { 

			rigidbody2D.AddForce(Vector3.up * Jump);
		} 
	
	}

	void OnCollisionEnter2D (Collision2D colisor)
	{
		if (colisor.gameObject.tag == "Plataform") {
			Debug.Log ("Entrou"); 
		
		} else
			Debug.Log ("Nem entrou");

		if (colisor.gameObject.tag == "Triangle") {
			Application.LoadLevel("EmConstruçao");  
			
		} 

	}
}
