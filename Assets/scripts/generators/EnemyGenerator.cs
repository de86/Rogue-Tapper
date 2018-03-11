using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Room Generator calls enemyGenerator if its a mob room
// Room Generator creates instance of enemyGenerator with Area type
// Enemy Generator grabs all enemies of that type from the list
// For now... Randomly generates mob form that list and returns it
// Layer given a seed generates a mob. This will allow us to proc gen areas

public class EnemyGenerator : MonoBehaviour {

	public GameObject slimePrefab,
			              impPrefab,
			              yetiPrefab;

	private Dictionary<int, SimpleMob>.KeyCollection availableEnemyTypes;
	private SystemManager                            gameManager;

	void Start () {
		gameManager         = GetComponent<SystemManager>();
		availableEnemyTypes = gameManager.DB.mobs.Keys;
	}

	public Transform generateEnemy () {
		if (Config.isDebug) Debug.Log("Generating Enemy...");

		int	enemyTypeId;		

		GameObject enemyPrefab     = ChooseEnemyType(out enemyTypeId);
		GameObject enemyGameObject = MonoBehaviour.Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity);
		Enemy      enemy           = enemyGameObject.GetComponent<Enemy>();

		SimpleMob mobData;
		gameManager.DB.mobs.TryGetValue(enemyTypeId, out mobData);

		enemy.SetStats(mobData);

		if (Config.isDebug) {
			Debug.Log("Generating Enemy...");
			Debug.Log(enemy.toString());
		};

		return enemyGameObject.GetComponent<Transform>();
	}

	public GameObject ChooseEnemyType (out int enemyTypeId) {
		enemyTypeId = (int)System.Math.Floor(Random.Range(0f, 3f));

    GameObject enemyPrefab;

		switch (enemyTypeId) {
			case (int)EnemyTypes.SLIME:
				return slimePrefab;

			case (int)EnemyTypes.IMP:
				return impPrefab;

			case (int)EnemyTypes.YETI:
				return yetiPrefab;

			default:
				Debug.LogWarning("Enemy ID of " + enemyTypeId + " does not exist. Returning Slime instead.");
				return slimePrefab;
		}
	}
}
