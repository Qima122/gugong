using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class detec : MonoBehaviour
{
    bool entered = false;
    bool triggered = false;
    public TextMeshProUGUI ButText;
    public Image ButIma;
    private string OriText;
    // Start is called before the first frame update
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Cb1"))
        {
            restoreimage();
            ButText.text = OriText;
            entered = true;
        }
        
    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("Cb1"))
        {
            clearimage();
            ButText.text = null;
            entered = false;
        }

    }
    void Start()
    {
        OriText = ButText.text;
        clearimage();
        ButText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (entered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!triggered) {
                    clearimage();
                    ButText.text = null;
                    triggered = true;
                }
                else
                {
                    restoreimage();
                    ButText.text = OriText;
                    triggered = false;
                }
            }
        }
    }
    void clearimage()
    {
        Color trans = new Color(0,0,0,0);
        ButIma.color = trans;
    }
    void restoreimage()
    {
        Color trans = new Color(255,255,255,255);
        ButIma.color = trans;
    }
}
