using UnityEngine;
using System.Collections;

public class RandomPlatformGenerator : MonoBehaviour {
	[SerializeField]
	private MovingPlatformBehaviour platform;
	[SerializeField]
	private int maximumAmount = 20;
	
	private float timer = 0;
	private Vector3 cohesion;
	private float cohesionRadius = 10;
	private Collider[] platforms;
	
	void Start () {
		for (int i = 0; i < maximumAmount; i++) {
			var newPlatform = Instantiate<MovingPlatformBehaviour>(platform);
			var x = Random.Range(Game.current.minX, Game.current.maxX);
			var y = Random.Range(Game.current.minY, Game.current.maxY);
			newPlatform.transform.position = new Vector3(x, y, 0);
			newPlatform.transform.localScale = new Vector3(Random.Range(3, 10), 1, 0);
			newPlatform.movement = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), 0);
		}
	}
}
