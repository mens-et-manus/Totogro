﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemCode: MonoBehaviour
{

    public GameObject stem;
    public GameObject leaf;
    private GameObject LeftHand;
    private GameObject RightHand;
    public float HandDistance=1;
    public float HandSpeed = 1;
    private bool resetStem = false;
    private bool growStem = false;
    private Vector3 LeftHandPosition;
    private Vector3 RightHandPosition;


    // Use this for initialization
    void Awake()
    {
        // Locate a stem
        stem = GameObject.FindGameObjectWithTag("Stem");
        stem.gameObject.transform.localScale = new Vector3(1, 1, 1);
        MakeLeaf();
        LeftHand = GameObject.FindGameObjectWithTag("LeftHandTag");
        RightHand = GameObject.FindGameObjectWithTag("RightHandTag");
        LeftHandPosition = LeftHand.transform.position;
        RightHandPosition = RightHand.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Connect True values to arrow keys
        //growStem = Input.GetKey("up"); //non-kinect
        resetStem = Input.GetKey("down");

        // If True for grow
        if (growStem)
        {
            // Grow in unit jumps
            stem.gameObject.transform.localScale += new Vector3(0, 1, 0);
        }

        // If True for reset
        if (resetStem)
        {
            // Reset object to 1,1,1
            stem.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
   


    }

    private void FixedUpdate()
    {
        
        Vector3 LeftHandVelocity = (LeftHandPosition - LeftHand.transform.position) / Time.deltaTime;
        Vector3 RightHandVelocity = (RightHandPosition - RightHand.transform.position) / Time.deltaTime;

        growStem = (Vector3.Distance(LeftHand.transform.position, RightHand.transform.position) < HandDistance) && (LeftHandVelocity.y > HandSpeed) && (RightHandVelocity.y > HandSpeed);

        LeftHandPosition = LeftHand.transform.position;
        RightHandPosition = RightHand.transform.position;
        
        LeftHand = GameObject.FindGameObjectWithTag("LeftHandTag");
        RightHand = GameObject.FindGameObjectWithTag("RightHandTag");
        LeftHandPosition = LeftHand.transform.position;
        RightHandPosition = RightHand.transform.position;
        
        
    }

    void MakeLeaf()
    {
        Instantiate(leaf, transform.position, Quaternion.identity);

        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y +180, rot.z);
        Debug.Log(Quaternion.Euler(rot));
        Instantiate(leaf, transform.position, Quaternion.Euler(rot));
    }
}
