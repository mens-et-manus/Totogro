using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnTriggerEnter(Collider other) 
    {
            if (other.gameObject.stem)
            {
                SetActive(false);
            }
        }
    }
}
