using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefabScale : MonoBehaviour {

    private void Awake()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
