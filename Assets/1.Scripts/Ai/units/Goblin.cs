using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Goblin : MonsterFSM {


    
    //  public PatrolState patrol;
    attackState Attack;
    chasingState Chasing;
    hittedState hitted;
    EscapeState escape;

    private GameMgr GM;
    private Image HPImg;
    private GameObject EnemyCanvas;

    private Goblin MyGoblin;


    public Transform TargetTrans; 


    protected override void Initialize()
    {
        MyGoblin = this;
        GM = GameMgr.GM;

       // CurHP = HP;
  
        EnemyCanvas = this.transform.Find("EnemyCanvas").gameObject;
        HPImg = EnemyCanvas.transform.Find("ImgHp").Find("Image").GetComponent<Image>();
        MyRidbody = this.GetComponent<Rigidbody2D>();
     
        MyRidbody.drag = friction;
        Anim = this.transform.Find("Model").Find("model").GetComponent<Animator>();
        ModelChildObj = this.transform.Find("Model").GetComponentsInChildren<Transform>();
        EnemyCanvas.SetActive(false);

        ConstructFSM();
     //   InitBlood();
        MentInit("anotherorc");
    }

    //Update each frame
    //protected override void FSMUpdate()
    //{

    //}

    protected override void FSMUpdate()
    {
        if (TargetTrans == null)
            return;

        CurrentState.Reason(TargetTrans.transform, transform);
        CurrentState.Act(TargetTrans.transform, transform);
        EnemyCanvas.transform.rotation = Quaternion.identity;

        if (!EnemyCanvas.activeSelf)
            EnemyCanvas.SetActive(true);
        //  Debug.Log(HPImg.transform.rotation);

        ////////////////////
        //   MentState   //
        //////////////////

        if (!IschageState)
        {
            ShowMent();
            IschageState = true;
        }


        //if (Mentgameobj != null)
        //{

        //    Vector2 tmpPos = new Vector2(this.transform.position.x, this.transform.position.y + 5);

        //    Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(tmpPos);
        //    Vector2 WorldObject_ScreenPosition = new Vector2(
        //    ((ViewportPosition.x * In.mainCanvas.MainRect.sizeDelta.x) - (MainCanvas.mainCanvas.MainRect.sizeDelta.x * 0.5f)),
        //    ((ViewportPosition.y * MainCanvas.mainCanvas.MainRect.sizeDelta.y) - (MainCanvas.mainCanvas.MainRect.sizeDelta.y * 0.5f)));


        //    Mentgameobj.anchoredPosition = WorldObject_ScreenPosition;
        //}


    }

    void ShowMent()
    {
        int tmpRand;
        switch (currentStateID)
        {
            case FSMStateID.Chasing:  // 0~5
                tmpRand = Random.Range(0, 6);
                CreateMent(tmpRand);
                break;
            case FSMStateID.Attacking://6 ~ 12
                tmpRand = Random.Range(6, 13);
                CreateMent(tmpRand);
                break;
            case FSMStateID.Escape:  //13 ~9
                tmpRand = Random.Range(13, 19);
                CreateMent(tmpRand);
                break;
        }


    }



    public void SetTransition(Transition t)
    {

        PerformTransition(t);
    }

    private void ConstructFSM()
    {
        //Get the list of points
        //  pointList = GameObject.Find("WanderPoint");


        Chasing = new chasingState(MyGoblin);
        Chasing.AddTransition(Transition.LookEnemy, FSMStateID.Chasing);
        Chasing.AddTransition(Transition.ReachAttackTime, FSMStateID.Attacking);
        Chasing.AddTransition(Transition.hitted, FSMStateID.hitted);
        Chasing.AddTransition(Transition.Escape, FSMStateID.Escape);

        Attack = new attackState(MyGoblin);
        Attack.AddTransition(Transition.LookEnemy, FSMStateID.Chasing);
        Attack.AddTransition(Transition.ReachAttackTime, FSMStateID.Attacking);
        Attack.AddTransition(Transition.hitted, FSMStateID.hitted);
        Attack.AddTransition(Transition.Escape, FSMStateID.Escape);

        hitted = new hittedState(MyGoblin);
        hitted.AddTransition(Transition.LookEnemy, FSMStateID.Chasing);
        hitted.AddTransition(Transition.ReachAttackTime, FSMStateID.Attacking);
        hitted.AddTransition(Transition.hitted, FSMStateID.hitted);
        hitted.AddTransition(Transition.Escape, FSMStateID.Escape);


        escape = new EscapeState(MyGoblin);
        escape.AddTransition(Transition.LookEnemy, FSMStateID.Chasing);
        escape.AddTransition(Transition.ReachAttackTime, FSMStateID.Attacking);
        escape.AddTransition(Transition.hitted, FSMStateID.hitted);
        escape.AddTransition(Transition.Escape, FSMStateID.Escape);




        AddFSMState(Chasing);
        AddFSMState(Attack);
        AddFSMState(hitted);
        AddFSMState(escape);
    }


    //미리 피를 만들어 준다.


  


    public override void GetDamaged(float Damage, Vector2 Dir, float PushPower)
    {
       
        

        MyRidbody.AddForce(Dir * PushPower);

        PerformTransition(Transition.hitted);

       // CurHP -= Damage;
       
        //HPImg.fillAmount = CurHP / HP;
        //AudioSource.PlayClipAtPoint(GameMgr.GM.Clip_MonHitted, Camera.main.transform.position, GameMgr.GM.FXSoundVolume);
        GetDamagedModelChage();

        //   Debug.Log("블레t::"+ CreateBloodIE.MoveNext());
        //if (!IsBlooding)
        //{
        //    StartCoroutine(CreateBlood());
        //    //  Debug.Log("블레싱시작");
        //}

        //if (CurHP <= 0)
        //{
        //    ScenMgr.scenMgr.DieEnemy(this.transform.gameObject, Award, Givehonor, Giveexp);
        //    CreateOrgans();
        //    //GameObject.Destroy(this.transform.gameObject);
 
        //}

    }

}
