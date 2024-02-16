using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphe;
    public Transform target;
    public float speed = 1f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objscale = sphe.transform.localScale;
        float radiusX = objscale.x / 2f; 
        float radiusY = objscale.y / 2f; 
        float radiusZ = objscale.z / 2f; 

        float distance = Vector3.Distance(transform.position, sphe.transform.position);

        Vector3 newPosition = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

        

        rb.MovePosition(newPosition); 

        if (distance > radiusX || distance > radiusY || distance > radiusZ)
        {
            
            Vector3 direction = (transform.position - sphe.transform.position).normalized;
            float newX = sphe.transform.position.x + direction.x * radiusX;
            float newY = sphe.transform.position.y + direction.y * radiusY;
            float newZ = sphe.transform.position.z + direction.z * radiusZ;

            transform.position = new Vector3(newX, newY, newZ);
        }
    }
}
