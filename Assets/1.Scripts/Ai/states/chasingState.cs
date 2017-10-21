using UnityEngine;
using System.Collections;

public class chasingState : FSMState
{

    public AI m_Mon;

    public chasingState(AI m_mon)
    {

        stateID = FSMStateID.Chasing;
        m_Mon = m_mon;
        //InitStateList();  여기선는 난수를 안쓸꺼니까 
    }

    float tic = 0;
    float time = 1;
    float dis = 0;
    public override void Reason(Transform player, Transform my)
    {

      
           
         dis = Vector3.Distance(player.position, my.position);
  
        //if (dis <= m_Mon.AttackDis && m_Mon.iSNoneAttackTypeMonster == false)   //일정 거리 안에 들어가면 공격. 
        //{
        
        //    my.GetComponent<MonsterFSM>().PerformTransition(Transition.ReachAttackTime);
        
        //}
 
        //Debug.Log("거리:" + dis);

    }


    bool ISGo = true;

    float ISGoTic1 = 0;
    float ISGoTic2 = 0;
    public override void Act(Transform player, Transform my)
    {


        if (!m_Mon.Anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            m_Mon.Anim.Play("Walk");
        }
     //  Debug.Log("따라가기 상태" + dis);
     //   Vector3 TmpDir = (Player.player.transform.position - m_Mon.transform.position).normalized;
       // float Angle = Vector3.Angle(TmpDir, m_Mon.transform.up);
  
 
 
        // 그냥 가기 . 
        if (ISGo)
        {
            //if (Angle > 10)
            //{
            //      m_Mon.transform.up = Vector2.Lerp(m_Mon.transform.up, TmpDir, Time.deltaTime * 5);
            //}

        }
        else
        {

            if (dis < 20)
            {
                //if (Angle > 10)
                //{
                //     m_Mon.transform.up = Vector2.LerpUnclamped(m_Mon.transform.up, TmpDir, Time.deltaTime * 5);
                
                //}

              
            }
            else
            {
                //if (Angle > 10)
                //{
                //   //  m_Mon.transform.up = Vector2.Lerp(m_Mon.transform.up, TmpDir + (Player.player.transform.up), Time.deltaTime * 5);

                //}

            }
    
         //   Debug.Log("우회함");
        }

     


     tic += Time.deltaTime;

        if (tic > 5)
        {

            float TmpRn = Random.Range(0, 100);
            if (TmpRn < 50)
            {            
                ISGo = !ISGo;
            }

            tic = 0;
        }

    



        float tmpDis = Vector2.Distance(player.transform.position, my.transform.position);





        //if (tmpDis > m_Mon.AttackDis)
        //{
        //    //Debug.Log("dddd");
        //    Vector2 ForwardVector = my.transform.up * 800 * m_Mon.MoveSpeed * Time.deltaTime;
        //    m_Mon.MyRidbody.AddForce(ForwardVector);
        //}


    
     
        //따라가기 
    }



}
