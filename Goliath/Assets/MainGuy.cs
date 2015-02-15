using UnityEngine;
using System.Collections;

public class MainGuy : MonoBehaviour
{
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;

	private bool onGround = false;
	private Vector3 s;
	

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
		detectOnGround();
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
	
	private void detectOnGround() {
		onGround = false;
		Vector3 p = transform.position;
		Vector3 s = transform.localScale;
		
		for(int i = 0; i < 3; i++) {
			float x = p.x + s.x / 2 * (i - 1);
			float y = p.y;
			Ray ray = new Ray(new Vector3(x, y, 0), Vector3.down);
			
			if(Physics.Raycast(ray, s.y / 2)) {
				onGround = true;
				break;
			}
		}
		rigidbody.useGravity = !onGround;
		Debug.Log(Time.frameCount + " onGround = " + onGround);
	}
}