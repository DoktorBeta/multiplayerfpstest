using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour {

	public float dragDist = 0.2f;
	public float dragSpeed = 0.2f;

	private bool isLooking;

	public Vector3 targetPos;
	public Vector3 pastPos;

	public float xMouse;
	public float yMouse;

	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate()
	{
		


	}

	// Update is called once per frame
	void Update () {
		float xMouse = Input.GetAxisRaw ("Mouse X");
		float yMouse = Input.GetAxisRaw ("Mouse Y");

		if (xMouse != 0 || yMouse != 0) {
			targetPos = new Vector3 (-xMouse * dragDist, -yMouse * dragDist, 0);
		} else {
			targetPos = new Vector3 (0, 0, 0);
		}
		// SMOOTHDAMP. IT WORKS. DON'T LERP, IT DOESN'T WORK.
		transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPos, ref velocity, dragSpeed);
	}
		
}
