using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private Camera cam;
	[SerializeField] private MouseLook mouseLook;
	[SerializeField] private float walkSpeed = 5f;
	[SerializeField] private float runSpeed = 10f;
	[SerializeField] private float flyingHeight = 800f;
	[SerializeField] private float flyingFuelBurnSpeed = 1f;
	[SerializeField] private float flyingFuelRegenSpeed = 0.3f;

	private float flyingFuelAmount = 1f;
	private bool isGrounded = true;
	private bool isRunning = false;
	private bool isFlying = false;
	private Vector3 velocity = Vector3.zero;
	private Vector3 flyingForce = Vector3.zero;
	private Animator animator;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		mouseLook.Init(transform , cam.transform);
	}

	void Update ()
	{
		//Calculate movement velocity as a 3D vector
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		isRunning = Input.GetKey(KeyCode.LeftShift);

		Vector3 horizontal = transform.right * x;
		Vector3 vertical = transform.forward * z;

		float speed = isRunning ? runSpeed : walkSpeed;

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
			if(isGrounded)
			{
				flyingFuelAmount = 1f;
			} else
			{
				flyingFuelAmount += flyingFuelRegenSpeed * Time.deltaTime;
			}
		}

		flyingFuelAmount = Mathf.Clamp(flyingFuelAmount, 0f, 1f);

	}

	// Run every physics iteration
	void FixedUpdate ()
	{
		PerformMovement();
		mouseLook.UpdateCursorLock();
		isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f) || (rb.velocity.y <= 0.1 && rb.velocity.y >= -0.1);
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
	public void RotateView()
	{
		mouseLook.LookRotation(transform, cam.transform);
	}
}
