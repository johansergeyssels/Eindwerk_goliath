using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour {
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;
	
	private PlayerController controller;
	private PlayerPhysics physics;

	void Awake () {
		physics = GetComponent<PlayerPhysics>();
		controller = GetComponent<PlayerController>();
		
		physics.player = this;
		
		controller.physics = physics;
	}

	void Update () {
		
	}
}
