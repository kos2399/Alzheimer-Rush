using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//public class Item
//{



//}
public class LobbyCanvasScript : MonoBehaviour {



    private GameObject LobbyCanvas;

    private GameObject DungeonPanel;
    public GameObject[] Dungeonlist;

    // 용병
    public GameObject Unit1;
    public GameObject Unit2;
    public GameObject Unit3;
    public GameObject Unit4;
    public GameObject Unit5;
    public Text Unit1text;
    public Text Unit2text;
    public Text Unit3text;
    public Text Unit4text;
    public Text Unit5text;
    public Text UnitExplain;
    string[] unit;

    // 상점
    public Text shopText;

    // 스킬
    public Image leftMagic;
    public Image rightMagic;
    public Dropdown selectedLeftMagic;
    public Dropdown selectedrightMagic;
    public GameObject[] leftmagiclist;
    public GameObject[] rightmagiclist;


   // public List<Item> ItemList = new List<Item>();


    public int Head  = -1;
    public int Body  =  0;

    // Use this for initialization
    void Awake()
    {
        


        LobbyCanvas = this.gameObject;
        DungeonPanel = LobbyCanvas.transform.Find("Panel_던전").gameObject;
        Dropdown_Dungeon = DungeonPanel.transform.Find("Dropdown").GetComponent<Dropdown>();
        hiredSoliderPanel = LobbyCanvas.transform.Find("Panel_용병고용소").gameObject;
        InventoryPanel = LobbyCanvas.transform.Find("Panel_인벤토리").gameObject;
        ShopPanel = LobbyCanvas.transform.Find("Panel_상점").gameObject; 
        SkillPanel = LobbyCanvas.transform.Find("Panel_스킬").gameObject;

        unit = new string[6];


    }

    void Start()
    {

        // 용병고용 초기화 초반에 1회 해줌
        Btn_unit_Rematch();

    }
    public void Btn_GameStart()
    {

        AsyncOperation async = SceneManager.LoadSceneAsync("2.Ingame");
        async.allowSceneActivation = true;

    }
    //////////////////////////////
    ////// 던전 패널  ////////////
    ////////////////////////////

    public Dropdown Dropdown_Dungeon;

    public void Btn_DungeonPanel_Open()
    {

        for (int i = 0; i < Dungeonlist.Length; i++)
        {
            Dungeonlist[i].SetActive(false);
        }

        Dungeonlist[0].SetActive(true);


        DungeonPanel.SetActive(true);

    }
    public void Btn_DungeonPanel_Close()
    {
        DungeonPanel.SetActive(false);
    }
    public void Dropdown_ChangeDungeon()
    {
        for (int i = 0; i < Dungeonlist.Length; i++)
        {
            Dungeonlist[i].SetActive(false);
        }
        switch (Dropdown_Dungeon.value)
        {
            case 0:
                Debug.Log("0");
                Dungeonlist[0].SetActive(true);
                break;
            case 1:
                Debug.Log("1");
                Dungeonlist[1].SetActive(true);
                break;
            case 2:
                Debug.Log("2");
                Dungeonlist[2].SetActive(true);
                break;
            case 3:
                Debug.Log("3");
                Dungeonlist[3].SetActive(true);
                break;

        }



    }


    //////////////////////////////
    ////// 용병 고용소 패널  ////////////
    ////////////////////////////

    public GameObject hiredSoliderPanel;

    public void Btn_hiredsoldierPanel_open()
    {
        hiredSoliderPanel.SetActive(true);

    }
    public void Btn_hiredsoldierPanel_close()
    {

        hiredSoliderPanel.SetActive(false);

    }



    //////////////////////////////
    //////shop 패널  ////////////
    ////////////////////////////
    public GameObject ShopPanel;
    public void Btn_shopPanel_open()
    {
        ShopPanel.SetActive(true);

    }
    public void Btn_shopPanel_close()
    {
        ShopPanel.SetActive(false);

    }
    //////////////////////////////
    ////// Inventory 패널  ////////////
    ////////////////////////////
    public GameObject InventoryPanel;
    public void Btn_InventoryPanel_open()
    {
        InventoryPanel.SetActive(true);

    }
    public void Btn_InventoryPanel_close()
    {
        InventoryPanel.SetActive(false);

    }
    //////////////////////////////
    ////// skill 패널  ////////////
    ////////////////////////////
    public GameObject SkillPanel;
    public void Btn_SkillPanel_open()
    {
        SkillPanel.SetActive(true);

    }
    public void Btn_SkillPanel_close()
    {
        SkillPanel.SetActive(false);

    }


