using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in transform)
        {
            child.LookAt(Camera.main.transform);
            child.Rotate(0, 180, 0);
        }
    }
}
