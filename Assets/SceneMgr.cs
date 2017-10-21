using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr : MonoBehaviour {

    public static SceneMgr scenemgr;

    public bool IsStopScene = true;   // 씬 일시정지.
     
    // Use this for initialization
    void Awake () {
        scenemgr = this;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
