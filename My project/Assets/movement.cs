using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform myTransform;
    public float spdScale;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
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
        //rb.MovePosition(new Vector3(0, 0, 15 * Time.deltaTime * Input.GetAxis("Vertical") * spdScale));
        //rb.MovePosition(new Vector3(15 * Time.deltaTime * Input.GetAxis("Horizontal") * spdScale, 0, 0));
        myTransform.localEulerAngles = new Vector3(myTransform.rotation.eulerAngles.x, myTransform.rotation.eulerAngles.y, 0);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (spdScale < 0.65f)
            {
                spdScale += 0.05f;
            }
        }
        else
        {
            if (spdScale > 0.2f)
            {
                spdScale -= 0.05f;
            }
        }
    }
}
