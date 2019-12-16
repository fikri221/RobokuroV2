using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	// variabel untuk menambah speed
	public float speedMultiplier;
	// jarak yang dibutuhkan untuk menambah speed
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;

	public float jumpForce;
	// atur berapa lama player jump
	public float jumpTime;
	// mengembalikan value ke 0
	private float jumpTimeCounter;

	private Rigidbody2D myRigidBody;
	private CapsuleCollider2D myCollider;
	private Animator myAnimator;

	public bool grounded;
	public bool sliding;

	public LayerMask isItGrounded;

    // Start is called before the first frame update
    void Start()
    {
		// instansiasi objek
		myRigidBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<CapsuleCollider2D>();
		myAnimator = GetComponent<Animator>();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
	}

    // Update is called once per frame
    void Update()
    {
		// cek apakah collider menyentuh ground
		grounded = Physics2D.IsTouchingLayers(myCollider, isItGrounded);

		CharMovement();
	}

	void CharMovement()
	{
		// kondisi ketika posisi player lebih besar daripada
		// MilestoneCount maka kecepatan player bertambah
		if(transform.position.x > speedMilestoneCount)
		{
			speedMilestoneCount += speedIncreaseMilestone;

			// menambah jauh milestone agar kecepatan tidak cepat bertambah
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			speed = speed * speedMultiplier;
		}

		// mengatur kecepatan robot
		myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
			}
		}

		// jauh lompatan berdasarkan lamanya tombol space ditekan
		if (Input.GetKey(KeyCode.Space))
		{
			if(jumpTimeCounter > 0)
			{
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		// ketika tombol space dilepas nilai jumpCounterTime berkurang ke 0
		if (Input.GetKeyUp(KeyCode.Space))
		{
			jumpTimeCounter = 0;
		}
		// ketika player menyentuh tanah nilai jumpTimeCounter reset ke 1 lagi 
		if (grounded)
		{
			jumpTimeCounter = jumpTime;
		}

		if (Input.GetKey(KeyCode.S))
		{
			myAnimator.SetBool("isSliding", true);
			gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
			gameObject.GetComponent<CircleCollider2D>().enabled = true;
		}
		else
		{
			myAnimator.SetBool("isSliding", false);
			gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
		}
		myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool("isGrounded", grounded);
	}
}
