using UnityEngine;
using System.Collections;

public class TargetBox : Destructable {
	private MovingPlatformBehaviour moveableGround;

	void FixedUpdate() {
		moveableGround = null;
		Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.down, 0.3f);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject){
				moveableGround = colliders[i].GetComponent<MovingPlatformBehaviour>();
				//anders kan de kubus zelf als collider worden beschouwd.
			}
		}
		
		if(moveableGround){
			transform.position += moveableGround.movement;
		}
		
		var pos = transform.position;
		if(pos.x < Game.current.minX || 
			pos.x > Game.current.maxX ||
			pos.y < Game.current.minY ||
			pos.y > Game.current.maxY) {
			RandomPlatformGenerator.current.ReplaceTarget(this);
		}
	}
	
	protected override void HandleDestroy ()
	{
		RandomPlatformGenerator.current.Score++;
		RandomPlatformGenerator.current.ReplaceTarget(this);
		destroyed = false;
	}
}
