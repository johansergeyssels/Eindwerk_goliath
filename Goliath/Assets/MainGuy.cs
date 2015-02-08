using UnityEngine;
using System.Collections;

public class MainGuy : MonoBehaviour
{
	public float jumpforce = 0;
	public float speed = 1f;
	public float testVariable;

	private bool air = false;

	void Start ()
	{

	}

	void Update ()
	{
		Vector3 moveVector = new Vector3 (Input.GetAxis ("Horizontal") * speed, 0, 0);
		rigidbody.AddForce (moveVector);
		if (Input.GetButtonDown ("Jump") && !air) {
			rigidbody.AddForce(new Vector3(0, jumpforce, 0));
			air = true;
		}
		Debug.Log (rigidbody.velocity);
	}

	void OnCollisionEnter(Collision col){
		air = false;
	}
}