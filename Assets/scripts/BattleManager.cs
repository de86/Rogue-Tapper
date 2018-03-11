using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

	enum  BattleStates {
		GENERATING,
		BATTLING,
		PAUSED,
		PLAYERDEAD,
		PLAYERWIN
	}

	private Dictionary<int, Enemy> enemies;
	private EnemyGenerator         enemyGenerator;
	private BattleStates	         battleState;
	private int		                 enemyCount;


	/*************************
	** Monobehaviours
	*************************/
	void Awake () {
		GameEventManager.playerDied  += playerDied;
		GameEventManager.enemyKilled += enemyKilled;
		GameEventManager.startBattle += startBattle;

		battleState = BattleStates.PAUSED;
	}

	void Start () {
		enemyGenerator = gameObject.GetComponent<EnemyGenerator>();
		enemies        = new Dictionary<int, Enemy>();		
	}
	
	
	/*************************
	** Delegate/Event Handlers
	*************************/
	public void playerDied () {
		if (Config.isDebug) Debug.Log("You died");
		pauseGame();
	}

	public void enemyKilled (int id) {
		enemies.Remove(id);

		if (enemies.Count <= 0) {
			playerWin();
		}
	}

	public void startBattle () {
		generateBattle();
		GameEventManager.BattleStarted();
	}


	/*************************
	** Internals
	*************************/
	private void generateBattle () {
		if (Config.isDebug) Debug.Log("Generating Battle...");

		battleState = BattleStates.GENERATING;
		enemyGenerator.generateEnemy();
		battleState = BattleStates.BATTLING;

		if (Config.isDebug) Debug.Log("Battle Generation Complete");
	}

	private void pauseGame () {
		if (Config.isDebug) Debug.Log("Paused");
		battleState = BattleStates.PAUSED;
		GameEventManager.PauseGame();
	}

	private void playerWin () {
		battleState = BattleStates.PLAYERWIN;
		GameEventManager.PlayerWon();
	}
}
