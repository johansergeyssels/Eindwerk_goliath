using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(GrapplingGun))]
[RequireComponent(typeof(Collider))]
public class Player : MonoBehaviour {
	public float jumpforce = 0;
	public float acc = 1f;
	public float maxSpeed = 10;
	
	private PlayerController controller;
	private PlayerPhysics physics;
	private GrapplingGun grapplingGun;
	

	void Awake () {
		physics = GetComponent<PlayerPhysics>();
		controller = GetComponent<PlayerController>();
		grapplingGun = GetComponent<GrapplingGun>();
		
		physics.player = this;
		
		controller.physics = physics;
		controller.grapplingGun = grapplingGun;
		
		grapplingGun.physics = physics;
	}

	void Update () {
		
	}
}
