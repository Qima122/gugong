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

public class detecBut : MonoBehaviour
{
    string objectName;
    string value;
    TextMeshProUGUI ButText;
    Image objIma;
    static bool activityE = false;
    static bool activityQ = false;
    bool AlrProc;
    string save;
    bool state = false;
    static string obje; 
    string objmin;

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
                if (Input.GetKeyDown(KeyCode.E) && detec.entered)
                {
                    AlrProc = true;
                    detec.enter[i] = "Cb";
                    detec.clearimage(objIma);
                    detec.cleartext(ButText);
                    save = value + 1;
                    obje = save; 
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

        if (AlrProc && Input.GetKeyDown(KeyCode.E) && detec.entered)
        {
            if (!detec.FirstEntered)
            {
                toggleE_Activ();
            }
            other(save, detec.entered);
            detec.FirstEntered = false;
        }
        if (AlrProc && Input.GetKeyDown(KeyCode.Q) && detec.entered)
        {
            if (!detec.FirstEntered)
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
                state = true;
            }
            if (!detec.entered)
            {
                state = false;
                other(obje, false);
                obje = null;
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

    void other(string objname, bool currentFound)
    {
        //Debug.Log(objname);
        GameObject obj = GameObject.Find(objname);
        if ((obj != null && obje != null) && (objname.CompareTo(obje) < 0 || objname.CompareTo(obje) > 0))
        {
            state = true;
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
            if (activityE && objname != null)
            {
                Match match = Regex.Match(objname, @"\d+");
                string result = match.Value;
                int num = Int32.Parse(result);
                activityE = false;
                detec.clearimage(objIma);
                foreach (TextMeshProUGUI text in objText)
                {
                    detec.cleartext(text);
                }
                obje = "Cb" + (num + 1);
                other("Cb" + (num + 1), currentFound);
            }
            else if (activityQ && objname != null)
            {
                Match match = Regex.Match(objname, @"\d+");
                string result = match.Value;
                int num = Int32.Parse(result);
                activityQ = false;
                detec.clearimage(objIma);
                foreach (TextMeshProUGUI text in objText)
                {
                    detec.cleartext(text);
                }
                obje = "Cb" + (num - 1);
                other("Cb" + (num - 1), currentFound);
            }
        }
    }
}
