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
	[SerializeField]
	private SpriteRenderer monster;
	private Color colorMonster;[SerializeField]
	private SpriteRenderer fog;
	private Color colorFog;
	
	private bool ended, fogAppeared, monsterAppeared = false;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		colorMonster = monster.color;
		monster.color = Color.clear;
		colorFog = fog.color;
		fog.color = Color.clear;
	}

	void FogAppear ()
	{
		var multiply = 0.5f;
		var newY = 3.03f;
		var pos = camerabehaviour.transform.position;
		pos.y = Mathf.Lerp (pos.y, newY, multiply * Time.fixedDeltaTime);
		fog.color = Color.Lerp (fog.color, colorFog, multiply * Time.fixedDeltaTime);
		camerabehaviour.transform.position = pos;
		if(newY - pos.y < 0.1f) {
			if(!fogAppeared) timer = 7f;
			fogAppeared = true;
		}
	}

	void MonsterAppear ()
	{
		var multiply = 0.3f;
		monster.color = Color.Lerp (monster.color, colorMonster, multiply * Time.fixedDeltaTime);
		if(!monsterAppeared) timer -= Time.fixedDeltaTime;
		if(timer < 0) {
			monsterAppeared = true;
		}
	}

	private float titleTimer = 0;

	void TitleAppear ()
	{
		var multiply = 0.003f;
		var pos = camerabehaviour.transform.position;
		var pos2 = title.transform.position;
		titleTimer += Time.fixedDeltaTime * multiply;
		pos.x = Mathf.Lerp (pos.x, pos2.x, titleTimer);
		pos.y = Mathf.Lerp (pos.y, pos2.y, titleTimer);
		camerabehaviour.transform.position = pos;
		if (pos2.y - pos.y < 2f) {
			if (Input.anyKey) {
				Menu.current.LoadLevel ("MainMenu");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(camerabehaviour.right) {
			noTurningBack.enabled = true;
			camerabehaviour.followPlayer = false;
			ended = true;
		}
		if(ended) {
			FogAppear ();
			
			if(fogAppeared) {
				MonsterAppear ();
				if(monsterAppeared) {
					TitleAppear ();
				}
			}
			
		}
	}
}
