using UnityEngine;
using System.Collections;

public class ShootGrapple : MonoBehaviour
{
	public Transform prefabGrapple;
	public int shootForceX = 0;
	public int shootForceY = 0;
	public int shootForceZ = 0;
	
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			Transform InstanceGrapple = Instantiate (prefabGrapple, transform.position, Quaternion.identity) as Transform;
			InstanceGrapple.rigidbody.AddForce (shootForceX, shootForceY, shootForceZ);
		}
	}
}
