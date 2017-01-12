using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementDetector : MonoBehaviour {

    public Text infoText;
    private GameObject leftHand;
    private GameObject rightHand;
    private GameObject leftHip;
    private Rigidbody lhandrb;
    private Rigidbody rhandrb;
    private Rigidbody lhiprb;
    private Vector3 lhandprevious;
    private Vector3 lhipprevious;
    private Vector3 rhandprevious;
    private Vector3 lhandcurrent;
    private Vector3 lhipcurrent;
    private Vector3 rhandcurrent;
    private Vector3 lhandvel;
    private Vector3 rhandvel;
    private Vector3 lhipvel;


    private void Start()
    {
        leftHand = GameObject.FindWithTag("LeftHand");
        lhandrb = leftHand.GetComponent<Rigidbody>();
        leftHip = GameObject.FindWithTag("LeftHip");
        lhiprb = leftHip.GetComponent<Rigidbody>();
        rightHand = GameObject.FindWithTag("RightHand");
        rhandrb = rightHand.GetComponent<Rigidbody>();
        lhandprevious = lhandrb.transform.position;
        rhandprevious = rhandrb.transform.position;
        lhipprevious = lhiprb.transform.position;
    }

    void FixedUpdate()
    {
        lhandcurrent = lhandrb.transform.position;
        rhandcurrent = rhandrb.transform.position;
        lhipprevious = lhiprb.transform.position;
        lhandvel = (lhandcurrent - lhandprevious) / Time.deltaTime;
        rhandvel = (rhandcurrent - rhandprevious) / Time.deltaTime;
        lhipvel = (lhipcurrent - lhipprevious) / Time.deltaTime;

        infoText.text = "Movements: ";
        if ((lhandvel.y>1)&&(rhandvel.y>1))
        {
            infoText.text += "Grow Up ";
            Debug.Log("Grow Up");
        }
        if (lhipvel.y>1)
        {
            infoText.text += "Jump ";
            Debug.Log("Jump");
        }
        if ((lhandvel.x > 1) && (rhandvel.x > 1))
        {
            infoText.text += "Grow Sides";
            Debug.Log("Grow Sides");
        }
        Debug.Log("left Hand: "+lhandrb.velocity.y);
        lhandprevious = lhandrb.transform.position;
        rhandprevious = rhandrb.transform.position;
        lhipprevious = lhiprb.transform.position;

    }


}
