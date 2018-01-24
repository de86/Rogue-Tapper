using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DB {

	public int recordCount;

	public Dictionary<int, MobData>    mobs    = new Dictionary<int, MobData>();
	public Dictionary<int, ItemData>   items   = new Dictionary<int, ItemData>();
	public Dictionary<int, WeaponData> weapons = new Dictionary<int, WeaponData>();

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
		long processTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

		buildDBFilesArray();

		int count = 0;
		foreach (string file in DB_FILES) {
			if (File.Exists(DB_FILES[count])) {
				populateTable(DB_FILES[count]);
			} else {
				UnityEngine.Debug.LogError("Cannot find file: " + DB_FILES[count]);
			}	

			count++;
		}

		if (Config.isDebug) {
			processTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond - processTime;
			UnityEngine.Debug.Log("Database built:" + recordCount + " entries loaded in " + (processTime) + " miliseconds");
		}
	}

	// Builds array of DB file names
	private void buildDBFilesArray() {
		Debug.Log(Application.dataPath + @"/StreamingAssets/Data");
		DB_FILES = Directory.GetFiles(Application.dataPath + @"/StreamingAssets/Data/", "*.json");
		
		foreach(string file in DB_FILES) {
			Debug.Log(file);
		};
	}

	// Populates a dictionary from a given DB file
	private void populateTable(string fileName) {
		if (Config.isDebug) UnityEngine.Debug.Log("Loading Data from " + fileName);
		string tableAsJson = File.ReadAllText(fileName);

		switch (Path.GetFileName(fileName)) {
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

	private void addDataToTable<ObjectType> (ObjectType[] dataItems, Dictionary<int, ObjectType> db)
	{
		foreach (ObjectType dataItem in dataItems) {
			// cast the cureent dataItem to a DataItem object so we can get
			// at the name value we will use as the key
			DataItem dataItemAsDataItem = dataItem as DataItem;
			db.Add(dataItemAsDataItem.ID, dataItem);
			recordCount++;
		}
	}


	/*************************
	** Debug
	*************************/

	private void viewDBKeys () {
		foreach (int key in mobs.Keys) {
			UnityEngine.Debug.Log(mobs[key].name);
		}

		foreach (int key in items.Keys) {
			UnityEngine.Debug.Log(items[key].name);
		}

		foreach (int key in weapons.Keys) {
			UnityEngine.Debug.Log(weapons[key].name);
		}
	}
}
