using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphe;
    public Transform target;
    public float speed = 1f;
    private Transform tf;
    
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objscale = sphe.transform.localScale;
        float radiusX = objscale.x / 2f; 
        float radiusY = objscale.y / 2f; 
        float radiusZ = objscale.z / 2f; 

        float distance = Vector3.Distance(transform.position, sphe.transform.position);
        //transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

        Vector3 direction = (target.position - sphe.transform.position).normalized;
        float newX = sphe.transform.position.x + direction.x * radiusX;
        float newY = sphe.transform.position.y + direction.y * radiusY;
        float newZ = sphe.transform.position.z + direction.z * radiusZ;
        Vector3 newTarget = new Vector3(newX, newY, newZ);
        transform.position = Vector3.Lerp(transform.position, newTarget, speed*Time.deltaTime);




        //if (distance > radiusX || distance > radiusY || distance > radiusZ)
        //{
            
        //    Vector3 direction = (target.position - sphe.transform.position).normalized;
        //    float newX = sphe.transform.position.x + direction.x * radiusX;
        //    float newY = sphe.transform.position.y + direction.y * radiusY;
        //    float newZ = sphe.transform.position.z + direction.z * radiusZ;
        //    Vector3 newTarget = new Vector3(newX, newY, newZ);
        //    transform.position = transform.position + (transform.position - newTarget) * 0.1f;
        //}
    }
}
