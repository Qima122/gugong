using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detec : MonoBehaviour
{
    public GameObject UI1;
    // Start is called before the first frame update
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Cb1"))
        {
            Debug.Log("Y");
            UI1.SetActive(true);
        }
        
    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("Cb1"))
        {
            UI1.SetActive(false);
        }

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
