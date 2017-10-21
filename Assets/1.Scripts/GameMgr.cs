using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    public static GameMgr GM;

    //
    int gold;


	// Use this for initialization
	void Awake () {

        Screen.SetResolution(1280, 800, true);

        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
            //dddddd
        }



    }
	

}
