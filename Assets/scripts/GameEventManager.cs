public static class GameEventManager {

	public delegate void __PlayerDied();
	public static event  __PlayerDied playerDied;

	public delegate void __PlayerWon();
	public static event  __PlayerWon playerWon;

	public delegate void __PauseGame();
	public static event  __PauseGame gamePaused;

	public delegate void __EnemyKilled(int id);
	public static event  __EnemyKilled enemyKilled;

	public delegate void __StartBattle();
	public static event  __StartBattle startBattle;

	public delegate void __BattleStarted();
	public static event  __BattleStarted battleStarted;

	public static void PlayerDied() {
		if (playerDied != null) {
			playerDied();
		}
	}

	public static void PlayerWon() {
		if (playerWon != null) {
			playerWon();
		}
	}

	public static void PauseGame () {
		if (gamePaused != null) {
			gamePaused();
		}
	}

	public static void EnemyKilled (int id) {
		if (enemyKilled != null) {
			enemyKilled(id);
		}
	}

	public static void BattleStarted () {
		if (battleStarted != null) {
			battleStarted();
		}
	}

	public static void StartBattle () {
		if (startBattle != null) {
			startBattle();
		}
	}
}
