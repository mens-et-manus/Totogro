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
        Vector3 cornerOne = (new Vector3((float)(stem.transform.localScale.x*0.75), (float)(stem.transform.localScale.y*0.5), (float)(stem.transform.localScale.z*0.75)));
        transform.position = cornerOne;

        //Debug.Log("HIHIHI");
        // Grow functionality for leaves
        // Connect True values to arrow keys
        bool growLeaf = Input.GetKey("right");
        bool resetLeaf = Input.GetKey("left");

        // If True for grow
        if (growLeaf)
        {
            // Check tags to see if object can grow
            if (gameObject.CompareTag("Growable"))
            {
                // Grow in unit jumps
                leaf.gameObject.transform.localScale += new Vector3(0, 1, 0);
            }
        }

        // If True for reset
        if (resetLeaf)
        {
            // Reset object to 1,1,1
            leaf.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
