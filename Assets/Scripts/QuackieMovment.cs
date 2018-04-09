using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackieMovment : MonoBehaviour {

	public bool isGrounded;
	private float speed;
	private float rotSpeed;
	private Vector3 jump;
	public float jumpForce = 10f;
	public bool isStanding;
	//walk speed
	public float w_speed = 0.1f;
	//run speed
	public float r_speed = 0.25f;
	//rotation speed
	public float rot_speed = 3.0f;
	Rigidbody rb;
	Animator anim;
	public static int timeWatch;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
		isGrounded = true; //indicate that we are in the ground
		isStanding = true;
	}
	
	void FixedUpdate () {
		isStanding = anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Up");

		if(!isStanding){
		
			if (isGrounded) {
				//moving forward and backward
				if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift)) {
					speed = w_speed;
					movementControl("WalkingForward");
				} else if (Input.GetKey(KeyCode.S)) {
					speed = w_speed;
					movementControl("WalkingBackward");
				} else {
					movementControl("idle");
				}

				if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) {
					speed = r_speed;
					movementControl("RunningForward");
				}

				//moving right and left
				if (Input.GetKey(KeyCode.A)) {
					rotSpeed = rot_speed;
				} else if (Input.GetKey(KeyCode.D)) {
					rotSpeed = rot_speed;
				} else {
					rotSpeed = 0;
				}
			}

			var z = Input.GetAxis("Vertical") * speed;
			var y = Input.GetAxis("Horizontal") * rotSpeed;

			transform.Translate(0, 0, z);
			transform.Rotate(0, y, 0);

			// Jumping function
			if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
				// TODO: FIX THIS
				rb.AddForce(jump * jumpForce, ForceMode.Impulse);
				anim.SetTrigger("isJumping");
				isGrounded = false;
			}
		}
	}

	void movementControl(string state)
	{
		switch (state)
		{
			case "RunningForward":
				anim.SetBool("isRunningForward", true);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isIdle", false);
				break;
			case "WalkingForward":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", true);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isIdle", false);
				break;
			case "WalkingBackward":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", true);
				anim.SetBool("isIdle", false);
				break;
			case "idle":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isIdle", true);
				break;
		}

	}

	void OnCollisionStay()
	{
		isGrounded = true;
	}
}
