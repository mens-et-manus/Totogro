using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafController : MonoBehaviour
{

    private GameObject stem;
    private Rigidbody leaf;

    //void OnTriggerExit(Collider stem)
    //{
    // Destroy everything that leaves the trigger
    //    Destroy(gameObject);
    //}

    private void Start()
    {
        leaf = GameObject.Find("Leaf").GetComponent<Rigidbody>();
        stem = GameObject.Find("Stem");
        Debug.Log("HIHIHI");
    }

    void Update()
    {
        var cornerOne = stem.gameObject.transform.TransformPoint(new Vector3((float)0.5 * transform.localScale.x, (float)0.5 * transform.localScale.y, (float)0.5 * transform.localScale.z));
        leaf.transform.position = cornerOne;
        Debug.Log("HIHIHI");
    }
}
