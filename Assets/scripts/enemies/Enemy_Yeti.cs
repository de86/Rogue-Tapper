using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Yeti : Enemy {

	void Awake () {
		GameEventManager.playerDied += PlayerDied;
		GameEventManager.gamePaused += Paused;
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
		sr     = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			ReceiveHit();
		}

		switch (currentState) {
			case EnemyStates.PAUSED:
				break;

			case EnemyStates.AGGRO:
				StartCoroutine(startAttack(attackTime));
				break;

			default:
				break;
		}
	}

	public void setBase (string name, int hp, int attack, int defense) {
		this.attack  = attack;
		this.defense = defense;
		this.hp      = hp;
		attackTime   = 3f;
		currentState = EnemyStates.AGGRO;
		enemyName    = name;
	}

	public override void PlayerDied () {
		Debug.Log("Enemy Yeti Killed You");
	}

	public override void Paused () {
		currentState = EnemyStates.PAUSED;
	}

	public override void ReceiveHit() {
		StartCoroutine(SetHitSprite());
		hp -= 1;

		Debug.Log("HP: " + hp);

		if (hp <= 0) killEnemy();
	}

	public override void killEnemy () {
		GameEventManager.EnemyKilled(GetInstanceID());
		Destroy(gameObject);
	}
}
