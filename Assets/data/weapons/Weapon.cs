public class Weapon : DataItem {
  public int attack,
             durability;

  public Weapon ( int ID, string name, int attack, int durability ) : base ( ID, name ) {
    this.attack     = attack;
    this.durability = durability;
  }
}
