
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemGrower : MonoBehaviour
{

    public GameObject stem;

    // Use this for initialization
    void Start()
    {
        // Locate a stem
        stem = GameObject.Find("Stem");
        stem.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Connect True values to arrow keys
        bool growVertical = Input.GetKey("up");
        bool resetVertical = Input.GetKey("down");

        // If True for grow
        if (growVertical)
        {
            // Check tags to see if object can grow
            if (gameObject.CompareTag("Growable"))
            {
                // Grow in unit jumps
                stem.gameObject.transform.localScale += new Vector3(0, 1, 0);
            }
        }

        // If True for reset
        if (resetVertical)
        {
            // Reset object to 1,1,1
            stem.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

}