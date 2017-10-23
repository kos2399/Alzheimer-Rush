using UnityEngine;
using System.Collections;

public class EscapeState : FSMState
{

    public AI m_Mon;

    public EscapeState(AI m_mon)
    {

        stateID = FSMStateID.Escape;
        m_Mon = m_mon;
        //InitStateList();  여기선는 난수를 안쓸꺼니까 
    }

 
    public override void Reason()
    {
       
    
    }
    float tic = 0;
    float time = 2;

    int LookDir;

    float TestId = 0;

    public override void Act()
    {

        m_Mon.Anim.Play("Walk");
      
        tic += Time.deltaTime;
        if (tic > time)
        {
            SwitchDir();
            tic = 0;
            TestId++;
            Debug.Log("TestId::"+ TestId);
            m_Mon.GetComponent<MonsterFSM>().PerformTransition(Transition.LookEnemy);
           
        }


        //float tmpDis = Vector2.Distance(player.transform.position, my.transform.position);

        //if (tmpDis > m_Mon.AttackDis)
        //{


            Quaternion Dir_Qua = Quaternion.identity;
            Dir_Qua.eulerAngles = new Vector3(0, 0, 45 * LookDir);

            m_Mon.transform.rotation = Quaternion.Slerp(m_Mon.transform.rotation, Dir_Qua, Time.deltaTime * 1.5f);



            Vector2 ForwardVector = m_Mon.transform.up * 800 * m_Mon.m_ability.Movespeed*2 * Time.deltaTime;
            m_Mon.MyRidbody.AddForce(ForwardVector);
      //  }

    }

    void SwitchDir()
    {
        int TmpRn = Random.Range(0, 100);
        if (TmpRn > 50)
        {
            LookDir = 1;
         
        }
        else
        {
            LookDir = -1;

        }

    }


}
