using UnityEngine;
using System.Collections;

public class BackgroundBehaviour : MonoBehaviour {
	[SerializeField]
	private float movingfactor = 0.001f;
	[SerializeField]
	private float distanceFactor = 1;
	[SerializeField]
	private Vector2 offset;
	
	private Material material;
	private Renderer r;
	
	void Awake () {
		r = GetComponent<Renderer>();
		material = r.material;
		material.mainTextureScale = new Vector2(distanceFactor, distanceFactor);
		
	}
	
	void Update() {
		material.mainTextureOffset = new Vector2(transform.position.x, transform.position.y) * movingfactor + offset;
	}
}
