using UnityEngine;
using System.Collections;

public class LeftRightWorldBound : MonoBehaviour {

    public bool left;
    
	void Awake() //Positions the bound and changes the collider
    {
        if (left)
        {
            transform.position = new Vector3(BoardGameHandler._leftWorldBound, BoardGameHandler._topWorldBound/2 + 1, 0);
        }
        
        else //for right world bound
        {
            transform.position = new Vector3(BoardGameHandler._rightWorldBound, BoardGameHandler._topWorldBound/2 + 1, 0);
        }
        
        gameObject.GetComponent<BoxCollider>().size= new Vector3(30, BoardGameHandler._topWorldBound, 2);
    }
	
	void OnTriggerStay(Collider coll) //pushes them in that direction
    {

        if (left)
        {
            coll.transform.root.rigidbody.AddForce(new Vector3((Mathf.Abs(coll.transform.root.rigidbody.velocity.x) + 1) * coll.transform.root.rigidbody.mass, 0, 0));
        }
        
        else //right
        {
            coll.transform.root.rigidbody.AddForce(new Vector3((Mathf.Abs(coll.transform.root.rigidbody.velocity.x) - 1) * coll.transform.root.rigidbody.mass, 0, 0));


        }
    }
}
