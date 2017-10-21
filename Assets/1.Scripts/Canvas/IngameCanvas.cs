using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCanvas : MonoBehaviour {


    public static IngameCanvas ingamecanvas;

	// Use this for initialization
	void Awake () {
        ingamecanvas = this;



    }

    //public bool B_PanelTouch = false;

    //public void btn_PanelTouch()
    //{

     

    //}


    bool BchangeElement = true;

    // 속성을 바꿔준다. 
    public void changeElement()
    {
     

        BchangeElement = !BchangeElement;
        if (BchangeElement)
            PlayerMgr.player.m_element = PlayerMgr.player.SwapElement[0];
       else
            PlayerMgr.player.m_element = PlayerMgr.player.SwapElement[1];

        PlayerMgr.player.SetElement();


    }

  
    // begin은 flase , end는 true , count -1 안에


    // 누른 손가락이 iD가 뭔지 알아 낸다. 
    // 뗀 손가락 id가 0,0이면 무시 . 아니면 찍어냄.

    public int Id = 0;
    public Vector3 Ingame_TouchPos;
    //public void TouchDisEnable()
    //{
    //    //if (touchMgr.touch.count == 0)
    //    //    return;

    //    Debug.Log("touchMgr.touch.EndPos.Count" + touchMgr.touch.count);
       
       

    //    for (int i = 0; i < touchMgr.touch.count; i++)
    //    {
    //        Debug.Log("touchMgr.touch.Begin_Touch[i]" + touchMgr.touch.Begin_Touch[i]);
    //     //   Debug.Log("touchMgr.touch.End_Touch[i]" + touchMgr.touch.End_Touch[i]);
    //        if (touchMgr.touch.Begin_Touch[i])
    //        {

    //            Ingame_TouchPos = touchMgr.touch.beginPos[i];
    //            PlayerMgr.player.Call_Magic_DefaltBall();
    //        }

    //    }

 
       
     

    //}

}
