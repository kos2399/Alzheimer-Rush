using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    private Rigidbody Myrigid;
	// Use this for initialization
	void Start () {

        Myrigid = this.GetComponent<Rigidbody>();
        Myrigid.velocity = new Vector3(0, 0,0);
        Myrigid.AddForce(this.transform.forward* 300 );
        StartCoroutine(UpdateCo());
    
    }

     void OnTriggerEnter(Collider obj)
     {
        Debug.Log("ㅇㅇㅇ22"+ obj.name);
        Destroy(this.gameObject);
     }

     IEnumerator UpdateCo()
     {

        yield return new WaitForSeconds(3f);
        Debug.Log("파이어볼파괴");
        Destroy(this.gameObject);


    }
}
