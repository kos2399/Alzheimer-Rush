using UnityEngine;
using System.Collections;


public class LongattackState : FSMState 
{
    
    private float ChasingDis;
    AI MyMon;


    public LongattackState( AI m_mon)
    {
     
        stateID = FSMStateID.Attacking;
        MyMon = m_mon;
        MyStateName = "Attack";

    //InitStateList();  여기선는 난수를 안쓸꺼니까 
    }

    public override void Reason(Transform player, Transform my)
    {
        float dis = Vector3.Distance(player.position, my.position);
    
        //if (dis > MyMon.AttackDis && !MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))   //거리가 멀면 추적
        //{
        //    my.GetComponent<MonsterFSM>().PerformTransition(Transition.LookEnemy);
        
        //}

        //if (dis < MyMon.LongTypeMonEscapeDis && !MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))   //거리가 가까우면 도망. 
        //{
        //    my.GetComponent<MonsterFSM>().PerformTransition(Transition.Escape);
         
        //}

    }



    float tic = 0;
 

    public override void Act(Transform player, Transform npc)
    {


      

      //  MyMon.MyRidbody.velocity = new Vector2(0, 0);
       // MyMon.Anim.speed =  MyMon.AtkSpeed;

        Debug.Log("고오옹력");
      //  Vector3 TmpDir = (Player.player.transform.position - MyMon.transform.position).normalized;
        // 그냥 가기 . 


      //  float Angle = Vector3.Angle(TmpDir, MyMon.transform.up);
        //   Debug.Log("Angle:::" + Angle);
        // 그냥 가기 . 
    
       //if (Angle > 5)
       // {
       //     MyMon.transform.up = Vector2.Lerp(MyMon.transform.up, TmpDir, Time.deltaTime*5);
       // }
            //  TmpDir = (Player.player.transform.position - m_Mon.transform.position).normalized;
       

        if (!MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")&& !MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            MyMon.Anim.Play("Idle");
        }


        tic += Time.deltaTime;

        //if (tic > MyMon.AtkDelay)
        //{

        //    if (!MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        //    {
        //        Debug.Log("ㅇㅇㅇㅇㅇ");
        //        MyMon.Anim.Play("Attack");

        //    }

        //    tic = 0;
        //}

     

        

    }

}
