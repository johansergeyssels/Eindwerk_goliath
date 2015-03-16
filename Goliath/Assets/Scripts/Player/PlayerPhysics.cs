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
	private Vector3 groundCheckVector, leftWallCheckVector, rightWallCheckVector, ceilingCheckVector;

	void Awake () {
		rbody = gameObject.AddComponent<Rigidbody>();
		rbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		groundCheckVector = Vector3.down * 0.5f; //around the base of the feets
		leftWallCheckVector = Vector3.left * 0.5f;
		rightWallCheckVector = Vector3.right * 0.5f;
		ceilingCheckVector = Vector3.up * 0.5f;
	}
	
	public void Update() {
	
	}
	
	public void Move(float horizontal, bool jump) {
		onGround = CheckOnCollision(groundCheckVector);
		onLeft = CheckOnCollision(leftWallCheckVector);
		onRight = CheckOnCollision(rightWallCheckVector);
		onCeiling = CheckOnCollision(ceilingCheckVector);
		
		if(onLeft) {
			Debug.Log("left " + Time.frameCount);
		}
		
		if(onRight) {
			Debug.Log("right " + Time.frameCount);
		}
		
		if(horizontal == 0 && onGround && !jump) {
			if(rigidbody.drag < 100) {
				rigidbody.drag++;
			}
		}
		else {
			rigidbody.drag = 0;
		}
		
		Vector3 moveVector = Vector3.zero;
		if(Mathf.Abs(rigidbody.velocity.x) < player.maxSpeed) {
			moveVector.x = horizontal * player.acc;
		}
		
		if(jump) {
			if(onGround) {
				moveVector.y = player.jumpforce;
			}
			else if(onLeft) {
				moveVector.x = player.jumpforce;
				moveVector.y = player.jumpforce;
			}
			else if(onRight) {
				moveVector.x = -player.jumpforce;
				moveVector.y = player.jumpforce;
			}
		}
		
		rigidbody.AddForce (moveVector);
	}
	
	private bool CheckOnCollision(Vector3 v) {
		Collider[] colliders = Physics.OverlapSphere(transform.TransformPoint(v), 0.3f);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				return true;
		}
		return false;
	}
}
