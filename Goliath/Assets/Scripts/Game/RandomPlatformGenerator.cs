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
	[SerializeField]
	private Text highScoreField;
	[SerializeField]
	private Canvas warningSign;
	[SerializeField]
	private Canvas warningSign2;
	[SerializeField]
	private CameraBehaviour camerabehaviour;
	
	public static RandomPlatformGenerator current;
	private MovingPlatformBehaviour[] platforms;

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
			scoreField.text = value.ToString();
			var highscore = PlayerPrefs.GetInt("highscore");
			if(value > highscore) {
				PlayerPrefs.SetInt("highscore", value);
				highscore = value;
			}
			highScoreField.text = highscore.ToString();
		}
	}
	
	void Awake() {
		current = this;
		platforms = new MovingPlatformBehaviour[maximumAmount];	
		var highscore = PlayerPrefs.GetInt("highscore");
		highScoreField.text = highscore.ToString();
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
	
	void FixedUpdate() {
		var warningpos = new Vector3(100, 100, 0);
		var warningpos2 = new Vector3(100, 100, 0);
		if(camerabehaviour.left) warningpos = new Vector3(Game.current.minX + 0.8f, Game.current.player.transform.position.y, -2);
		if(camerabehaviour.right) warningpos = new Vector3(Game.current.maxX - 0.8f, Game.current.player.transform.position.y, -2);
		if(camerabehaviour.up) warningpos2 = new Vector3(Game.current.player.transform.position.x, Game.current.maxY - 1.5f, -2);
		if(camerabehaviour.down) warningpos2 = new Vector3(Game.current.player.transform.position.x, Game.current.minY + 0.5f, -2);
		
		warningSign.transform.position = warningpos;
		warningSign2.transform.position = warningpos2;
	}
}
