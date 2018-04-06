using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	public bool isGrounded;
	private float speed;
	private float rotSpeed;
	public float jumpHeight;
	public bool isSleeping;
	//walk speed
	private float w_speed = 0.1f;
	//run speed
	private float r_speed = 0.25f;
	//rotation speed
	private float rot_speed = 3.0f;
	Rigidbody rb;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isGrounded = true; //indicate that we are in the ground
		isSleeping = true;
	}
	
	// Update is called once per frame
	void Update () {
		
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
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) {
			// TODO: FIX THIS

			rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
			anim.SetTrigger("isJumping");
			OnCollisionEnter ();
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

	void OnCollisionEnter()
	{
		isGrounded = true;
	}

}
