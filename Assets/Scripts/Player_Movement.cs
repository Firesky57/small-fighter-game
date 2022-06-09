using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 10f;

	float horizontalMove = 0f;
	bool jump = false;
	

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime,  jump);
		jump = false;
	}
}