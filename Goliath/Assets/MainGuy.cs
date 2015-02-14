using UnityEngine;
using System.Collections;

public class MainGuy : MonoBehaviour
{
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;

	private bool onGround = false;

	void Start ()
	{

	}

	void Update ()
	{
		//handling jump
		if (onGround) {
			if (Input.GetButtonDown ("Jump")) {
				rigidbody.AddForce (new Vector3 (0, jumpforce, 0));
			}
		}
	}

	void FixedUpdate() {
		//handling movement
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float sign = Mathf.Sign (rigidbody.velocity.x);		
		if (onGround) {
			if (Mathf.Abs (rigidbody.velocity.x) < maxSpeed && horizontal != 0) {
				Vector3 moveVector = new Vector3 (horizontal * acc, 0, 0);
				rigidbody.AddForce (moveVector);
			}
		}
		else if(sign == -horizontal) {
			Vector3 moveVector = new Vector3 (horizontal * acc, 0, 0);
			rigidbody.AddForce (moveVector);
		}
	}

	void OnCollisionEnter(Collision col){
		foreach (ContactPoint contact in col.contacts) {
			Ray ray = new Ray(contact.point, contact.normal);
			if(ray.direction.y > 0.5) {
				onGround = true;
				Debug.Log("on = " + ray.direction.y);
			}
		}
	}
	
	void OnCollisionExit(Collision col) {
		foreach (ContactPoint contact in col.contacts) {
			Ray ray = new Ray(contact.point, contact.normal);
			if(ray.direction.y > 0.5) {
				onGround = false;
			}
		}
	}
}