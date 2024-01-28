using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class detec : MonoBehaviour
{
    public static bool entered = false;
    bool triggered = false;
    public TextMeshProUGUI ButText;
    public Image ButIma;
    private string OriText;
    private Animator ButAni;
    // Start is called before the first frame update
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        
        if (other.CompareTag("Cb1"))
        {
            Debug.Log("1");
            entered = true;
            restoreimage();
            ButText.text = OriText;
            
        }
        
    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("Cb1"))
        {
            entered = false;
            clearimage();
            ButText.text = null;
            
        }

    }
    void Start()
    {
        OriText = ButText.text;
        clearimage();
        ButText.text = null;
        ButAni = GetComponent<Animator>();
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
