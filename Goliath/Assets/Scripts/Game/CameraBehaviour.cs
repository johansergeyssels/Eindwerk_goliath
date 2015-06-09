using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	private float maxX, minX, maxY, minY;
	
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
		if(maxX > Game.current.player.transform.position.x &&
		   minX < Game.current.player.transform.position.x) {
			movement.x = Game.current.player.transform.position.x;
		}
		if(maxY > Game.current.player.transform.position.y &&
		   minY < Game.current.player.transform.position.y) {
			movement.y = Game.current.player.transform.position.y;  
		}
		transform.position = movement;
	}
}
