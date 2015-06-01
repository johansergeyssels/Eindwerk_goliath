using UnityEngine;
using System.Collections;

public class OnCollisionStop3 : MonoBehaviour
{

	void OnCollisionEnter (Collision collision)
	{

		GetComponent<Rigidbody>().isKinematic = true;
		GameObject bob = GameObject.Find ("MainGuy");
		Vector3 endPosition = GameObject.Find ("MainGuy/GunStart").GetComponent<ShootGrapple> ().test.transform.position;

		bob.transform.LookAt (endPosition);
		bob.GetComponent<Rigidbody>().AddForce(bob.transform.forward * 500);
		bob.transform.rotation = Quaternion.identity;
		StartCoroutine(DestroyObj(1.5f));
	}
	
	IEnumerator DestroyObj (float time)
	{
		
		yield return new WaitForSeconds (time);
		Destroy (gameObject);
	}
	
	void Update ()
	{

		GameObject bob = GameObject.Find ("MainGuy");
		if (this.transform.position.y <= bob.transform.position.y) {
			Destroy (gameObject);
		}
		if (this.transform.position.y > bob.transform.position.y + 10) {
			Destroy (gameObject);
		}
	
	}
}
