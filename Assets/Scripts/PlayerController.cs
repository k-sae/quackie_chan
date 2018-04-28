using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private Camera cam;
	[HideInInspector] public static Transform playerTransform;
	[SerializeField] private GameObject pivot;
	[SerializeField] private MouseLook mouseLook;
	[SerializeField] private float walkSpeed = 5f;
	[SerializeField] private float runSpeed = 10f;
	[SerializeField] private float flyingHeight = 800f;
	[SerializeField] private float flyingFuelBurnSpeed = 1f;
	[SerializeField] private float flyingFuelRegenSpeed = 0.3f;

	private float flyingFuelAmount = 1f;
	private bool isStanding = true;
	private bool isGrounded = true;
	private bool isRunning = false;
	private bool isFlying = false;
	private Vector3 velocity = Vector3.zero;
	private Vector3 flyingForce = Vector3.zero;
	private Animator anim;
	private Rigidbody rb;

	private void Awake() {
		playerTransform = GetComponent<Transform>();
	}
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		mouseLook.Init(transform, pivot.transform);
	}

	void Update ()
	{
		isStanding = anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Up");
		if (!isStanding)
		{
			//Calculate movement velocity as a 3D vector
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");
			isRunning = Input.GetKey(KeyCode.LeftShift);

			Vector3 horizontal = transform.right * x;
			Vector3 vertical = transform.forward * z;

			float speed = (isRunning && z > 0) ? runSpeed : walkSpeed;

			// Final movement vector
			velocity = (horizontal + vertical) * speed;

			// Rotate the camera
			RotateView();

			// Calculate the flyingforce based on player input		
			if (Input.GetButton("Jump") && flyingFuelAmount > 0f)
			{
				flyingFuelAmount -= flyingFuelBurnSpeed * Time.deltaTime;

				if (flyingFuelAmount >= 0.01f)
				{
					flyingForce = Vector3.up * flyingHeight;
					isFlying = true;
				}

			} else
			{
				flyingForce = Vector3.zero;
				isFlying = false;

				if (isGrounded && !isFlying)
				{
					flyingFuelAmount = 1f;
				} else
				{
					flyingFuelAmount += flyingFuelRegenSpeed * Time.deltaTime;
				}
			}

			flyingFuelAmount = Mathf.Clamp(flyingFuelAmount, 0f, 1f);

			// Play animation clips upon action
			if (isFlying) 
			{
				movementControl("Flying");
			} else if (!isFlying && !isGrounded) 
			{
				movementControl("Falling");
			} else if (z > 0 && isRunning)
			{
				movementControl("RunningForward");
			} else if (z > 0) 
			{
				movementControl("WalkingForward");
			} else if (z < 0) 
			{
				movementControl("WalkingBackward");
			} else if (x < 0) 
			{
				movementControl("WalkingLeft");
			} else if (x > 0) 
			{
				movementControl("WalkingRight");
			} else
			{
				movementControl("idle");
			}
		}
	}

	// Run every physics iteration
	void FixedUpdate ()
	{
		PerformMovement();
		mouseLook.UpdateCursorLock();
		isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f) || (rb.velocity.y <= 0.05f && rb.velocity.y >= -0.05f);
	}

	// Perform movement based on velocity variable
	void PerformMovement ()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}

		if (flyingForce != Vector3.zero)
		{
			rb.AddForce(flyingForce * Time.fixedDeltaTime, ForceMode.Acceleration);
		}
	}

	// Gets a rotational vector for the camera
	void RotateView()
	{
		mouseLook.LookRotation(transform, pivot.transform);
	}

	void movementControl(string state)
	{
		switch (state)
		{
			case "RunningForward":
				anim.SetBool("isRunningForward", true);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isWalkingLeft", false);
				anim.SetBool("isWalkingRight", false);
				anim.SetBool("isFlying", false);
				anim.SetBool("isFalling", false);
				anim.SetBool("isIdle", false);
				break;
			case "WalkingForward":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", true);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isWalkingLeft", false);
				anim.SetBool("isWalkingRight", false);
				anim.SetBool("isFlying", false);
				anim.SetBool("isFalling", false);
				anim.SetBool("isIdle", false);
				break;
			case "WalkingBackward":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", true);
				anim.SetBool("isWalkingLeft", false);
				anim.SetBool("isWalkingRight", false);
				anim.SetBool("isFlying", false);
				anim.SetBool("isFalling", false);
				anim.SetBool("isIdle", false);
				break;
			case "WalkingLeft":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isWalkingLeft", true);
				anim.SetBool("isWalkingRight", false);
				anim.SetBool("isFlying", false);
				anim.SetBool("isFalling", false);
				anim.SetBool("isIdle", false);
				break;
			case "WalkingRight":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isWalkingLeft", false);
				anim.SetBool("isWalkingRight", true);
				anim.SetBool("isFlying", false);
				anim.SetBool("isFalling", false);
				anim.SetBool("isIdle", false);
				break;
			case "Flying":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isWalkingLeft", false);
				anim.SetBool("isWalkingRight", false);
				anim.SetBool("isFlying", true);
				anim.SetBool("isFalling", false);
				anim.SetBool("isIdle", false);
				break;
			case "Falling":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isWalkingLeft", false);
				anim.SetBool("isWalkingRight", false);
				anim.SetBool("isFlying", false);
				anim.SetBool("isFalling", true);
				anim.SetBool("isIdle", false);
				break;
			case "idle":
				anim.SetBool("isRunningForward", false);
				anim.SetBool("isWalkingForward", false);
				anim.SetBool("isWalkingBackward", false);
				anim.SetBool("isWalkingLeft", false);
				anim.SetBool("isWalkingRight", false);
				anim.SetBool("isFlying", false);
				anim.SetBool("isFalling", false);
				anim.SetBool("isIdle", true);
				break;
		}

	}
}
