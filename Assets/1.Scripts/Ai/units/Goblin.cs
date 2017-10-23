using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Goblin : MonsterFSM {


    
    //  public PatrolState patrol;
    attackState Attack;
    chasingState Chasing;
    hittedState hitted;
    EscapeState escape;

    private GameMgr GM;

  



    private Goblin MyGoblin;





    protected override void Initialize()
    {
        MyGoblin = this;
        GM = GameMgr.GM;

       // CurHP = HP;
  
        MyRidbody = this.GetComponent<Rigidbody2D>();
     
        MyRidbody.drag = friction;
        Anim = this.transform.Find("Model").Find("model").GetComponent<Animator>();
        ModelChildObj = this.transform.Find("Model").GetComponentsInChildren<Transform>();
 

        ConstructFSM();
        MentInit("anotherorc");
    }

 

    protected override void FSMUpdate()
    {
        if (TargetTrans == null)
            return;

        CurrentState.Reason();
        CurrentState.Act();

  


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





        AddFSMState(Chasing);
        AddFSMState(Attack);
        AddFSMState(hitted);
        AddFSMState(escape);
    }


    //미리 피를 만들어 준다.


  


    public override void GetDamaged(float Damage, Vector2 Dir, float PushPower)
    {
       
        

       // MyRidbody.AddForce(Dir * PushPower);

       // PerformTransition(Transition.hitted);

       // GetDamagedModelChage();

  
    }

}
