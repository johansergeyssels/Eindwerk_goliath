using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[HideInInspector]
	public PlayerPhysics physics;
	
	private bool jump = false;

	void Update () {
		if (Input.GetButtonDown("Jump")) {
			jump = true;
		}
	}
	
	void FixedUpdate() { 
		float horizontal = Input.GetAxisRaw ("Horizontal");
		physics.Move(horizontal, jump);
		jump = false;
	}
}
