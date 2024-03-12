using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_camera : MonoBehaviour
{
    Transform probe_transform;
    public Transform target_transform;
    // Start is called before the first frame update
    void Start()
    {
        probe_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        probe_transform.position = target_transform.position;
    }
}
