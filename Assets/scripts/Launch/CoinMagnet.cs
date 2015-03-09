using UnityEngine;
using System.Collections;

public class CoinMagnet : MonoBehaviour {

	/*void Start()
    {
        GetComponent<CapsuleCollider>().height *= 3;
        GetComponent<CapsuleCollider>().radius *= 3;
    }*/

	void Update () 
    {

	}
    
    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Coin" || coll.tag == "Card")
        {
            coll.collider.transform.position = Vector3.MoveTowards(coll.collider.transform.position, transform.root.position, 10f * Time.deltaTime);//(transform.root.position - coll.transform.position);
            //coll.transform.position = (myDirection.normalized * Time.deltaTime);
        }
    }
}
