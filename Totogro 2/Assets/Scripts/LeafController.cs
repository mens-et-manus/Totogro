using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{
    private GameObject stem;
    private GameObject leaf;
    private GameObject LeftHand;
    private GameObject RightHand;
    private GameObject Head;
    private bool growLeaf = false;
    private bool resetLeaf = false;
    private Vector3 LeftHandPosition;
    private Vector3 RightHandPosition;
    public float HandDistance = 1;
    public float HandSpeed = 1;
    

    private void Awake()
    {
        leaf = GameObject.FindGameObjectWithTag("ActiveLeaf");
        stem = GameObject.FindGameObjectWithTag("ActiveStem");
        LeftHand = GameObject.FindGameObjectWithTag("LeftHandTag");
        RightHand = GameObject.FindGameObjectWithTag("RightHandTag");
        Head = GameObject.FindGameObjectWithTag("HeadTag");
        LeftHandPosition = LeftHand.transform.position;
        RightHandPosition = RightHand.transform.position;
        
    }

    void Update()
    {
        leaf = GameObject.FindGameObjectWithTag("ActiveLeaf");
        stem = GameObject.FindGameObjectWithTag("ActiveStem");
        if (leaf)
        {
            Vector3 cornerOne = (new Vector3((float)(InstantiateLeaf.direction*leaf.transform.localScale.x * 0.5 * 0.707), (float)((stem.transform.position.y+stem.transform.localScale.y*0.5) + (leaf.transform.localScale.x * 0.333)), (float)(stem.transform.localPosition.z)));
            leaf.transform.position = cornerOne;
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 0, InstantiateLeaf.direction*45);
            leaf.transform.rotation = rot;
            // Grow functionality for leaves
            // Connect True values to arrow keys
            resetLeaf = Input.GetKey("left");

            // If True for grow
            if (growLeaf | Input.GetKey("right"))
            {

                // Grow in unit jumps
                leaf.transform.localScale += new Vector3(0.1f, 0, 0);

            }

            // If True for reset
            if (resetLeaf)
            {
                // Reset object to 1,1,1
                leaf.transform.localScale = new Vector3(1, 1, 1);
            }
            if (leaf.transform.localScale.x > 3|stem.transform.localScale.y>5)
            {
                GameObject NewStem = stem;
                leaf.gameObject.tag = "Leaf";
                stem.gameObject.tag = "Stem";
                    
                var temp = Instantiate(NewStem, new Vector3(0, (float)(stem.transform.position.y+0.5*stem.transform.localScale.y), 0), Quaternion.Euler(0,Random.Range(0f,360f),0));
                temp.tag = "ActiveStem";
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 LeftHandVelocity = (LeftHandPosition - LeftHand.transform.position) / Time.deltaTime;
        Vector3 RightHandVelocity = (RightHandPosition - RightHand.transform.position) / Time.deltaTime;

        growLeaf = (Vector3.Distance(LeftHand.transform.position, RightHand.transform.position) > HandDistance) && (Mathf.Abs(LeftHandVelocity.x) > HandSpeed) && (Mathf.Abs(RightHandVelocity.x) > HandSpeed) && (RightHand.transform.position.y<Head.transform.position.y) && (LeftHand.transform.position.y<Head.transform.position.y);

        LeftHandPosition = LeftHand.transform.position;
        RightHandPosition = RightHand.transform.position;
        
    }
}
