using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DB {

	public int recordCount;

	public Dictionary<string, MobData>    mobs    = new Dictionary<string, MobData>();
	public Dictionary<string, ItemData>   items   = new Dictionary<string, ItemData>();
	public Dictionary<string, WeaponData> weapons = new Dictionary<string, WeaponData>();

	private const string MOBTABLE_FILENAME    = "mobs.json";
	private const string ITEMTABLE_FILENAME   = "items.json";
	private const string WEAPONTABLE_FILENAME = "weapons.json";

	private string[] DB_FILES;


	/*************************
	** Constructor
	*************************/

	public DB () {
		recordCount = 0;
		initDB();

		if (Config.isDebug) viewDBKeys();
	}


	/*************************
	** Internals
	*************************/
	
	// Grabs all data from our json files and stores them in dictionaries
	private void initDB() {
		long processTime    = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

		buildDBFilesArray();

		int count = 0;
		foreach (string file in DB_FILES) {
			if (File.Exists(Path.Combine(Application.streamingAssetsPath, DB_FILES[count]))) {
				populateTable(DB_FILES[count]);
			} else {
				Debug.LogError("Cannot find file: " + DB_FILES[count]);
			}	

			count++;
		}

		processTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond - processTime;
		if (Config.isDebug) Debug.Log("Database built:" + recordCount + " entries loaded in " + (processTime) + " miliseconds");
	}

	// Used to build arrays as they need to be built after the variable declearations
	private void buildDBFilesArray() {
		DB_FILES  = new string[] {
			MOBTABLE_FILENAME,
			ITEMTABLE_FILENAME,
			WEAPONTABLE_FILENAME
		};
	}

	// Populates a dictionary from a given filename
	private void populateTable(string fileName) {
		if (Config.isDebug) Debug.Log("Loading Data from " + fileName);
		string tableAsJson = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, fileName));

		switch (fileName) {
			case MOBTABLE_FILENAME:
				MobTable mobTable = JsonUtility.FromJson<MobTable>(tableAsJson);
				addDataToTable<MobData> (mobTable.dataItems, mobs);
				break;

			case ITEMTABLE_FILENAME:
				ItemTable itemTable = JsonUtility.FromJson<ItemTable>(tableAsJson);
				addDataToTable<ItemData> (itemTable.dataItems, items);
				break;

			case WEAPONTABLE_FILENAME:
				WeaponTable weaponTable = JsonUtility.FromJson<WeaponTable>(tableAsJson);
				addDataToTable<WeaponData> (weaponTable.dataItems, weapons);
				break;

			default:
				break;
		}
	}

	private void addDataToTable<ObjectType> (ObjectType[] dataItems, Dictionary<string, ObjectType> db)
	{
		foreach (ObjectType dataItem in dataItems) {
			// cast the cureent dataItem to a DataItem object so we can get
			// at the name value we will use as the key
			DataItem dataItemAsDataItem = dataItem as DataItem;
			db.Add(dataItemAsDataItem.name, dataItem);
			recordCount++;
		}
	}


	/*************************
	** Debug
	*************************/

	private void viewDBKeys () {
		foreach (string key in mobs.Keys) {
			Debug.Log(mobs[key].name);
		}

		foreach (string key in items.Keys) {
			Debug.Log(items[key].name);
		}

		foreach (string key in weapons.Keys) {
			Debug.Log(weapons[key].name);
		}
	}
}
