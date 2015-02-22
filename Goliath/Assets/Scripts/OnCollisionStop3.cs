using UnityEngine;
using System.Collections;

public class OnCollisionStop3 : MonoBehaviour
{
	void OnCollisionEnter (Collision collision)
	{
		rigidbody.isKinematic = true;
		var bob = GameObject.Find ("MainGuy");
		bob.rigidbody.AddForce (0, 250, 250);
		StartCoroutine(DestroyObj(1.5f));
	}
	
	IEnumerator DestroyObj (float time)
	{
		
		yield return new WaitForSeconds (time);
		Destroy (gameObject);
	}
	
	void Update ()
	{
		/**
		var bob = GameObject.Find ("MainGuy");
		if (this.transform.position.y <= bob.transform.position.y) {
			Destroy (gameObject);
		}
		if (this.transform.position.y > bob.transform.position.y + 10) {
			Destroy (gameObject);
		}
		**/
	}
}
