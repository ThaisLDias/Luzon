using UnityEngine;
using System.Collections;
using System.Diagnostics;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;

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

	public bool hasKey = false;
	public GameObject c;


	#region has
	public bool hasGravity, hasWallJump;
	#endregion
	Transform otherHorizontal,otherVertical;


	/**/

	void Start() {
		anim = GetComponent<Animator> ();
		controller = GetComponent<Controller2D> ();
		sprite = GetComponent<SpriteRenderer> ();
	
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


		otherVertical = controller.verticalLastHit.transform;
		if (controller.collisions.below && otherVertical.gameObject.tag == "Triangle") {
			Application.LoadLevel(Application.loadedLevel);
			PlayerPrefs.SetInt("mortes", PlayerPrefs.GetInt("mortes") + 1);
			StartCoroutine(wait());
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
			if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
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

		}

			if (Input.GetAxis ("Vertical") >= 0) {
				if (Input.GetAxisRaw ("Vertical") > 0) {
					/*if (wallSliding) {
						if (wallDirX == input.x) {
							velocity.x = -wallDirX * wallJumpClimb.x;
							velocity.y = wallJumpClimb.y;
						} else if (input.x == 0) {
							velocity.x = -wallDirX * wallJumpOff.x;
							velocity.y = wallJumpOff.y;
						} else {
							velocity.x = -wallDirX * wallLeap.x;
							velocity.y = wallLeap.y;
						}
					}*/
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

	void Update() {

		OtherCollision ();
		LevelHandler ();
		GravityCalculator ();
		Move ();
		WallJump ();
		AnimationHandler ();

	}





	IEnumerator wait() 
	{
		yield return new WaitForSeconds(0.9f);
		Application.LoadLevel(Application.loadedLevel);
	} 

}