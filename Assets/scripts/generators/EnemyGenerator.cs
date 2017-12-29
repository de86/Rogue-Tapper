using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Room Generator calls enemyGenerator if its a mob room
// Room Generator creates instance of enemyGenerator with Area type
// Enemy Generator grabs all enemies of that type from the list
// For now... Randomly generates mob form that list and returns it
// Layer given a seed generates a mob. This will allow us to proc gen areas

public class EnemyGenerator : MonoBehaviour {

	public  GameObject enemyPrefab;

	private Dictionary<string, MobData>.KeyCollection availableEnemyTypes;
	private SystemManager gameManager;

	void Awake () {}

	void Start () {
		gameManager 		= GetComponent<SystemManager>();
		availableEnemyTypes = gameManager.db.mobs.Keys;
	}

	public Transform generateEnemy () {
		if (Config.isDebug) Debug.Log("Generating Enemy...");

		GameObject enemyGO = MonoBehaviour.Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity);
		Enemy      enemy   = enemyGO.GetComponent<Enemy>();

		MobData mobData;
		gameManager.db.mobs.TryGetValue("imp", out mobData);

		enemy.SetStats(mobData);

		if (Config.isDebug) {
			Debug.Log("Generating Enemy...");
			Debug.Log(enemy.toString());
		}

		return enemyGO.GetComponent<Transform>();;
	}
}
