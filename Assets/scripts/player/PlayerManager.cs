using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private int hp;


	/*************************
	** Monobehaviours
	*************************/
	void Awake () {
		GameEventManager.playerWon += playerWon;
	}
	
	void Start () {
		hp = 5;
	}
	
	void Update () {
		
	}


	/*************************
	** Delegate/Event Handlers
	*************************/
	public void playerWon () {
		Debug.Log("Victory is mine foul Demon!");
	}


	/*************************
	** Internals
	*************************/
	public void receiveHit (int enemyAttackRating) {
		hp -= enemyAttackRating;
		Debug.Log("player HP: " + hp);

		if (hp <= 0) {
			GameEventManager.PlayerDied();
		};
	}
}
