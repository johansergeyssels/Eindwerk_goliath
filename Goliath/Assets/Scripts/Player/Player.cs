using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(GrapplingGun))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AttackBehaviour))]
public class Player : MonoBehaviour {
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;
	
	private PlayerController controller;
	private PlayerPhysics physics;
	private GrapplingGun grapplingGun;
	private AttackBehaviour attackbehaviour;
	

	void Awake () {
		physics = GetComponent<PlayerPhysics>();
		controller = GetComponent<PlayerController>();
		grapplingGun = GetComponent<GrapplingGun>();
		attackbehaviour = GetComponent<AttackBehaviour>();
		
		physics.player = this;
		
		controller.physics = physics;
		controller.grapplingGun = grapplingGun;
		controller.attackBehaviour = attackbehaviour;
		
		grapplingGun.physics = physics;
		
		attackbehaviour.physics = physics;
	}

	void Update () {
		
	}
}
