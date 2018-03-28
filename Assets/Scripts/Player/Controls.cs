using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	public Rigidbody2D rb;
	public float movespeed;
	public bool moveright;
	public bool moveleft;
	public bool jump;
	public float jumpheight;
	public float angularVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool onGround;
	private bool canJump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (new Vector2 (0, -30), ForceMode2D.Force);
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-movespeed, rb.velocity.y);
			rb.angularVelocity = angularVelocity;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (movespeed, rb.velocity.y);
			rb.angularVelocity = -angularVelocity;
		}

		if (moveright) {
			rb.velocity = new Vector2 (movespeed, rb.velocity.y);
			rb.angularVelocity = -angularVelocity;
		}

		if (moveleft) {
			rb.velocity = new Vector2 (-movespeed, rb.velocity.y);
			rb.angularVelocity = angularVelocity;
		}
			
		if (Input.GetKey (KeyCode.Space) && onGround) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpheight);
		}

		if (jump) {
			if (onGround) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpheight);
			}
			jump = false;
		}
	}

	void FixedUpdate() {
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

}
