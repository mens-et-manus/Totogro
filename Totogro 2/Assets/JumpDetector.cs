using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{
    public AudioSource audio;
    private GameObject LeftHip;
    private Vector3 LeftHipPosition;
    public GameObject stem;
    public GameObject scripts;
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
       if (!(StartedGame) && ((LeftHipPosition.y-LeftHip.transform.position.y)/Time.deltaTime>JumpSpeed)|Input.GetKey("space"))
        {
            Instantiate(stem, new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(scripts, new Vector3(0, 0, 0), Quaternion.identity);
            StartedGame = true;
            audio.Play();
        }
       //TODO: add squat to spawn new plant

        LeftHipPosition = LeftHip.transform.position;
    }
}
