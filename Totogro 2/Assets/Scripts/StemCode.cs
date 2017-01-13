
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemCode: MonoBehaviour
{

    public GameObject stem;
    public Rigidbody leaf;
    
    // Use this for initialization
    void Start()
    {
        // Locate a stem
        stem = GameObject.Find("Stem");
        stem.gameObject.transform.localScale = new Vector3(1, 1, 1);
        MakeLeaf();
    }

    // Update is called once per frame
    void Update()
    {
        // Connect True values to arrow keys
        bool growStem = Input.GetKey("up");
        bool resetStem = Input.GetKey("down");

        // If True for grow
        if (growStem)
        {
            // Check tags to see if object can grow
            if (gameObject.CompareTag("Growable"))
            {
                // Grow in unit jumps
                stem.gameObject.transform.localScale += new Vector3(0, 1, 0);
            }
        }

        // If True for reset
        if (resetStem)
        {
            // Reset object to 1,1,1
            stem.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void MakeLeaf()
    {
        var cornerOne = transform.TransformPoint(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z));
        Rigidbody leafClone = (Rigidbody)Instantiate(leaf, cornerOne, transform.rotation);
    }
}
