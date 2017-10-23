using UnityEngine;
using System.Collections;

public class chasingState : FSMState
{

    public AI m_AI;

    public chasingState(AI m_ai)
    {

        stateID = FSMStateID.Chasing;
        m_AI = m_ai;
        //InitStateList();  여기선는 난수를 안쓸꺼니까 
    }


    public override void Reason()
    {
        



    }


    public override void Act()
    {
        if(m_AI ==null)


        m_AI.navMeshAgent.SetDestination(m_AI.TargetTrans.transform.position);

    }



}
