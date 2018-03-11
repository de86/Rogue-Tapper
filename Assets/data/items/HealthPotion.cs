public class HealthPotion : DataItem {
 
  public int hpRecovery;

	public HealthPotion ( int ID, string name, int hpRecovery ) : base( ID, name ) {
    this.hpRecovery = hpRecovery;
  }
}
