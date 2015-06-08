using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public GameObject holdBack;
	public GameObject koort;
	Quaternion start = Quaternion.Euler(0, 0, 100);
	Quaternion finish = Quaternion.Euler(0, 0, 180);
	void Start () {

		speed = 0.2f;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (holdBack == null) {
			Destroy(koort);
			Debug.Log("in Bridge Function");
						
			gameObject.transform.rotation = Quaternion.Slerp (start,finish,speed);
			speed += 0.05f;
			//transform.rotation = Quaternion.Slerp (start,finish, Time.time * speed);

				}
		}


}
