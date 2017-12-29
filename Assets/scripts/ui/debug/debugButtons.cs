using UnityEngine;

public class debugButtons : MonoBehaviour {
	public void OnClickSetBattleState () {
		Debug.Log("OnClickSetBattleState");
		GameEventManager.StartBattle();	
	}
}
