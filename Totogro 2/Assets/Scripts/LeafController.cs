using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{

    private GameObject stem;

    //void OnTriggerExit(Collider stem)
    //{
    // Destroy everything that leaves the trigger
    //    Destroy(gameObject);
    //}

    private void Start()
    {
        stem = GameObject.Find("Stem");
        Debug.Log("HIHIHI");
    }

    void Update()
    {
        Vector3 cornerOne = (new Vector3((float) stem.transform.localScale.x, (float)stem.transform.localScale.y, (float) stem.transform.localScale.z));
        transform.position = cornerOne;
        Debug.Log("HIHIHI");
    }
}
