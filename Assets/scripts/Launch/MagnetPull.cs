using UnityEngine;
using System.Collections;

public class MagnetPull : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        Vector3 directionTowards = transform.parent.position - other.transform.root.position;
        float distance = directionTowards.magnitude;
        other.transform.root.rigidbody.AddForce((directionTowards/distance) * 10);
    }
}