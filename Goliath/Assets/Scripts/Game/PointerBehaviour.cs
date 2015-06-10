using UnityEngine;
using System.Collections;

public class PointerBehaviour : MonoBehaviour {
	private Renderer r;
	[SerializeField]
	private GameObject target;
	private Renderer targetRenderer;

	// Use this for initialization
	void Awake () {
		r = GetComponentInChildren<Renderer>();
		targetRenderer = target.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		r.enabled = !targetRenderer.isVisible;
		transform.LookAt(target.transform.position);
	}
}
