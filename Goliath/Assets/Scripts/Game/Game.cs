using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public float minX = -20;
	public float maxX = 20;
	public float minY = -20;
	public float maxY = 20;
	public static Game current;
	[HideInInspector]
	public Player player;
	
	void Awake () {
		current = this;
	}
	
	void Update () {
		
	}
}
