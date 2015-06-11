using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {
	protected bool destroyed;
	// Use this for initialization
	void Awake () {
		destroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(destroyed) {
			HandleDestroy();
		}
	}
	
	protected virtual void HandleDestroy() {
		Destroy(gameObject);
	}
	
	public void Destroy() {
		destroyed = true;
	}
}
