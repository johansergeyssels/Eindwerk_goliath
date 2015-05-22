using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	private Animator animator;
	private Rigidbody rbody;
	private PlayerPhysics physics;
	private Quaternion rotationY;

	void Awake () {
		animator = GetComponent<Animator>();
		rbody = GetComponentInParent<Rigidbody>();
		physics = GetComponentInParent<PlayerPhysics>();
		rotationY = Quaternion.Euler(0, 90, 0);
	}
	
	// Update is called once per frame
	void Update () {
		var velocity = rbody.velocity;
		animator.SetFloat("Speed", Mathf.Abs(velocity.x));
		if(velocity.x != 0) {
			var sign = Mathf.Sign(velocity.x);
			rotationY = Quaternion.Euler(0, 90 * sign, 0);
		}
		if(rotationY != transform.localRotation) {
			transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationY, 0.3f);
		}
		
		Debug.Log(physics.onGround);
		animator.SetBool("OnGround", physics.onGround);
		animator.SetBool("OnLeft", physics.onLeft);
		animator.SetBool("OnRight", physics.onRight);
		animator.SetBool("OnCeiling", physics.onCeiling);
	}
}
