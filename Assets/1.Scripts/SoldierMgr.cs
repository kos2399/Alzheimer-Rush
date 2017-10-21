using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierMgr : MonoBehaviour {


    private NavMeshAgent navMeshAgent;
    public GameObject Monster;

    public Transform MyModel;

    private Quaternion OrigineRo;
   	// Use this for initialization
	void Start () {

        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.SetDestination(Monster.transform.position);

      

        StartCoroutine(UpdateCo());

        //  OrigineRo = MyModel.transform.rotation;
        MyModel.transform.SetParent(null);

    }


    IEnumerator UpdateCo()  
    {
        while (true)
        {
             MyModel.transform.position = this.transform.position;
            //MyModel.transform.rotation = OrigineRo;



            navMeshAgent.SetDestination(Monster.transform.position);
       

            yield return new WaitForSeconds(0.01f);
        }
        

    }
}
