using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(GrapplingGun))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AttackBehaviour))]
[RequireComponent(typeof(DeadBehaviour))]
public class Player : MonoBehaviour {
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;
	
	private PlayerController controller;
	private PlayerPhysics physics;
	private GrapplingGun grapplingGun;
	private AttackBehaviour attackbehaviour;
	private DeadBehaviour deadbehaviour;
	

	void Awake () {
		physics = GetComponent<PlayerPhysics>();
		controller = GetComponent<PlayerController>();
		grapplingGun = GetComponent<GrapplingGun>();
		attackbehaviour = GetComponent<AttackBehaviour>();
		deadbehaviour = GetComponent<DeadBehaviour>();
		
		physics.player = this;
		
		controller.physics = physics;
		controller.grapplingGun = grapplingGun;
		controller.attackBehaviour = attackbehaviour;
		controller.deadbehaviour = deadbehaviour;
		
		grapplingGun.physics = physics;
		
		attackbehaviour.physics = physics;
	}
}
