using UnityEngine;
using System.Collections;

public class BackgroundBehaviour : MonoBehaviour {
	[SerializeField]
	private float movingfactor = 0.001f;
	[SerializeField]
	private float distanceFactor = 1;
	[SerializeField]
	private Vector2 offset;
	[SerializeField]
	private CameraBehaviour camerabehavioiur;
	
	private Material material;
	private Renderer r;
	private Transform t;
	
	void Awake () {
		r = GetComponent<Renderer>();
		material = r.material;
		material.mainTextureScale = new Vector2(distanceFactor, distanceFactor);
		if(camerabehavioiur) {
			t = camerabehavioiur.transform;
		}
		else {
			t = transform;
		}
	}
	
	void Update() {
		material.mainTextureOffset = new Vector2(t.position.x, t.position.y) * movingfactor + offset;
	}
}
