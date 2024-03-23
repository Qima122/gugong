using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using System;
using System.Linq;
using JetBrains.Annotations;

public class detecBut : MonoBehaviour
{
    string objectName;
    string value;
    TextMeshProUGUI ButText;
    Image objIma;
    static bool activityE = false;
    static bool activityQ = false;
    bool AlrProc; //already processed, but i forgot what its use is, don't remove it otherwise the code gets bugged
    string save;
    bool state = false;
    static string obje;
    string FirstObj;
    public GameObject obj1;


    void Start()
    {
        int length = detec.enter.Length;
        objectName = gameObject.name;
        objIma = gameObject.GetComponent<Image>();
        ButText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        
}

    void Update()
    {
        for (int i = 0; i < detec.enter.Length; i++)
        {
            value = detec.enter[i];
            if (value == objectName)
            {
                detec.restoreimage(objIma);
                detec.restoretext(ButText);
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5)) && detec.entered)
                {
                    AlrProc = true;
                    detec.enter[i] = "Cb";
                    detec.clearimage(objIma);
                    detec.cleartext(ButText);
                    save = value + 1; // value + 1, ex. Cb1 + 1 -> Cb11, then call the 'other()' function with input 'save'
                    obje = save;
                    FirstObj = value;
                    other(save, detec.entered);
                }
            }

            if (!detec.entered)
            {
                detec.enter[i] = "Cb";
                other(save, false);
                detec.enter[i] = save;
            }
        }

        if (AlrProc && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5)) && detec.entered)
        {
            if (!detec.FirstEntered)
            {
                toggleE_Activ();
            }
            other(save, detec.entered);
            detec.FirstEntered = false;
        }
        if (AlrProc && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4)) && detec.entered)
        {
            if (!detec.FirstEntered && FirstObj != obje)
            {
                toggleQ_Activ();
            }
            other(save, detec.entered);
            detec.FirstEntered = false;
        }

        if (!detec.entered && objIma != null && ButText != null)
        {
            detec.clearimage(objIma);
            detec.cleartext(ButText);
            AlrProc = false;
        }

        if (state)
        {
            if (detec.entered)
            {
                state = false;
                other(obje, true);
                state = true; //keep (state = true) until player leave the detection area
            }
            if (!detec.entered)
            {
                state = false;
                other(obje, false);
                //obje = null;
            }
        }
    }

    void toggleE_Activ()
    {
        activityE = !activityE;
        //Debug.Log("Toggle " + activity);
    }
    void toggleQ_Activ()
    {
        activityQ = !activityQ;
        //Debug.Log("Toggle " + activity);
    }

    void other(string objname, bool currentFound) //the function that can make buttons appear and disappear, 'currentFound' is like 'detec.entered'
    {
        if(objname != null)
        {
        Debug.Log(objname);
            Match match = Regex.Match(objname, @"\d+"); // Regex function: extract numbers from string (ex. Cb11 -> 11)
            string result = match.Value;
            int num = Int32.Parse(result);
            if (num > 100)
            {
                Debug.Log("he");
                objname = null;
                num = 1;
            }
        }
        
        GameObject obj = GameObject.Find(objname);
        if ((obj != null && obje != null) && (objname.CompareTo(obje) < 0 || objname.CompareTo(obje) > 0))
        {
            state = true; //state, a variable that is similar to another "detec.entered", in order to make the button disappear if player leave the detection area
        }
        if (state || obj == null)
        {
            return;
        }
        if (!currentFound && obj != null)
        {
            Image objIma = obj.GetComponent<Image>();
            TextMeshProUGUI[] objText = obj.GetComponentsInChildren<TextMeshProUGUI>();
            detec.clearimage(objIma);
            foreach (TextMeshProUGUI text in objText)
            {
                detec.cleartext(text);
            }
            activityE = false;
            activityQ = false;
        }
        else if (currentFound && obj != null)
        {
            Image objIma = obj.GetComponent<Image>();
            TextMeshProUGUI[] objText = obj.GetComponentsInChildren<TextMeshProUGUI>();
            detec.restoreimage(objIma);
            foreach (TextMeshProUGUI text in objText)
            {
                detec.restoretext(text);
            }
            Match match = Regex.Match(objname, @"\d+"); // Regex function: extract numbers from string (ex. Cb11 -> 11)
            string result = match.Value;
            int num = Int32.Parse(result);
            if (activityE && objname != null)
            {
                activityE = false;
                detec.clearimage(objIma);
                foreach (TextMeshProUGUI text in objText)
                {
                    detec.cleartext(text);
                }
                if (num < 10) //detect if input is Cb1 or Cb2 or Cb3 etc.. (if there are more than 10 objects, change here)
                {
                    obje = "Cb" + num + 1;
                    other("Cb" + num + 1, currentFound);
                }
                else
                {
                    obje = "Cb" + (num + 1);
                    other("Cb" + (num + 1), currentFound);
                }
                
            }
            else if (activityQ && objname != null)
            {
                activityQ = false;
                detec.clearimage(objIma);
                foreach (TextMeshProUGUI text in objText)
                {
                    detec.cleartext(text);
                }
                obje = "Cb" + (num - 1);
                other("Cb" + (num - 1), currentFound);
            }
            if (obj1.gameObject.transform.Find(obje) == null) // detect if this is the last button (the new code that fixed "button problem")
            {
                activityQ = false;
                detec.clearimage(objIma);
                foreach (TextMeshProUGUI text in objText)
                {
                    detec.cleartext(text);
                }
                obje = FirstObj;
                other(FirstObj, true);
            }
            
        }
    }
}
