using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{
    private GameObject LeftHip;
    private Vector3 LeftHipPosition;
    public GameObject stem;
    public float JumpSpeed;
    private bool StartedGame = false;

    // Use this for initialization
    void Start () {
        LeftHip = GameObject.FindGameObjectWithTag("LeftHipTag");
        LeftHipPosition = LeftHip.transform.position;
    }

    private void FixedUpdate()
    {
        //if upward velocity is high enough (jump)
       if (!(StartedGame) && ((LeftHipPosition.y-LeftHip.transform.position.y)/Time.deltaTime>JumpSpeed))
        {
            Debug.Log("JUMP TRIGGERED");
            Instantiate(stem, new Vector3(0, 0, 0), Quaternion.identity);
            StartedGame = true;
        }
        LeftHipPosition = LeftHip.transform.position;
    }
}
