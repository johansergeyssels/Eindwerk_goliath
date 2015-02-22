using UnityEngine;
using System.Collections;

public class MainGuy : MonoBehaviour
{
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;

	private bool onGround = false;
	private Vector3 s;
	//private Collider collider;
	

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
			if(horizontal == 0) {
				
			}
			else if (Mathf.Abs (rigidbody.velocity.x) < maxSpeed && horizontal != 0) {
				Vector3 moveVector = new Vector3 (horizontal * acc, 0, 0);
				rigidbody.AddForce (moveVector);
			}
		}
		else if(sign == -horizontal) {
			Vector3 moveVector = new Vector3 (horizontal * acc, 0, 0);
			rigidbody.AddForce (moveVector);
		}
	}
	
	void OnCollisionEnter(Collision col) {
		DetectOnGround();
	}
	
	void OnCollisionExit(Collision col) {
		DetectOnGround();
	}
	
	private void DetectOnGround() {
		
		onGround = false;
		Vector3 p = transform.position;
		Vector3 s = transform.localScale;
		
		for(int i = 0; i < 2; i++) {
			float x = p.x - s.x / 2 + s.x * i;
			float y = p.y;
			Ray ray = new Ray(new Vector3(x, y, 0), Vector3.down);
			//Debug.DrawRay(new Vector3(x, y, 0), Vector3.down * s.y / 2, Color.white, 5);
			if(Physics.Raycast(ray, s.y / 2)) {
				onGround = true;
			}
		}
		
		{
			float x = p.x - s.x / 2;
			float y = p.y - s.y / 2;
			Ray ray = new Ray(new Vector3(x + 0.001f, y, 0), Vector3.right * s.x);
			Debug.DrawRay(new Vector3(x, y, 0), Vector3.right * s.x, Color.white, 5);
			if(Physics.Raycast(ray, s.x)) {
				onGround = true;
			}
		}
		Debug.Log(!onGround);
		rigidbody.useGravity = !onGround;
		//Debug.Log(Time.frameCount + " onGround = " + onGround);
	}
}