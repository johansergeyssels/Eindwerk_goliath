using UnityEngine;
using System.Collections;

public class GrapplingGun : MonoBehaviour {
	[SerializeField]
	private float power;
	[SerializeField]
	private float timeToPull = 0.1f;
	[SerializeField]
	private float length = 3f;
	[SerializeField]
	private float cooldownTime = 5;
	[SerializeField]
	private float startWidth = 0.05f;
	[SerializeField]
	private float endWidth = 0.05f;
	
	public PlayerPhysics physics;
	private float pulltimer = 0;
	private float cooldowntimer = 0;
	private bool cooldown = false;
	private bool pull = false;
	private Vector3 target;
	
	private LineRenderer lineRenderer;
	
	void Awake() {
		lineRenderer = this.gameObject.AddComponent <LineRenderer>();
		lineRenderer.SetWidth (startWidth, endWidth);
		lineRenderer.SetVertexCount (2);
		lineRenderer.material.color = Color.black;
	}
	
	void Update() {
		if(pull) {
			lineRenderer.SetPosition (0, this.gameObject.transform.position);
			lineRenderer.SetPosition (1, target);
		}
	}
	
	void FixedUpdate() {
		if(pull) {
			if(pulltimer > 0) {
				pulltimer -= Time.fixedDeltaTime;
			}
			else {
				physics.Pull(target, power);
				lineRenderer.enabled = false;
				pull = false;
			}
		}
		if(cooldown) {
			if(cooldowntimer > 0) {
				cooldowntimer -= Time.fixedDeltaTime;
			}
			else {
				cooldown = false;
			}
		}
	}
	
	public void UseGrapplingHook() {
		if(!cooldown) {
			var v = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			v.z = 0;
			var ray = new Ray(transform.position, v);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, length)) {
				target = hit.point;
				pulltimer = Vector3.Distance(transform.position, target) * timeToPull;
				pull = true;
				lineRenderer.enabled = true;

				cooldowntimer = cooldownTime;
				cooldown = true;
			}
		}
	}
}
