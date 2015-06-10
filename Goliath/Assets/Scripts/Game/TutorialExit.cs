using UnityEngine;
using System.Collections;

public class TutorialExit : MonoBehaviour {
	[SerializeField]
	private Collider player;
	[SerializeField]
	private Collider noTurningBack;
	[SerializeField]
	private CameraBehaviour camerabehaviour;
	[SerializeField]
	private GameObject title;
	
	private bool ended = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(camerabehaviour.right) {
			noTurningBack.enabled = true;
			camerabehaviour.followPlayer = false;
			ended = true;
		}
		if(ended) {
			var multiply = 0.5f;
			var pos = camerabehaviour.transform.position;
			var pos2 = title.transform.position;
			pos.x = Mathf.Lerp(pos.x, pos2.x, multiply * Time.fixedDeltaTime);
			pos.y = Mathf.Lerp(pos.y, pos2.y, multiply * Time.fixedDeltaTime);
			camerabehaviour.transform.position = pos;
			
			if(pos2.y - pos.y < 0.1f) {
				if(Input.anyKey) {
					Menu.current.LoadLevel("MainMenu");
				}
			}
		}
	}
}
