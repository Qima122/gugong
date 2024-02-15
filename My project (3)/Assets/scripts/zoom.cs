using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class zoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera cam_1 = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.C))
        {
            GetComponent<Camera>().fieldOfView -= (float)((GetComponent<Camera>().fieldOfView - 30) * 0.1);
        } 
       else
        {
            GetComponent<Camera>().fieldOfView += (float)((60 - GetComponent<Camera>().fieldOfView) * 0.1);
        }
    }
}
