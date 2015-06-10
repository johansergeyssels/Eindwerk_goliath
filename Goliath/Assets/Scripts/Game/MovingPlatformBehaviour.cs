using UnityEngine;
using System.Collections;

public class MovingPlatformBehaviour : MonoBehaviour {
	public Vector3 movement;
	private Collider col;
	[SerializeField]
	private float seperationDistance = 5;
	[SerializeField]
	private float cohesionRadius = 10;
	[SerializeField]
	private float speedMultiplier = 0.1f;
	[SerializeField]
	private Vector3 direction;
	
	void Awake() {
		//InvokeRepeating("CalculateVelocity", 0, 1);
		col = GetComponent<Collider>();
	}
	
	void FixedUpdate()
	{
		var separation = Vector3.zero;
		var platforms = Physics.OverlapSphere(transform.position, cohesionRadius);
		foreach (var platform in platforms)
		{
			if(platform.GetComponent<MovingPlatformBehaviour>()) {
				
				var delta = transform.position - platform.transform.position;
				var distance = delta.magnitude;
				
				if (platform != col && distance < seperationDistance)
				{
					separation += delta;
				}
			}
		}
		
		movement = (separation.normalized * speedMultiplier + direction) * Time.fixedDeltaTime;
		movement = Vector3.Lerp(Vector3.zero, movement, 0.5f);
		transform.position += movement;
		
		var pos = transform.position;
		if(pos.x < Game.current.minX) pos.x = Game.current.maxX;
		if(pos.x > Game.current.maxX) pos.x = Game.current.minX;
		if(pos.y < Game.current.minY) pos.y = Game.current.maxY;
		if(pos.y > Game.current.maxY) pos.y = Game.current.minY;
		
		transform.position = pos;
	}
}
