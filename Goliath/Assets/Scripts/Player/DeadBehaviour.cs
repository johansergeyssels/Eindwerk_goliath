using UnityEngine;
using System.Collections;

public class DeadBehaviour : MonoBehaviour {
	[HideInInspector]
	public bool isDead = false;
	
	void Awake () {
		
	}
	
	void FixedUpdate() {
		if(isDead) {
			//Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		var enemy = collision.gameObject.GetComponent<DeadlyBehaviour>();
		if(enemy) {
			isDead = true;
		}
	}
}
