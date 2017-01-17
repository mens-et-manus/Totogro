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
        Vector3 cornerOne = (new Vector3((float)(gameObject.transform.localScale.x*0.5*0.707), (float)((stem.transform.localScale.y*0.5)+(transform.localScale.x*0.333)), (float)(stem.transform.localPosition.z)));
        transform.position = cornerOne;
        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0,0,45);
        transform.rotation = rot;

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
                gameObject.transform.localScale += new Vector3(0.1f, 0, 0);
            }
        }

        // If True for reset
        if (resetLeaf)
        {
            // Reset object to 1,1,1
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
