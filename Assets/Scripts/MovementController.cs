using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	public bool isGrounded;
	private float speed;
	public float rotSpeed;
	public float jumpHeight;
	public bool isSleeping;
	//walk speed
	private float w_speed = 0.05f;
	//rotation speed
	private float rot_speed = 1.0f;
	Rigidbody rb;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isGrounded = true; //indicate that we are in the ground
		isSleeping= true;
		}
	
	// Update is called once per frame
	void Update () {
		
		//&& anim.GetBool("isJumping") == true
		if (isGrounded) {
				//moving forward and backward
				if (Input.GetKey (KeyCode.W)) {
					movementControl ("Walking");
					speed = w_speed;}
			 
			//moving right and left
			else if (Input.GetKey (KeyCode.S)) {
					movementControl ("WalkingBackward");
				     rotSpeed = rot_speed;
				} else {
					movementControl ("idle");
				}
				if (Input.GetKey (KeyCode.A)) {
					rotSpeed = rot_speed;
				} else if (Input.GetKey (KeyCode.D)) {
					rotSpeed = rot_speed;
				} else {
					rotSpeed = 0;
				}
			}
		if (Input.GetKeyDown (KeyCode.Z)) {
			anim.SetTrigger ("isRuning");
			rotSpeed = rot_speed;

		}
			var z = Input.GetAxis ("Vertical") * speed;
			var y = Input.GetAxis ("Horizontal") * rotSpeed;
			transform.Translate (0, 0, z);
			transform.Rotate (0, y, 0);
			//jumping function
			if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			anim.SetTrigger ("isJumping");
			rb.AddForce (0, jumpHeight * Time.deltaTime, 0);
			isGrounded= false;
			}
			
	}
	void movementControl(string state)
	{
		switch (state)
		{
		case "WalkingForward":
			anim.SetBool("isWalking", true);
			anim.SetBool("isWalkingBackward", false);
			anim.SetBool("isIdle", false);
			anim.SetBool("hasSprint", false);
			break;
		case "WalkingBackward":
			anim.SetBool("isWalking", false);
			anim.SetBool("isWalkingBackward", true);
			anim.SetBool("isIdle", false);
			anim.SetBool("hasSprint", false);
			break;
		case "idle":
			anim.SetBool("isWalking", false);
			anim.SetBool("isWalkingBackward", false);
			anim.SetBool("isIdle", true);
			anim.SetBool("hasSprint", false);
			break;
		case "sprint":
			anim.SetBool("isWalking", false);
			anim.SetBool("isWalkingBackward", false);
			anim.SetBool("isIdle", false);
			anim.SetBool("hasSprint", true);
			break;
			break;
		}

	}


	void OnCollisionEnter()
	{
		isGrounded = true;
	}

}
