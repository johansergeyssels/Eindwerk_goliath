using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	private float maxX, minX, maxY, minY;
	[HideInInspector]
	public bool left, right, up, down = false;
	
	void Start () {
		if(Game.current == null) return;
		var orthosize = GetComponent<Camera>().orthographicSize;
		var sizeX = orthosize * (float)Screen.width / (float)Screen.height;
		var sizeY = orthosize;
		maxX = Game.current.maxX - sizeX;
		minX = Game.current.minX + sizeX;
		maxY = Game.current.maxY - sizeY;
		minY = Game.current.minY + sizeY;
	}
	
	// Update is called once per frame
	void Update () {
		if(Game.current == null) return;
		
		var movement = transform.position;
		
		left = minX > Game.current.player.transform.position.x;
		right = maxX < Game.current.player.transform.position.x;
		if(!left && !right) {
			movement.x = Game.current.player.transform.position.x;
		}
		
		up = maxY < Game.current.player.transform.position.y;
		down = minY > Game.current.player.transform.position.y;
		
		if(!up && !down) {
			movement.y = Game.current.player.transform.position.y;  
		}
		transform.position = movement;
	}
}
