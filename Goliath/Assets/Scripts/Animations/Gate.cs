using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public GameObject holdBack;
	public GameObject bridge;
	public GameObject koort;
	public AudioSource bridgeSound;
	private bool playsound;
	private bool stopsound;
	Quaternion start = Quaternion.Euler(0, 0, 100);
	Quaternion finish = Quaternion.Euler(0, 0, 180);
	void Start () {

		speed = 0.00125f;
		bridgeSound = bridge.GetComponent<AudioSource> ();
		Debug.Log (bridgeSound);
		playsound = false;
		stopsound = false;



	
	}
	
	// Update is called once per frame
	void Update () {

				if (holdBack == null) {
						Destroy (koort);
						playsound = true;
						Debug.Log ("in Bridge Function");
						
						gameObject.transform.rotation = Quaternion.Slerp (start, finish, speed);
						speed += 0.00125f;

						//transform.rotation = Quaternion.Slerp (start,finish, Time.time * speed);

				}

				if (playsound == true && stopsound == false) {
						bridgeSound.Play ();
						stopsound = true;
				}
		}


}
