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
				GetComponent<Rigidbody>().drag = 0;
				GetComponent<Rigidbody>().AddForce (new Vector3 (0, jumpforce, 0));
			}
		}
	}

	void FixedUpdate() {
		//handling movement
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float sign = Mathf.Sign (GetComponent<Rigidbody>().velocity.x);	
		if (onGround) {
			if(horizontal == 0) {
				if(GetComponent<Rigidbody>().drag < 10)
					GetComponent<Rigidbody>().drag++;
			}
			else if (Mathf.Abs (GetComponent<Rigidbody>().velocity.x) < maxSpeed && horizontal != 0) {
				GetComponent<Rigidbody>().drag = 0;
				Vector3 moveVector = new Vector3 (horizontal * acc, 0, 0);
				GetComponent<Rigidbody>().AddForce (moveVector);
			}
		}
		else {
			GetComponent<Rigidbody>().drag = 0;
			if(sign == -horizontal) {
				Vector3 moveVector = new Vector3 (horizontal * acc, 0, 0);
				GetComponent<Rigidbody>().AddForce (moveVector);
			}
		}
	}
	
	void OnCollisionEnter(Collision col) {
		DetectOnGround();
	}
	
	void OnCollisionExit(Collision col) {
		DetectOnGround();
	}
	
	void OnCollisionStay(Collision col) {
		foreach (var contact in col.contacts) {
			Debug.Log(contact.otherCollider.name);
		}
	}
	
	private void DetectOnGround() {
		
		onGround = false;
		Vector3 p = transform.position;
		Vector3 s = transform.localScale;
		
		//detect on ground
		for(int i = 0; i < 2; i++) {
			float x = p.x - s.x / 2 + s.x * i;
			float y = p.y;
			Ray ray = new Ray(new Vector3(x, y, 0), Vector3.down);
			if(Physics.Raycast(ray, s.y / 2)) {
				onGround = true;
			}
		}
		
		{
			float x = p.x - s.x / 2;
			float y = p.y - s.y / 2;
			Ray ray = new Ray(new Vector3(x + 0.001f, y, 0), Vector3.right * s.x);
			if(Physics.Raycast(ray, s.x)) {
				onGround = true;
			}
		}
		Debug.Log(!onGround);
		GetComponent<Rigidbody>().useGravity = !onGround;
		//Debug.Log(Time.frameCount + " onGround = " + onGround);
	}
}