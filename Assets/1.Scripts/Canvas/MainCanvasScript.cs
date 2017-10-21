using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainCanvasScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    public void Btn_GotoLobby()
    {

        AsyncOperation async = SceneManager.LoadSceneAsync("1.Lobby");
        async.allowSceneActivation = true;

    }

}
