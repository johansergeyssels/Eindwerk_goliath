using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPhysics : MonoBehaviour {
	[HideInInspector]
	public Player player;
	[HideInInspector]
	public bool onGround, onRight, onCeiling, onLeft = false;
	
	private Rigidbody rbody;
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
		
		
		if(horizontal == 0 && onGround && !jump) {
			if(GetComponent<Rigidbody>().drag < 100) {
				rbody.drag++;
			}
		}
		else {
			rbody.drag = 0;
		}
		
		Vector3 moveVector = Vector3.zero;
		
		if(Mathf.Abs(GetComponent<Rigidbody>().velocity.x) < player.maxSpeed || Mathf.Sign(horizontal) == -Mathf.Sign(rbody.velocity.x)) {
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
		
		rbody.AddForce (moveVector);
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
	
	public void Pull(Vector3 target, float power) {
		var pullVector = transform.InverseTransformPoint(target).normalized * power;
		rbody.drag = 0;
		rbody.AddForce(pullVector);
		Debug.DrawRay(transform.position, pullVector, Color.green, 2);
	}
}
