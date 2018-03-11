using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB {
  public Dictionary<int, DataItem> items    = new Dictionary<int, DataItem>();
  public Dictionary<int, SimpleMob> mobs    = new Dictionary<int, SimpleMob>();
  public Dictionary<int, DataItem> weapons  = new Dictionary<int, DataItem>();

  public DB () {
    // Item DB
    // Potions:                    ID, name                      hpRecovery
    items.Add(0, new HealthPotion( 0,  "Tiny Health Potion",     10         ));
    items.Add(1, new HealthPotion( 1,  "Minor Health Potion",    30         ));
    items.Add(2, new HealthPotion( 2,  "Regular Health Potion",  80         ));


    // Mob DB
    // SimpleMobs:             ID, name,    type,             attack, attackTime, defense, hp, minXP, maxXP
    mobs.Add(0, new SimpleMob( 0,  "Slime", EnemyTypes.SLIME, 1,      5f,         3,       5,  4,     6     ));
    mobs.Add(1, new SimpleMob( 1,  "Imp",   EnemyTypes.IMP,   2,      3f,         1,       8,  5,     8     ));
    mobs.Add(2, new SimpleMob( 2,  "Yeti",  EnemyTypes.YETI,  25,     5f,         10,      20, 50,    50    ));


    // Weapon DB
    // Weapons:                ID, name,           attack, durability
    weapons.Add(0, new Weapon( 0,  "Broken Sword", 2,     -1           ));
    weapons.Add(1, new Weapon( 1,  "Rusty Sword",  3,      7           ));
    weapons.Add(2, new Weapon( 2,  "Void Sword",   10,    -10          ));

    Debug.Log(">> New DB Keys:");

    foreach( int key in items.Keys ) {
      Debug.Log(items[key].name);
    }

    foreach( int key in mobs.Keys ) {
      Debug.Log(mobs[key].name);
    }

    foreach( int key in weapons.Keys ) {
      Debug.Log(weapons[key].name);
    }
  }
}
