using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

	public Sprite spr_attack, spr_hit, spr_idle;
	
	public EnemyStates    currentState;
	public GameObject     obj_player;
	public PlayerManager  player;
	public SpriteRenderer sr;

	public int    attack, defense, hp, xp, ID;
	public float  attackTime;
	public string enemyName;


	public void SetStats (MobData mobData) {
		attack 	   = mobData.attack;
		attackTime = mobData.attackTime;
		defense	   = mobData.defense;
		enemyName  = mobData.name;
		hp 	   = mobData.hp;
		xp 	   = mobData.maxXP;
	}

	/*************************
	** Event Handlers
	*************************/

	public abstract void PlayerDied ();

	public abstract void Paused ();



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

	public abstract void ReceiveHit();

	public abstract void killEnemy ();

	public virtual IEnumerator startAttack (float countdownTime) {
		currentState = EnemyStates.CHARGING;

		yield return new WaitForSeconds(countdownTime);

		currentState = EnemyStates.ATTACKING;
		sr.sprite    = spr_attack;

		player.receiveHit(attack);

		yield return new WaitForSeconds(0.2f);

		if (currentState != EnemyStates.PAUSED) {
			currentState = EnemyStates.AGGRO;
		}
		sr.sprite = spr_idle;
	}

	public virtual IEnumerator SetHitSprite () {
		sr.sprite = spr_hit;

		yield return new WaitForSeconds(0.2f);

		sr.sprite = spr_idle;
	}
}
