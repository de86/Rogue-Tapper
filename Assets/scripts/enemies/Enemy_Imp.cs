using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Imp : Enemy {
	public void setBase (string name, int hp, int attack, int defense) {
		this.attack  = attack;
		this.defense = defense;
		this.hp      = hp;
		attackTime   = 3f;
		currentState = state.AGGRO;
		enemyName    = name;
	}
}
