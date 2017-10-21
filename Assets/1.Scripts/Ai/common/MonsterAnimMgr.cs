using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimMgr : MonoBehaviour {

  
    private AI Mymon;

    // Use this for initialization
    void Start()
    {

        Mymon = this.transform.root.GetComponent<AI>();
    
    }
    public void AtkAnimStartEvent()
    {
        // 어택 애니메이션이 시작하는 이벤트

        Mymon.AttackStartEvent();
     //   Debug.Log("공격");
    }
    public void AtkAnimEndEvent()
    {
        // 어택 애니메이션이 끝나하는 이벤트

        Mymon.AttackEndEvent();

     //   Debug.Log("공격햊[");
    }

    public void AtkAnimExitEvent()
    {
     
    }

    public void Skill1StartEvent()
    {

        Mymon.Skill1StartEvent();
    }
    public void Skill1EndEvent()
    {

        Mymon.Skill1EndEvent();
    }
    public void Skill2StartEvent()
    {

        Mymon.Skill2StartEvent();
    }
    public void Skill2EndEvent()
    {

        Mymon.Skill2EndEvent();
    }

    public void FootStep()
    {

        Mymon.FootStep();
    }

}
