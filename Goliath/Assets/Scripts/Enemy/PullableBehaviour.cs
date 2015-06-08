using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PullableBehaviour : MonoBehaviour {
	private Rigidbody rbody;

	void Awake () {
		rbody = GetComponent<Rigidbody>();
		rbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
	}
	
	void Update () {
	
	}

	public virtual void Pull (Vector3 target, float power)
	{
		var pullVector = transform.InverseTransformPoint(target).normalized * power;
		rbody.drag = 0;
		//rbody.AddForce(pullVector);
		rbody.AddRelativeForce(pullVector);
	}
}
