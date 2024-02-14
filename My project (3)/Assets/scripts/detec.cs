using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class detec : MonoBehaviour
{
    public static bool entered = false;
    bool triggered = false;
    private Animator ButAni;
    public static string[] enter = new string[10];
    public static bool FirstEntered;
    // Start is called before the first frame update
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        FirstEntered = true;
        for (int i = 0; i < 10; i++)
        {
            if (other.CompareTag("Cb" + (i + 1))) //the "Cb" name tags are for exhibition items
            {
                entered = true;
                enter[i] = "Cb" + (i + 1);  //note that if there are more than 10 objects, change here
                //restoreimage();
                //ButText.text = OriText;

            }
        }


    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        for (int i = 0; i < 10; i++)
        {
            if (other.CompareTag("Cb" + (i + 1)))
            {
                FirstEntered = false;
                entered = false;
                enter[i] = "Cb";
                //clearimage();
                //ButText.text = null;
            }
        }


    }
    void Start()
    {
        //clearimage();
        //ButText.text = null;
        ButAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (entered)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (!triggered)
                {
                    //clearimage();
                    //ButText.text = null;
                    triggered = true;
                }
                else
                {
                    //restoreimage();
                    //ButText.text = OriText;
                    triggered = false;
                }
            }
        }
        */
    }
    public static void clearimage(Image ButIma)
    {
        Color trans = new Color(0, 0, 0, 0);
        ButIma.color = trans;
    }
    public static void restoreimage(Image ButIma)
    {
        Color trans = new Color(255, 255, 255, 255);
        ButIma.color = trans;
    }
    public static void cleartext(TextMeshProUGUI text)
    {
        Color textcolor = text.color;
        textcolor.a = 0f; //alpha, 1: opaque, 0: transparant
        text.color = textcolor;
    }
    public static void restoretext(TextMeshProUGUI text)
    {
        Color textcolor = text.color;
        textcolor.a = 1f;
        text.color = textcolor;
    }
}