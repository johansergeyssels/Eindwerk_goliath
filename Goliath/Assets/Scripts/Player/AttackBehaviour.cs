using UnityEngine;
using System.Collections;

public class AttackBehaviour : MonoBehaviour {
	[SerializeField]
	private float cooldown = 0.5f;
	[SerializeField]
	private float radius = 0.3f;
	
	public PlayerPhysics physics;
	
	private float cooldowntimer = 0;

	private PlayerAnimation playeranimation;

	void Awake () {
		playeranimation = GetComponentInChildren<PlayerAnimation>();
	}
	
	void FixedUpdate () {
		if(cooldowntimer > 0) {
			cooldowntimer -= Time.fixedDeltaTime;
		}
		else {
			cooldowntimer = 0;
		}
	}
	
	public void Attack ()
	{
		if(cooldowntimer == 0) {
			playeranimation.AnimateAttack();
			Collider[] colliders = Physics.OverlapSphere(transform.TransformPoint(Vector3.right * physics.direction), radius);
			for (int i = 0; i < colliders.Length; i++)
			{
				var go = colliders[i].gameObject;
				if (go != gameObject) {
					var destructable = go.GetComponent<Destructable>();
					if(destructable) {
						destructable.Destroy();
					}
				}	
			}
			cooldowntimer = cooldown;
		}
	}
}
