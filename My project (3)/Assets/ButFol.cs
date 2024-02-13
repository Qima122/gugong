using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphe;
    public Transform target;
    public float speed = 10f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objscale = sphe.transform.localScale; 
        float radius = ((objscale.x + objscale.y + objscale.z) / 3f) / 2f;
        float distance = Vector3.Distance(transform.position, sphe.transform.position);
        
        rb.MovePosition(Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime)); //chase the camera
        if (distance > radius)
                {
                    Vector3 newpos = (transform.position - sphe.transform.position).normalized;
                    transform.position = sphe.transform.position + newpos * radius;
                }

            
    }
}
