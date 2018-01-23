/*************************
** TempTables - Hold data before inserting into Dictionary
*************************/
[System.Serializable]
public class dataItemTable {
	public DataItem[] dataItems;
}

[System.Serializable]
public class MobTable {
	public MobData[] dataItems;
}

[System.Serializable]
public class ItemTable {
	public ItemData[] dataItems;
}

[System.Serializable]
public class WeaponTable {
	public WeaponData[] dataItems;
}


/*************************
** Game Object types
*************************/

[System.Serializable]
public class DataItem {
	public int ID;
	public string name;
}

[System.Serializable]
public class MobData : DataItem {
	public int attack,
			   attackTime,
			   defense,
			   hp,
			   minXP,
			   maxXP;
}

[System.Serializable]
public class ItemData : DataItem {
	public string type;
}

[System.Serializable]
public class WeaponData : DataItem {
	public int attack,
			   durability;
}
