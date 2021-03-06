﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;

	public bool jump;

	private Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	//get movement vector
	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
	}

	//get rotation vector
	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}

	//get camera rotation vector
	public void RotateCamera(Vector3 _cameraRotation)
	{
		cameraRotation = _cameraRotation;
	}

	//run on physics tick
	void FixedUpdate()
	{
		PerformMovement ();
		PerformRotation ();

		if (jump)
		{
			rb.AddForce(new Vector3(0, 2.5f, 0), ForceMode.Impulse);
		}
	}

	//perform movement based on velocity variable
	void PerformMovement()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	void PerformRotation()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler(rotation));
		if (cam != null)
		{
			cam.transform.Rotate (-cameraRotation);
		}
	}
}
