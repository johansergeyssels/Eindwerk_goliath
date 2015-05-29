using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	private Animator animator;
	private Rigidbody rbody;
	private PlayerPhysics physics;
	private Quaternion rotationY;
	private bool attack;

	void Awake () {
		animator = GetComponent<Animator>();
		rbody = GetComponentInParent<Rigidbody>();
		physics = GetComponentInParent<PlayerPhysics>();
		rotationY = Quaternion.Euler(0, 90, 0);
		attack = false;
	}
	
	void FixedUpdate () {
		var velocity = rbody.velocity;
		animator.SetFloat("Speed", Mathf.Abs(velocity.x));
		
		if(rotationY != transform.localRotation) {
			transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationY, 0.3f);
		}
		
		animator.SetBool("OnGround", physics.onGround);
		animator.SetBool("OnLeft", physics.onLeft);
		animator.SetBool("OnRight", physics.onRight);
		animator.SetBool("OnCeiling", physics.onCeiling);
		animator.SetBool("Attack", attack);
		attack = false;
	}
	
	public void SetDirection(float direction) {
		rotationY = Quaternion.Euler(0, 90 * direction, 0);
	}
	
	public void AnimateAttack() {
		attack = true;
	}
}
