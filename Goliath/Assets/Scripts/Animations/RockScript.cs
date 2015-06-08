using UnityEngine;
using System.Collections;

public class RockScript : MonoBehaviour {
	public GameObject rock;
	public Rigidbody rb;
	public AudioSource rockSlide;
	bool collision;
	// Use this for initialization
	void Start () {
		rb = rock.GetComponent<Rigidbody> ();
		rockSlide = rock.GetComponent<AudioSource> ();
		collision = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
				if (collision == true) {
						rb.AddForce (new Vector3 (0, -9.81f, 0));
				}
		}

	void OnTriggerEnter(Collider collider) {
		rb.AddForce(new Vector3(200,-9.81f,0));
		collision = true;
		rock.AddComponent <DeadlyBehaviour>();
		rockSlide.Play();
		Debug.Log ("testentestenetenst");
	}
}
