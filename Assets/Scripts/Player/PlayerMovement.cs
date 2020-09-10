using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//public variables
	public float walkSpeed = 5f;
	public float jumpPower = 12f;
	public float runSpeed= 5f;

	public Transform groundCheckPosition;
	public LayerMask groundLayer;

	//private variables
	private Rigidbody2D myBody;
	private Animator anim;

	private bool isGrounded;
	private bool jumped;



	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {

	}

	void Update () {
		CheckIfGrounded ();

		PlayerJump ();
	}

	void FixedUpdate() {
		PlayerWalk ();
	}

	void PlayerWalk() {

		float h = Input.GetAxisRaw ("Horizontal");
		string playanim;
		float speed;
		if (Input.GetKey(KeyCode.LeftShift)) {
			playanim = MyTags.PLAYER_RUN_PARAM;
			speed = runSpeed;
		} else {
			playanim = MyTags.PLAYER_WALK_PARAM;
			speed = walkSpeed;
		}

		if (h > 0) {
			myBody.velocity = new Vector2 (speed, myBody.velocity.y);

			ChangeDirection (1);

		} else if (h < 0) {
			myBody.velocity = new Vector2 (-speed, myBody.velocity.y);

			ChangeDirection (-1);

		} else {
			myBody.velocity = new Vector2 (0f, myBody.velocity.y);
		}


		anim.SetInteger (playanim, Mathf.Abs((int)myBody.velocity.x));

	}

	void ChangeDirection(int direction) {
		Vector3 tempScale = transform.localScale;
		tempScale.x = direction;
		transform.localScale = tempScale;
	}

	void CheckIfGrounded() {
		isGrounded = Physics2D.Raycast (groundCheckPosition.position, Vector2.down, 0.3f, groundLayer);

		if (isGrounded) {
			
			if (jumped) {

				jumped = false;

				anim.SetBool (MyTags.PLAYER_JUMP_PARAM , false);
			}
		}

	}

	void PlayerJump() {
		if (isGrounded) {
			if (Input.GetKey(KeyCode.Space)) {
				jumped = true;
				myBody.velocity = new Vector2 (myBody.velocity.x, jumpPower);

				anim.SetBool (MyTags.PLAYER_JUMP_PARAM, true);
			}
		}
	}

} // class














































