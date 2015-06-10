using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomPlatformGenerator : MonoBehaviour {
	[SerializeField]
	private MovingPlatformBehaviour platform;
	[SerializeField]
	private int maximumAmount = 20;
	[SerializeField]
	private TargetBox targetbox;
	private int score = 0;
	[SerializeField]
	private Text scoreField;
	
	public static RandomPlatformGenerator current;
	private MovingPlatformBehaviour[] platforms;

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
			scoreField.text = value.ToString();
		}
	}
	
	void Awake() {
		current = this;
		platforms = new MovingPlatformBehaviour[maximumAmount];	
	}
	
	void Start () {
		for (int i = 0; i < maximumAmount; i++) {
			var newPlatform = Instantiate<MovingPlatformBehaviour>(platform);
			var x = Random.Range(Game.current.minX, Game.current.maxX);
			var y = Random.Range(Game.current.minY, Game.current.maxY);
			newPlatform.transform.position = new Vector3(x, y, 0);
			newPlatform.transform.localScale = new Vector3(Random.Range(2, 6), 1, 1);
			newPlatform.movement = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), 0);
			platforms[i] = newPlatform;
		}
	}

	public void ReplaceTarget(TargetBox target) {
		var i = Random.Range(0, maximumAmount - 1);
		target.transform.position = platforms[i].transform.position + Vector3.up;
		target.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
