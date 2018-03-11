public class SimpleMob : DataItem {
	public int attack,
			       defense,
			       hp,
			       minXP,
			       maxXP;

  public float attackTime; 

  public EnemyTypes type;

  public SimpleMob ( int ID, string name, EnemyTypes type, int attack, float attackTime, int defense, int hp, int minXP, int maxXP ) : base (ID, name) {
    this.type       = type;
    this.attack     = attack;
    this.attackTime = attackTime;
    this.defense    = defense;
    this.hp         = hp;
    this.minXP      = minXP;
    this.maxXP      = maxXP;
  }

}
