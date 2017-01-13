using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafCode: MonoBehaviour {

    public GameObject stem;
    public Rigidbody leaf;

    //void OnTriggerExit(Collider stem)
    //{
    // Destroy everything that leaves the trigger
    //    Destroy(gameObject);
    //}

    void Update ()
    {
        var cornerOne = stem.gameObject.transform.TransformPoint(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z));
        transform.position = cornerOne;
        Debug.Log("HIHIHI");
    }
}
