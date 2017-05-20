using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

	public float groundCheckLength = 1.2f;

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;

	private PlayerMotor motor;

	void Start ()
	{
		motor = GetComponent<PlayerMotor> ();
	}

	void Update()
	{
		float _xMov = Input.GetAxisRaw ("Horizontal");
		float _zMov = Input.GetAxisRaw ("Vertical");

		//get individual axis velocities from input
		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		//define velocity
		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		//send velocity to motor
		motor.Move (_velocity);

		//Calculate rotation as a 3d vector. turning left and right
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		//Apply rotation
		motor.Rotate(_rotation);

		//Calculate camera rotation as a 3d vector
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * lookSensitivity;

		//Apply rotation
		motor.RotateCamera(_cameraRotation);

		Vector3 forward = transform.TransformDirection (-Vector3.up);

		if (Input.GetButton ("Jump") == true && Physics.Raycast (transform.position, -Vector3.up, groundCheckLength)) {
			Debug.DrawRay (transform.position, forward * groundCheckLength, Color.green );
			motor.jump = true;
		} else {
			Debug.DrawRay (transform.position, forward * groundCheckLength, Color.green );
			motor.jump = false;
		}
	}
}
