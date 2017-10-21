using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class AI : MonoBehaviour
{
    public enum MonType
    {
        Boss,
        Normal,
        Trap,
    }

    public MonType montype = MonType.Normal;
    public bool ISInfinityBoss = false;
    public Image HPBossImg;

    public Rigidbody2D MyRidbody;
    public Animator Anim;
    protected Transform[] ModelChildObj;
    protected float friction = 3;

    public bool iSNoneAttackTypeMonster = false;

    public bool IsSkill1Start = false;
    public bool IsLongAtkSensorStay = false;
    public bool ISMASICRECALLMOSNTER = false;

    public bool IschageState = false;

    public Ability m_ability;

    void Awake()  // 여기에 코루틴을 넣게 되면 active가 false가 되면 다시 꺼지니깐 여기에 넣을면 안됨.
    {
        Initialize();

        if(ModelChildObj != null)
        m_Model_Sprite = ModelChildObj[0].GetComponentsInChildren<SpriteRenderer>();


        MentPrefab = Resources.Load("Texteffect/Img_Ment") as GameObject;

        m_ability = new Ability(0, "", 0, 100, 10, 5, 5, 5, 1, 0, 0, 0, 0, 0, 0,"");
        

        Debug.Log("State" + m_ability.Id+":"+ m_ability.Movespeed);
    }

    void OnEnable()
    {
        if(!ISMASICRECALLMOSNTER)
        StartCoroutine(StartMonUpdate());
        else
        StartCoroutine(MonsterUpdate());
    }

    public IEnumerator StartMonUpdate()
    {
  
       yield return StartCoroutine(RespwanFoward());

     
       yield return  StartCoroutine(MonsterUpdate());
    }


    IEnumerator RespwanFoward()
    {
        float tic = 0;
   
        while (tic < 1)
        {
            tic += Time.deltaTime;
            Vector2 ForwardVector = this.transform.up * 800 * m_ability.Movespeed * Time.deltaTime;
            if(MyRidbody!=null)
            MyRidbody.AddForce(ForwardVector);

            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator MonsterUpdate()
    {
        while (true)
        {
            if (IsMonsterStart)
            {


                if (SceneMgr.scenemgr.IsStopScene)
                {
                    DestoryMentgameobj();
                    yield return new WaitForSeconds(0.01f);
                    continue;
                }

               // Debug.Log("업데이트");
                FSMUpdate();

             


              
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    public List<string> mentList = new List<string>();

    public void MentInit(string name)  // 해당 몬스터의 멘트만 따로 뽑아 준다. 
    {
        //for (int i = 0; i < GameMgr.GM.Mentdata.Count; i++)
        //{
        //    if (name == GameMgr.GM.Mentdata[i]["enemy"].ToString())
        //    {
        //        mentList.Add(GameMgr.GM.Mentdata[i]["ment"].ToString());
        //    }
        //}
    }
    public GameObject MentPrefab;
    public RectTransform Mentgameobj;

    public void CreateMent(int id)  // 몬스터의 종류에 이름을 쓴다. id는 0~ 9 상태에 따른 
    {

      //  string tmpString = "";
    
      //  tmpString = mentList[id];

      //  GameObject Tmpobj;
      //  if (Mentgameobj == null)
      //  {
      //      //Tmpobj = Instantiate(MentPrefab, MainCanvas.mainCanvas.MentPanel.transform);

      //      Mentgameobj = Tmpobj.GetComponent<RectTransform>();
    
      //      Mentgameobj.name = "MentObj";
        
      //  }
          

      ////  Debug.Log("멘트 만들어짐:" + tmpString.Length);
      //  Mentgameobj.transform.Find("Text_Ment").GetComponent<Text>().text = tmpString;
      //  Mentgameobj.sizeDelta = new Vector2(28 * tmpString.Length,36);
      

    }

    public void DestoryMentgameobj()
    {
        if (Mentgameobj != null)
            Destroy(Mentgameobj.gameObject);
    }

    protected virtual void Initialize() { }
    protected virtual void FSMUpdate() { }
    //  protected virtual void FSMFixedUpdate() { }

    public void StartMonster()
    {
        IsMonsterStart = true;

    }

    protected bool IsMonsterStart = true; // 몬스터가 플레이되는지 멈추는지 
    public void StopMonster()
    {
        IsMonsterStart = false;
        MyRidbody.velocity = new Vector2(0, 0);
        DestoryMentgameobj();
    }


    public void DestoryModel()
    {
        DestoryMentgameobj();
        this.transform.localScale = new Vector2(1, 1);
        for (int j = 0; j < m_Model_Sprite.Length; j++)
        {
            m_Model_Sprite[j].color = new Color(1.0f, 1.0f, 1.0f, 1);
        }

        for (int i = 0; i < m_Model_Sprite.Length; i++)
        {
            m_Model_Sprite[i].gameObject.transform.SetParent(null);
            Rigidbody2D MonRi = m_Model_Sprite[i].gameObject.AddComponent<Rigidbody2D>();
            BoxCollider2D MonBox = m_Model_Sprite[i].gameObject.AddComponent<BoxCollider2D>();
        
            MonRi.gravityScale = 0;
            MonRi.drag = 5;
            MonRi.constraints = RigidbodyConstraints2D.FreezeRotation;
            m_Model_Sprite[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
            MonRi.AddForceAtPosition(Random.insideUnitCircle * 100, ModelChildObj[i].transform.position, ForceMode2D.Impulse);

            MonBox.gameObject.layer = 11;

        }


        //for (int i = 0; i < ModelChildObj.Length; i++)
        //{

        //    // Debug.Log(ModelChildObj[i]);
        //    if (ModelChildObj[i].GetComponent<SpriteRenderer>() != null)
        //    {
        //        ModelChildObj[i].SetParent(null);
        //        Rigidbody2D MonRi = ModelChildObj[i].gameObject.AddComponent<Rigidbody2D>();
        //        BoxCollider2D MonBox = ModelChildObj[i].gameObject.AddComponent<BoxCollider2D>();
        //        ModelChildObj[i].gameObject.AddComponent<BodyDestroyer>();
        //        MonRi.gravityScale = 0;
        //        MonRi.drag = 5;
        //        MonRi.constraints = RigidbodyConstraints2D.FreezeRotation;
        //        ModelChildObj[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
        //        MonRi.AddForceAtPosition(Random.insideUnitCircle * 100, ModelChildObj[i].transform.position, ForceMode2D.Impulse);
           
        //        MonBox.gameObject.layer = 11;

        //    }


        //}


    }

    public void GetDamagedModelChage()
    {

        StartCoroutine(GetDamagedModelChageCo());

    }

    IEnumerator GetDamagedModelChageCo()
    {
        this.transform.localScale = new Vector2(1.3f, 1.3f);

        for (int j = 0; j < m_Model_Sprite.Length; j++)
        {
            m_Model_Sprite[j].color = new Color(1f, 0.3f, 0.3f, 1);
        }



        yield return new WaitForSeconds(0.1f);
        for (int j = 0; j < m_Model_Sprite.Length; j++)
        {
            m_Model_Sprite[j].color = new Color(1.0f, 1.0f, 1.0f, 1);
        }
        this.transform.localScale = new Vector2(1, 1);
    }


    public virtual void AttackStartEvent() { }
    public virtual void AttackEndEvent() { }


    public virtual void Skill1StartEvent() { }
    public virtual void Skill1EndEvent() { }
    public virtual void Skill2StartEvent() { }
    public virtual void Skill2EndEvent() { }

    public virtual void FootStep() { }

    public virtual void LongAtkSensorStayEvent() { }
    public virtual void LongAtkSensorExitEvent() { }


    public virtual void BodySensorEvent() { }

    public virtual void GetDamaged(float Damage, Vector2 Dir,float PushPower) { }

    public SpriteRenderer[] m_Model_Sprite;
    public bool IsSuperAmour;

    public void SuperAmour(float ticTime)
    {
        StartCoroutine(SuperAmourTime(ticTime));

    }
    IEnumerator SuperAmourTime(float ticTime)
    {

        float tic = 0;
        float a = 0;
        float i = 0;
        while (true)
        {

            tic += Time.deltaTime;

            i += 0.1f * 2;
            a = Mathf.Sin(i);


            for (int j = 0; j < m_Model_Sprite.Length; j++)
            {
                m_Model_Sprite[j].color = new Color(1.0f, 1.0f, 1.0f, Mathf.Abs(a));
            }


            if (tic > ticTime)  // 1초에 한번씩 실행. 
            {
                break;
            }

            yield return new WaitForSeconds(0.001f);
        }


        for (int j = 0; j < m_Model_Sprite.Length; j++)
        {
            m_Model_Sprite[j].color = new Color(1.0f, 1.0f, 1.0f, 1);
        }
        this.gameObject.layer = 9;
    }

   // public bool IsOneAtk = false;  // 공격이 한번만 들어오게 한다. 


 

    

}
