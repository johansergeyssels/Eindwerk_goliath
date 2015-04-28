using UnityEngine;
using System.Collections;

public class ShootGrapple : MonoBehaviour
{
	public Transform prefabGrapple;
	public GameObject prefab;
	public float distance = 0;
	public GameObject test;
	
	void Update () 
	{

		//Debug.Log (test);

		if (Input.GetButtonDown ("Fire1") && test == null) {

			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
			position = Camera.main.ScreenToWorldPoint(position);
			position.z = 0;
			test = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
			test.transform.LookAt(position);    
			Debug.Log(position);    
			test.GetComponent<Rigidbody>().AddForce(test.transform.forward * 100);

		}


	}
}

