using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBParsing : MonoBehaviour {

    public static DBParsing DB;

    public enum Language
    {
        Kr,
        Eng
    }



    public Language language; 



    public List<Dictionary<string, object>> SoldierDb = new List<Dictionary<string, object>>();

    // Use this for initialization
    void Awake () {
        DB = this;
        SoldierDb = CSVReader.Read("DB/Soldier_db");



   }
	
	
}
