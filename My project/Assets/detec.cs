using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detec : MonoBehaviour
{
    public GameObject UI1;
    bool entered = false;
    bool triggered = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Cb1"))
        {
            UI1.SetActive(true);
            entered = true;
        }
        
    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("Cb1"))
        {
            UI1.SetActive(false);
            entered = false;
        }

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (entered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!triggered) {
                    UI1.SetActive(false);
                    triggered = true;
                }
                else
                {
                    UI1.SetActive(true);
                    triggered = false;
                }
            }
        }
    }
}
