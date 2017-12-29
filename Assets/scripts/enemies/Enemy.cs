using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Sprite spr_attack, spr_hit, spr_idle;
	
	public enum state {
		AGGRO,
		ATTACKING,
		CHARGING,
		IDLE,
		PAUSED
	}
	public state  		 currentState;
	public GameObject     obj_player;
	public PlayerManager  player;
	public SpriteRenderer sr;

	public int    		 attack, defense, hp, xp;
	public float   	   	 attackTime;
	public string 		 enemyName;


	/*************************
	** Public Methods
	*************************/
	public void SetStats (MobData mobData) {
		attack 		= mobData.attack;
		attackTime  = mobData.attackTime;
		defense 	= mobData.defense;
		enemyName   = mobData.name;
		hp 			= mobData.hp;
		xp 			= mobData.maxXP;
	}

	/*************************
	** Monobehaviours
	*************************/

	public void Awake () {
		GameEventManager.playerDied += playerDied;
		GameEventManager.gamePaused += paused;
	}

	public void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
		sr 	   = gameObject.GetComponent<SpriteRenderer>();
	}

	public void Update () {
		if (Input.GetMouseButtonDown(0)) {
			receiveHit();
		}

		switch (currentState) {
			case state.PAUSED:
				break;

			case state.AGGRO:
				StartCoroutine(startAttack(attackTime));
				break;

			default:
				break;
		}
	}



	/*************************
	** Event Handlers
	*************************/

	public void playerDied () {
		Debug.Log("Slime says: OOOHHHH YEAHHH, I Killed you bitch!");
	}

	public  void paused () {
		currentState = state.PAUSED;
	}



	/*************************
	** Inernals
	*************************/

	public string toString () {
		// TODO: Convert to string builder...
		return
			"--------------------------\n" +
			"Name: "    + enemyName + "\n" +
			"Attack: "  + attack    + "\n" +
			"Defense: " + defense   + "\n" +
			"HP: "      + hp        + "\n" +
			"--------------------------";
	}

	public void receiveHit() {
		StartCoroutine(setHitSprite());
		hp -= 1;

		Debug.Log("HP: " + hp);

		if (hp <= 0) killEnemy();
	}

	public void killEnemy () {
		GameEventManager.EnemyKilled(GetInstanceID());
		Destroy(gameObject);
	}

	IEnumerator startAttack (float countdownTime) {
		currentState = state.CHARGING;

		yield return new WaitForSeconds(countdownTime);

		currentState = state.ATTACKING;
		sr.sprite    = spr_attack;

		player.receiveHit(attack);

		yield return new WaitForSeconds(0.2f);

		if (currentState != state.PAUSED) {
			currentState = state.AGGRO;
		}
		sr.sprite = spr_idle;
	}

	IEnumerator setHitSprite () {
		sr.sprite = spr_hit;

		yield return new WaitForSeconds(0.2f);

		sr.sprite = spr_idle;
	}
}
