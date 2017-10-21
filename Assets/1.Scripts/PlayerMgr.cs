using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour {


    public static PlayerMgr player;

    

   
   public enum Element
    {
        Fire,
        Wind,
        Earth,
        Water
    }

    public Element m_element;

    // Use this for initialization
    void Awake () {
        

        player = this;

        m_element = Element.Fire;


        StartCoroutine(UpdateCo());



        SetElement();

    }


    public GameObject FireBallprefab;
    public GameObject WindBallprefab;
    public GameObject EarthBallprefab;
    public GameObject WaterBallprefab;

    public GameObject Magic_DefaltBallPrefab;

    public GameObject Magic_DefaltBallobj;

    public Element[] SwapElement;

    public void SetElement()
    {
        SwapElement = new Element[2];
        SwapElement[0] = Element.Fire;
        SwapElement[1] = Element.Wind;


        switch (m_element)
        {
            case Element.Fire:
                Magic_DefaltBallPrefab = Resources.Load("Magic/fire") as GameObject;
                break;
            case Element.Wind:
                Magic_DefaltBallPrefab = Resources.Load("Magic/wind") as GameObject;
                break;
            case Element.Earth:
                Magic_DefaltBallPrefab = Resources.Load("Magic/earth") as GameObject;
                break;
            case Element.Water:
                Magic_DefaltBallPrefab = Resources.Load("Magic/water") as GameObject;
                break;



        }

    }
    private bool OnceAtack = true;

    //기본 매직 볼을 날린다.
    public void Call_Magic_DefaltBall()
    {
        if (!OnceAtack)
            return;


        Vector3 tmpPos = new Vector3(0, 0, 0);

        tmpPos = touchMgr.touch.EndPos[touchMgr.touch.touch_fingerId];

        if (tmpPos == new Vector3(0, 0, 0))
        {
            return;
        }

            OnceAtack = false;
            StartCoroutine(Maigic_Delay(0.1f));



     

        Vector3 pos = Camera.main.ScreenToWorldPoint(tmpPos);
        pos.y = 0;

  
        Magic_DefaltBallobj = Instantiate(Magic_DefaltBallPrefab);

        Magic_DefaltBallobj.transform.position = this.transform.position;
        Vector3 tmpdir = pos - Magic_DefaltBallobj.transform.position;

        Magic_DefaltBallobj.transform.forward = tmpdir;

  
    }


    IEnumerator Maigic_Delay(float sec)
    {

        yield return new WaitForSeconds(sec);
        OnceAtack = true;


    }

    IEnumerator UpdateCo()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(0.01f);
        }


    }

 


  





}
