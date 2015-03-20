using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	[HideInInspector]
	public PlayerPhysics physics;
	[HideInInspector]
	public GrapplingGun grapplingGun;

	private Dictionary<string, bool> buttons;
	private List<string> keys;
	
	void Awake() {
		buttons = new Dictionary<string, bool>();
		buttons.Add("Jump", false);
		buttons.Add("Grappling gun", false);
		
		keys = new List<string>(buttons.Keys);
	}
	
	void Update () {
		foreach(var key in keys) {
			if (Input.GetButtonDown(key)) {
				buttons[key] = true;
			}	
		}
	}
	
	void FixedUpdate() { 
		float horizontal = Input.GetAxisRaw ("Horizontal");
		
		physics.Move(horizontal, buttons["Jump"]);
		if(buttons["Grappling gun"]) {
			grapplingGun.UseGrapplingHook();
		}
		
		foreach(var key in keys) {
			buttons[key] = false;
		}
	}
}
