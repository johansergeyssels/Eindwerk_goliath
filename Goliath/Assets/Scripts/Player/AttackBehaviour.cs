using UnityEngine;
using System.Collections;

public class AttackBehaviour : MonoBehaviour {
	[SerializeField]
	private float cooldown = 0.5f;
	[SerializeField]
	private float radius = 0.3f;
	[SerializeField]
	private float range = 0.5f;
	[SerializeField]
	private float attacktime = 0.3f;
	
	public PlayerPhysics physics;
	public bool isAttacking;
	
	private float cooldowntimer = 0;
	private float attacktimer = 0;

	void Awake () {
		isAttacking = false;
	}
	
	void FixedUpdate () {
		if(cooldowntimer > 0) {
			cooldowntimer -= Time.fixedDeltaTime;
		}
		else {
			cooldowntimer = 0;
		}
		if(attacktimer > 0) {
			attacktimer -= Time.fixedDeltaTime;
			Collider[] colliders = Physics.OverlapSphere(transform.TransformPoint(Vector3.right * physics.direction * range), radius);
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
		}
		else {
			isAttacking = false;
			attacktimer = 0;
		}
	}
	
	public void Attack ()
	{
		if(cooldowntimer == 0) {
			attacktimer = attacktime;
			cooldowntimer = cooldown;
			isAttacking = true;
		}
	}
}
