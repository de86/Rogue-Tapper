using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

	public DB db;
	
	// Use this for initialization
	void Awake () {
		db = new DB();
	}
}
