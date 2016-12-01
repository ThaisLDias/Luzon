using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;



[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 3.5f;

	Vector2 input;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	SpriteRenderer sprite;
	Controller2D controller;
	Animator anim;

	float lastFacingDir = 1;

	public bool hasKey;

	public bool gravityPlataform;



	#region has
	public bool hasGravity, hasWallJump;
	#endregion
	Transform otherHorizontal,otherVertical;



	public Image blImage;


	/**/

	void Start() {
		anim = GetComponent<Animator> ();
		controller = GetComponent<Controller2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		gravityPlataform = false;


		if (Application.loadedLevel != 11) {
			hasKey = false;
		}
		else 
			hasKey = true;
	
	}

	void OtherCollision(){
		otherHorizontal = controller.horizontalLastHit.transform;
		otherVertical = controller.verticalLastHit.transform;
	}

	void GravityCalculator(){
		if (hasGravity) {
			gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
			maxJumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
			minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
	
		}
	}

	void Move(){
		if (input.x == -1) 
			sprite.flipX = true;
		
		if (input.x == 1) 
			sprite.flipX = false;

		otherHorizontal = controller.horizontalLastHit.transform;
		otherVertical = controller.verticalLastHit.transform;



		if (controller.collisions.right && otherHorizontal.gameObject.tag == "Triangle" || 
			controller.collisions.left && otherHorizontal.gameObject.tag == "Triangle" || 
			controller.collisions.below && otherVertical.gameObject.tag == "Triangle" || 
			controller.collisions.above && otherVertical.gameObject.tag == "Triangle") {

			Application.LoadLevel(Application.loadedLevel);
			PlayerPrefs.SetInt("mortes", PlayerPrefs.GetInt("mortes") + 1);
		}



			if (controller.collisions.right && otherHorizontal.gameObject.tag == "Key" ||
			    controller.collisions.left && otherHorizontal.gameObject.tag == "Key" ||
			    controller.collisions.below && otherVertical.gameObject.tag == "Key" ||
			    controller.collisions.above && otherVertical.gameObject.tag == "Key") {
			if (Application.loadedLevel != 11) {
				Destroy (GameObject.Find ("Key"));
				hasKey = true;
			} else {
				blImage.enabled = true;
			} 
			}


		if (controller.collisions.right && otherHorizontal.gameObject.tag == "Door" || 
			controller.collisions.left && otherHorizontal.gameObject.tag == "Door" || 
			controller.collisions.below && otherVertical.gameObject.tag == "Door" || 
			controller.collisions.above && otherVertical.gameObject.tag == "Door") {
			if (hasKey) {
				PlayerPrefs.SetInt ("lastLevel", Application.loadedLevel);
				Application.LoadLevel ("LevelComplete");
				PlayerPrefs.SetInt ("globalDeaths", PlayerPrefs.GetInt ("globalDeaths") + PlayerPrefs.GetInt ("mortes"));
				PlayerPrefs.DeleteKey ("mortes");
			}
		}
	

		if (controller.collisions.right && otherHorizontal.gameObject.tag == "Plataform" ||
			controller.collisions.left && otherHorizontal.gameObject.tag == "Plataform" ||
			controller.collisions.below && otherVertical.gameObject.tag == "Plataform" ||
			controller.collisions.above && otherVertical.gameObject.tag == "Plataform") {
			if (controller.collisions.right || controller.collisions.left) {
				otherHorizontal.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			}
			if (controller.collisions.above || controller.collisions.below) {
				otherVertical.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			}
		}

	
	}




	void LevelHandler(){
	
		if (Application.loadedLevel != 3) {
			input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));	
		}
		else 
			input = new Vector2 (Input.GetAxisRaw ("Horizontal") * -1 , Input.GetAxisRaw ("Vertical"));	


		if (Application.loadedLevel == 9) {
			hasGravity = false;
			velocity.y = input.y * moveSpeed;
		}

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();

		} 
	}

	void WallJump(){
		if(!hasWallJump){
		int wallDirX = (controller.collisions.left) ? -1 : 1;

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		bool wallSliding = false;
			/*if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
				wallSliding = true;

				if (velocity.y < -wallSlideSpeedMax) {
					velocity.y = -wallSlideSpeedMax;
				}

				if (timeToWallUnstick > 0) {
					velocityXSmoothing = 0;
					velocity.x = 0;

					if (input.x != wallDirX && input.x != 0) {
						timeToWallUnstick -= Time.deltaTime;
					} else {
						timeToWallUnstick = wallStickTime;
					}
				} else {
					timeToWallUnstick = wallStickTime;
				}

		}*/

			if (Input.GetAxis ("Vertical") >= 0) {
				if (Input.GetAxisRaw ("Vertical") > 0) {
					if (controller.collisions.below) {
						velocity.y = maxJumpVelocity;
					}
				}
			}
		}

		if (Input.GetAxisRaw("Vertical") < 0) {
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			}
		}


		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

	}

	void AnimationHandler(){
	
		if (controller.collisions.below) {
			anim.SetBool ("Grounded", true);
		} else {
			anim.SetBool ("Grounded", false);
		}

		bool asd = (input.y == 1) ? true : false;
		anim.SetBool ("JumpButton", asd );
	
		anim.SetInteger ("Moving", Mathf.RoundToInt(input.x));
	
	}

	void OnMouseDrag() {
		if (Application.loadedLevel == 7) {
			Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gameObject.transform.position = position;
			hasGravity = false;
			gravity = 0;

		}
	}

	void OnMouseUp(){
		if (Application.loadedLevel == 7) {
			hasGravity = true;
		}
	}


	void FixedUpdate(){

		OtherCollision ();
		Move ();
		WallJump ();
	}
	void Update() {
		LevelHandler ();
		GravityCalculator ();
	}

	void LateUpdate(){
		AnimationHandler ();
	}







}