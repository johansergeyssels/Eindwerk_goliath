using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPhysics : MonoBehaviour {
	[HideInInspector]
	public Player player;
	[HideInInspector]
	public bool onGround, onRight, onCeiling, onLeft = false;
	[HideInInspector]
	public float direction;
	[SerializeField]
	private float disableTime = 0.2f;
	
	private float disabletimer = 0;
	private Rigidbody rbody;
	private Vector3 groundCheckVector, leftWallCheckVector, rightWallCheckVector, ceilingCheckVector;
	private PlayerAnimation playeranimation;
	private MovingPlatformBehaviour moveableGround;

	void Awake () {
		rbody = GetComponent<Rigidbody>();
		rbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		groundCheckVector = Vector3.down * 0.5f; //around the base of the feets
		leftWallCheckVector = Vector3.left * 0.5f;
		rightWallCheckVector = Vector3.right * 0.5f;
		ceilingCheckVector = Vector3.up * 0.5f;
		playeranimation = GetComponentInChildren<PlayerAnimation>();
	}
	
	public void FixedUpdate() {
		var velocity = rbody.velocity.x;
		if(Mathf.Abs(velocity) > 0.1f) {
			direction = Mathf.Sign(velocity);
			//Sign is het teken. Als het positief is dan is de waarde 1 en als het negatief is dan is de waarde 0
			playeranimation.SetDirection(direction);
		}
		if(disabletimer > 0) {
			disabletimer -= Time.fixedDeltaTime;
		}
		else {
			disabletimer = 0;
		}
		
		if(moveableGround) {
			transform.position += moveableGround.movement;
		}
	}
	
	public void Move(float horizontal, bool jump) {
		if(disabletimer > 0) return;
	
		moveableGround = null;
		onLeft = CheckOnCollision(leftWallCheckVector, 0.3f);
		//Cirkels opzij groter. 
		onRight = CheckOnCollision(rightWallCheckVector, 0.3f);
		onCeiling = CheckOnCollision(ceilingCheckVector, 0.3f);
		onGround = CheckOnCollision(groundCheckVector, 0.1f);
		
		//sets drag when not in air
		if(horizontal == 0 && onGround && !jump) {
			if(GetComponent<Rigidbody>().drag < 100) {
				rbody.drag++;
			}
		}
		else {
			rbody.drag = 0;
		}
		
		Vector3 moveVector = Vector3.zero;
		
		//moving horizontal
		if(Mathf.Abs(rbody.velocity.x) < player.maxSpeed || Mathf.Sign(horizontal) == -Mathf.Sign(rbody.velocity.x)) {
			moveVector.x = horizontal * player.acc;
		}
		//reduce speed after speeding up to much
		else if(Mathf.Abs(rbody.velocity.x) > player.maxSpeed) {
			float difference = 0;
			if(rbody.velocity.x < 0) {
				difference = -player.maxSpeed - rbody.velocity.x;
			}
			else {
				difference = player.maxSpeed - rbody.velocity.x;
			}
			moveVector.x = Mathf.Lerp(difference, 0, 0.5f);
		}
		
		//jumping
		if(jump) {
			disabletimer = disableTime;
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
	
	private bool CheckOnCollision(Vector3 v, float checkradius) {
		Collider[] colliders = Physics.OverlapSphere(transform.TransformPoint(v), checkradius);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject){
				moveableGround = colliders[i].GetComponent<MovingPlatformBehaviour>();
				//anders kan de kubus zelf als collider worden beschouwd.
				return true;
			}
		}
		return false;
	}
	
	public void Pull(Vector3 target, float power) {
		var pullVector = transform.InverseTransformPoint(target).normalized * power;
		rbody.drag = 0;
		rbody.AddForce(pullVector);
	}
}
