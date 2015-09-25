using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	
	public float speed = 1f;
	public float jump = 0;
	public bool hasKey = false;

	
	void Update () 
	{
		

		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate (Vector3.left * speed * Time.deltaTime);
			
		}

		
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
		
		if((Input.GetKey(KeyCode.W) && jump <= 0)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, 20, 0);
			jump += 1;
		}

		 
		
	}

	void OnCollisionEnter2D (Collision2D colisor)
	{


		if (colisor.gameObject.tag == "Triangle") {
			Application.LoadLevel("EmConstruçao");  
			
		} 

		if (colisor.gameObject.tag != "Parede")
		{
			jump = 0;
		}



	}
}
