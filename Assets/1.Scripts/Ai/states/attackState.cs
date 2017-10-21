using UnityEngine;
using System.Collections;


public class attackState : FSMState 
{
    
    AI MyMon;


    public attackState( AI m_mon)
    {
     
        stateID = FSMStateID.Attacking;
        MyMon = m_mon;
        MyStateName = "Attack";

    //InitStateList();  여기선는 난수를 안쓸꺼니까 
    }

    public override void Reason(Transform player, Transform my)
    {


        float dis = Vector3.Distance(player.position, my.position);
     //   Debug.Log(AttackObj.activeSelf);
        //if (dis > MyMon.AttackDis&& !MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))   //일정 거리 안에 들어가면 공격. 
        //{
        //    my.GetComponent<MonsterFSM>().PerformTransition(Transition.LookEnemy);       
        //}
    }


    public override void Act(Transform player, Transform npc)
    {
        //  MyMon.MyRidbody.velocity = new Vector2(0, 0);
      //  Debug.Log("공격" + MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"));
      //  MyMon.Anim.speed =  MyMon.AtkSpeed;
            if (!MyMon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
             
               MyMon.Anim.Play("Attack");
             
            }

        

    }

}
