using UnityEngine;
using System.Collections;

public class MainGuy : MonoBehaviour
{
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;

	private bool air = false;

	void Start ()
	{

	}

	void Update ()
	{
		if (!air) {
			if (Input.GetButtonDown ("Jump")) {
				rigidbody.AddForce (new Vector3 (0, jumpforce, 0));
				air = true;
			}
		}
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float sign = Mathf.Sign (rigidbody.velocity.x);
		if (!air || sign == -horizontal) {
			if (Mathf.Abs (rigidbody.velocity.x) < maxSpeed) {
				Vector3 moveVector = new Vector3 (horizontal * acc, 0, 0);
				rigidbody.AddForce (moveVector);
			}
		}
	}

	void OnCollisionEnter(Collision col){
		air = false;
	}
}