using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPhysics : MonoBehaviour {
	[HideInInspector]
	public Vector3 movementVector;
	[HideInInspector]
	public Player player;
	[HideInInspector]
	public bool onGround, onRight, onCeiling, onLeft = false;
	
	private Rigidbody rbody;
	private List<GameObject> colliderGameObjects = new List<GameObject>();
	private Vector3 groundCheckVector;

	void Awake () {
		rbody = gameObject.AddComponent<Rigidbody>();
		rbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		groundCheckVector = Vector3.down * 0.5f; //around the base of the feets
	}
	
	public void Update() {
	
	}
	
	public void Move(float horizontal, bool jump) {
		CheckOnGround();
		
		Vector3 moveVector = Vector3.zero;
		if(rigidbody.velocity.x < player.maxSpeed) {
			moveVector.x = horizontal * player.acc;
		}
		
		if(onGround && jump) {
			moveVector.y = player.jumpforce;
		}
		
		rigidbody.AddForce (moveVector);
	}
	
	private void CheckOnGround() {
		onGround = false;
		Collider[] colliders = Physics.OverlapSphere(transform.TransformPoint(groundCheckVector), 0.3f);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				onGround = true;
		}
	}
}
