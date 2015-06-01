using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour {
	private Animator animator;
	private Rigidbody rbody;
	private PlayerPhysics physics;
	private AttackBehaviour attackbehaviour;
	private DeadBehaviour deadbehaviour;
	private Quaternion rotationY;

	void Awake () {
		animator = GetComponent<Animator>();
		rbody = GetComponentInParent<Rigidbody>();
		physics = GetComponentInParent<PlayerPhysics>();
		attackbehaviour = GetComponentInParent<AttackBehaviour>();
		deadbehaviour = GetComponentInParent<DeadBehaviour>();
		rotationY = Quaternion.Euler(0, 90, 0);
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
		animator.SetBool("Attack", attackbehaviour.isAttacking);
		animator.SetBool("IsDead", deadbehaviour.isDead);
	}
	
	public void SetDirection(float direction) {
		rotationY = Quaternion.Euler(0, 90 * direction, 0);
	}
}
