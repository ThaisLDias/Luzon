using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	
	public float speed = 1f;
	public float jump = 0;
	public bool hasKey = false;

	#region AnimationBools

	bool animWalking;
	bool dead;
	int animJump;

	#endregion

	Animator anim;
	Rigidbody2D rb;

	void Start(){

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

	}

	void AnimUpdate(){

		anim.SetBool ("Moving" , animWalking);
		anim.SetBool("Dead" , dead);
		anim.SetInteger("JumpState" , animJump);

	}
	
	void Update () 
	{

		if(Input.GetKey(KeyCode.D))
		{
			if(Application.loadedLevel != 0){
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			} else{
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			}
			animWalking = true;
		}
		
		
		if(Input.GetKey(KeyCode.A))
		{
			if(Application.loadedLevel != 0){
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			} else{
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			}
			animWalking = true;
		}

		else animWalking = false;


		if((Input.GetKey(KeyCode.W) && jump <= 0)) 
		{
			rb.velocity = new Vector3(0, 20, 0);
			jump += 1;
			animJump+=1;
			StartCoroutine(basicTimer());
			animJump+=1;	

		}
	
		AnimUpdate();	

	}

	IEnumerator basicTimer(){

		yield return new WaitForSeconds(0.000000001f);

	}

	void OnCollisionEnter2D (Collision2D colisor)
	{

		if (colisor.gameObject.tag == "Triangle") {

			dead = true;
			Application.LoadLevel(Application.loadedLevel);  
			
		} 

		if (colisor.gameObject.tag != "Parede")
		{
			jump = 0;
			animJump = 0;
		}
	}
}
