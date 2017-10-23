using UnityEngine;
using System.Collections;

public class hittedState : FSMState
{

    public AI m_Mon;

    public hittedState(AI m_mon)
    {

        stateID = FSMStateID.hitted;
        m_Mon = m_mon;
        //InitStateList();  여기선는 난수를 안쓸꺼니까 
    }

    public override void Reason()
    {


    }
    float tic = 0;
    float time = 1;

    public override void Act()
    {
        tic += Time.deltaTime;
        m_Mon.Anim.Play("Walk");
        //Debug.Log("가속도!!" + m_Mon.MyRidbody.velocity.magnitude);

        //if (m_Mon.MyRidbody.velocity.magnitude > 70)
        //{
        //    m_Mon.MyRidbody.velocity = new Vector2(m_Mon.MyRidbody.velocity.x*0.5f, m_Mon.MyRidbody.velocity.y*0.5f);

        //}

        
        if (tic> time)
        {

            int TmpRn = Random.Range(0, 2);
            //float TmpHPPersent = m_Mon.HP * 0.4f;
            //if (m_Mon.CurHP < TmpHPPersent && m_Mon.montype ==AI.MonType.Normal && TmpRn == 0)  // 현재 피가 40% 이하이면 도망  노말 타입 몬스터만
            //{
   
            //    my.GetComponent<MonsterFSM>().PerformTransition(Transition.Escape);
              
            //}
            //else
            //{

            //    my.GetComponent<MonsterFSM>().PerformTransition(Transition.LookEnemy);

            //}

            tic = 0;
        }

    }

}
