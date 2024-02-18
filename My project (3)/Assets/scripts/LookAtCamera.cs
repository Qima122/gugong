using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 initialPosition = new Vector3(0f, 0f, 0f);
    public Vector3 initialRotation = new Vector3(0f, 0f, 0f);

    void Start()
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.Euler(initialRotation);
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
