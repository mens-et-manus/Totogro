using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLeaf : MonoBehaviour {


    public GameObject leaf;
    private GameObject stem;
    private GameObject newLeaf;
    public static int direction;

    private void Awake()
    {
        newLeaf = leaf;

        var temp = Instantiate(newLeaf, transform.position+transform.localScale/2, Quaternion.identity);
        temp.tag = "ActiveLeaf";


        leaf = GameObject.FindGameObjectWithTag("ActiveLeaf");
        
        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y + 180, rot.z);
        

        direction = Random.Range(0, 2);
        
        if (direction == 0)
        {
            direction = -1;
        }
        Debug.Log(direction);

    }
    private void Update()
    {

    }
}
