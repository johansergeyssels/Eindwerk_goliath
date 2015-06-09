using UnityEngine;
using System.Collections;

public class MovingPlatformBehaviour : MonoBehaviour {
	public Vector3 movement;
	
	private Vector3 cohesion;
	private float cohesionRadius = 10;
	private Collider[] platforms;

	void FixedUpdate () {
		transform.position += movement;
	}
	
	void Update()
	{
		cohesion = Vector3.zero;
		platforms = Physics.OverlapSphere(transform.position, cohesionRadius);
		foreach (var platform in platforms)
		{
			cohesion += platform.transform.position;
		}
		cohesion = cohesion / platforms.Length;
		Debug.DrawLine(transform.position, cohesion, Color.magenta);
	}
}
