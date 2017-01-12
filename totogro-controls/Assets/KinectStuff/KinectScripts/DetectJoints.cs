using UnityEngine;
using System.Collections;
using Windows.Kinect;
//using System.;

public class DetectJoints : MonoBehaviour {

    public GameObject BodySrcMgr;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;
    private float currentclosest;

    //static string HandState;

    // Use this for initialization
    void Start () {
        if (BodySrcMgr == null)
        {
            Debug.Log("Assign game object with BodySrcMgr");
        }
        else
        {
            bodyManager = BodySrcMgr.GetComponent<BodySourceManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (bodyManager == null)
        {
            return;
        }
        bodies = bodyManager.GetData();
        if (bodies == null)
        {
            return;
        }
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                if (pos.Z < currentclosest)
                {
                    pos.Z = currentclosest;
                }
                gameObject.transform.position = new Vector3(pos.X, pos.Y, pos.Z);  // commented out to find closest body
            }
        }
        /*
        //warning: stupid code ahead
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                if (Mathf.Abs(pos.Z - currentclosest) < .5)
                {
                    gameObject.transform.position = new Vector3(pos.X, pos.Y, pos.Z);  // commented out to find closest body
                }
            }
        }
        currentclosest = 10000f;
        //end of stupid code
        */

        //HandState = bodies[0].HandRightState.ToString();
    }

    public string Hand1State () {
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                return bodies[0].HandRightState.ToString();
            }
        }
        return "No Bodies found...";
    }
}