    /// <summary>
    ///  상점 구입하려고 터치
    /// </summary>
    /// <param name="i">상점아이템 번호</param>
    public void Btn_shop_item(int i)
    {
       shopText.text = "" +i+ "번 아이템을 구매하려고 터치";
    }

    public void Btn_shop_buy_gem()
    {
        Debug.Log("잼구매 진행");
    }

    /// <summary>
    /// 용병고용에서 추가슬롯을 획득
    /// </summary>
    public void Btn_unit_AddSlot()
    {      

        // 슬롯 4가 안열려있으면
        if (Unit4.activeSelf == false) {
            Unit4.SetActive(true);
            return;
        }

        // 슬롯 4가 열려있고 슬롯 5가 안열려있으면
        if (Unit4.activeSelf == true && Unit5.activeSelf == false)
        {
            Unit5.SetActive(true);
            return;
        }

        // 모두 열려있으면
        if (Unit4.activeSelf == true && Unit5.activeSelf == true)
        {
            return;
        }
    }

    /// <summary>
    /// 용병목록 새로고침하기
    /// </summary>
    public void Btn_unit_Rematch()
    {
        // 용병이 몇마리나 나왔는지
        int limitNum = 3;
        
        int rand = Random.Range(0, limitNum);
        Unit1text.text = DBParsing.DB.SoldierDb[rand]["name"].ToString() + "\n" + DBParsing.DB.SoldierDb[rand]["rank"].ToString();
        unit[1] = DBParsing.DB.SoldierDb[rand]["id"].ToString();

        rand = Random.Range(0, limitNum);
        Unit2text.text = DBParsing.DB.SoldierDb[rand]["name"].ToString() + "\n" + DBParsing.DB.SoldierDb[rand]["rank"].ToString();
        unit[2] = DBParsing.DB.SoldierDb[rand]["id"].ToString();

        rand = Random.Range(0, limitNum);
        Unit3text.text = DBParsing.DB.SoldierDb[rand]["name"].ToString() + "\n" + DBParsing.DB.SoldierDb[rand]["rank"].ToString();
        unit[3] = DBParsing.DB.SoldierDb[rand]["id"].ToString();

        rand = Random.Range(0, limitNum);
        Unit4text.text = DBParsing.DB.SoldierDb[rand]["name"].ToString() + "\n" + DBParsing.DB.SoldierDb[rand]["rank"].ToString();
        unit[4] = DBParsing.DB.SoldierDb[rand]["id"].ToString();

        rand = Random.Range(0, limitNum);
        Unit5text.text = DBParsing.DB.SoldierDb[rand]["name"].ToString() + "\n" + DBParsing.DB.SoldierDb[rand]["rank"].ToString();
        unit[5] = DBParsing.DB.SoldierDb[rand]["id"].ToString();
    }

    /// <summary>
    /// 유닛 선택해서 설명보기
    /// </summary>
    /// <param name="i">몇번째 버튼인지</param>
    public void Btn_unit_select(int i)
    {
        UnitExplain.text = DBParsing.DB.SoldierDb[int.Parse(unit[i])]["explain"].ToString();
    }


    public void Dropdown_magic_left()
    {
        for (int i = 0; i <4; i++)
        {
            leftmagiclist[i].SetActive(false);
        }
        switch (selectedLeftMagic.value)
        {
            case 0:
                Debug.Log("0");
                leftmagiclist[0].SetActive(true);
                break;
            case 1:
                Debug.Log("1");
                leftmagiclist[1].SetActive(true);
                break;
            case 2:
                Debug.Log("2");
                leftmagiclist[2].SetActive(true);
                break;
            case 3:
                Debug.Log("3");
                leftmagiclist[3].SetActive(true);
                break;
        }
    }

    public void Dropdown_magic_right()
    {
        for (int i = 0; i < 4; i++)
        {
            rightmagiclist[i].SetActive(false);
        }
        switch (selectedLeftMagic.value)
        {
            case 0:
                Debug.Log("0");
                rightmagiclist[0].SetActive(true);
                break;
            case 1:
                Debug.Log("1");
                rightmagiclist[1].SetActive(true);
                break;
            case 2:
                Debug.Log("2");
                rightmagiclist[2].SetActive(true);
                break;
            case 3:
                Debug.Log("3");
                rightmagiclist[3].SetActive(true);
                break;
        }
    }
}
