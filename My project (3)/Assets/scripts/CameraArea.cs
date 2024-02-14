using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraArea : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public static bool isEnter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            Debug.Log("wall");
            isEnter = true;
        }
        else
        {
            isEnter = false;
        }*/
    }

}
