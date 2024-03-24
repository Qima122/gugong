using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;
using System;

public class movement : MonoBehaviour
{
    public Transform myTransform;
    public float spdScale;
    private Rigidbody rb;
    private Vector3 positionNow;
    private BoxCollider Mycollider;
    // Start is called before the first frame update
    void Start()
    {
        Mycollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        myTransform = GetComponent<Transform>();
        spdScale = 0.2f;
        Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        
        
        myTransform.Rotate(-60 * 2 * Time.deltaTime * Input.GetAxis("Mouse Y"), 0, 0);
        myTransform.Rotate(0, 60 * 2 * Time.deltaTime * Input.GetAxis("Mouse X"), 0);
        
        myTransform.Translate(0, 0, 15 * Time.deltaTime * Input.GetAxis("Vertical") * spdScale);
        myTransform.Translate(15 * Time.deltaTime * Input.GetAxis("Horizontal") * spdScale, 0, 0);
        myTransform.Translate(0, 5 * Time.deltaTime * Input.GetAxis("Jump") * spdScale, 0);
        //rb.MovePosition(new Vector3(0, 0, 15 * Time.deltaTime * Input.GetAxis("Vertical") * spdScale));
        //rb.MovePosition(new Vector3(15 * Time.deltaTime * Input.GetAxis("Horizontal") * spdScale, 0, 0));
        myTransform.localEulerAngles = new Vector3(myTransform.rotation.eulerAngles.x, myTransform.rotation.eulerAngles.y, 0);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button6))
        {
            if (!Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Joystick1Button7))
            {
                spdScale -= (spdScale - 0.65f) * 0.3f;
            }
            else
            {
                spdScale -= (spdScale - 0.2f) * 0.3f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Joystick1Button7))
            {
                spdScale -= (spdScale - 0.05f) * 0.3f;
            }
            else
            {
                spdScale -= (spdScale - 0.2f) * 0.3f;
            }
        }
        if (Mycollider.isTrigger)
        {
            myTransform.position = positionNow;
        }
    }
    private void LateUpdate()
    {
        positionNow = myTransform.position;
    }
    private void FixedUpdate()
    {
        Debug.ClearDeveloperConsole();
        Utils.ClearLogConsole();
    }
    public static class Utils
    {
        static MethodInfo _clearConsoleMethod;
        static MethodInfo clearConsoleMethod
        {
            get
            {
                if (_clearConsoleMethod == null)
                {
                    Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
                    Type logEntries = assembly.GetType("UnityEditor.LogEntries");
                    _clearConsoleMethod = logEntries.GetMethod("Clear");
                }
                return _clearConsoleMethod;
            }
        }

        public static void ClearLogConsole()
        {
            clearConsoleMethod.Invoke(new object(), null);
        }
    }
}
