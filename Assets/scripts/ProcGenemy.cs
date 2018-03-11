using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGenemy : MonoBehaviour {

    public int health,
               physStrength,
               magicStrength,
               physDefense,
               magicDefense;
               
    public float minAttackCooldown;
    
    public Sprite sprite;

    public ProcGenemy (ProcGenemy procGenemy) {
        this.health = procGenemy.health;
        this.physStrength = procGenemy.physStrength;
        this.magicDefense = procGenemy.magicDefense;
        this.physDefense = procGenemy.physDefense;
        this.magicStrength =  procGenemy.magicStrength;
        this.minAttackCooldown = procGenemy.minAttackCooldown;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
