using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

	public DB DB;
	
	// Use this for initialization
	void Awake () {
	  DB = new DB();
	}
}
