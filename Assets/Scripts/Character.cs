using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	
	public float speed = 1f;
	public float jump = 0;
	public bool hasKey = false;
<<<<<<< HEAD
	public GameObject c;
=======
>>>>>>> origin/master

	#region AnimationBools

	bool animWalking;
	bool dead;
	int animJump;

	#endregion

	Animator anim;
	Rigidbody2D rb;

<<<<<<< HEAD

	
	void Start(){
		
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();



=======
	void Start(){

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

>>>>>>> origin/master
	}

	void AnimUpdate(){

		anim.SetBool ("Moving" , animWalking);
		anim.SetBool("Dead" , dead);
		anim.SetInteger("JumpState" , animJump);

	}
	
	void Update () 
	{
		animWalking = false;

		if (Input.GetKey (KeyCode.D)) {
			if (Application.loadedLevel != 3) {
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			} else {
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			}

			if(Application.loadedLevel != 9)
				animWalking = true;
		}
		
		
		if (Input.GetKey (KeyCode.A)) {
			if (Application.loadedLevel != 3) {
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			} else {
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			}
			if(Application.loadedLevel != 9)
				animWalking = true;
		}

		if (Input.GetKey (KeyCode.W) && Application.loadedLevel == 9) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.S) && Application.loadedLevel == 9) {
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}
		

		if (Input.GetKey (KeyCode.W) && jump <= 0 && Application.loadedLevel != 9) {
			rb.velocity = new Vector3 (0, 20, 0);
			jump += 1;
			animJump += 1;
<<<<<<< HEAD
=======
			StartCoroutine (basicTimer ());
			animJump += 1;	

>>>>>>> origin/master
		}

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
			
		} 

<<<<<<< HEAD
		
		/*if (Application.loadedLevel == 7) {
			
			audio.Play();
			Debug.Log("Entrou");
		}*/

=======
>>>>>>> origin/master
		AnimUpdate ();
        Debug.Log(PlayerPrefs.GetInt("mortes"));
    }

	void OnMouseDrag() {
		if (Application.loadedLevel == 7) {
			Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gameObject.transform.position = position;
<<<<<<< HEAD

		}
	}



		

	

=======
		}
	}
	
	IEnumerator basicTimer(){

		yield return new WaitForSeconds(0.000000001f);

	}
>>>>>>> origin/master

	void OnCollisionEnter2D (Collision2D colisor)
	{

		if (colisor.gameObject.tag == "Triangle") {

			dead = true;
            PlayerPrefs.SetInt("mortes", PlayerPrefs.GetInt("mortes") - 1);
            Application.LoadLevel(Application.loadedLevel);
            
			
		} 

<<<<<<< HEAD
		if (colisor.gameObject.tag != "MainCamera" && colisor.gameObject.tag != "Key")
=======
		if (colisor.gameObject.tag != "Parede" && colisor.gameObject.tag != "Key")
>>>>>>> origin/master
		{
			jump = 0;
			animJump = 0;
		}
	}

	void OnApplicationQuit() 
	{
		PlayerPrefs.DeleteAll ();
	} 
}
