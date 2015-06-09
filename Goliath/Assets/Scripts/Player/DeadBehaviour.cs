using UnityEngine;
using System.Collections;

public class DeadBehaviour : MonoBehaviour {
	[HideInInspector]
	public bool isDead = false;
	private float time = 2.0f;
	private float timer = 0;
	
	void Awake () {
		
	}
	
	void FixedUpdate() {
		if(isDead) {
			if(timer > 0) {
				timer -= Time.fixedDeltaTime;
			}
			else {
				if(Menu.current) {
					Menu.current.Pause();
				}
			}
		}
		
		if(Game.current == null) return;
		
		if(!isDead) {
			var pos = transform.position;
			if(pos.x < Game.current.minX 
			|| pos.x > Game.current.maxX 
			|| pos.y < Game.current.minY
			|| pos.y > Game.current.maxY) {
				isDead = true;
				timer = time;
			}
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		var enemy = collision.gameObject.GetComponent<DeadlyBehaviour>();
		if(enemy) {
			isDead = true;
			timer = time;
		}
	}
}
