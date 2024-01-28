using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (detec.entered==true)
        {
            animator.SetBool("appear",true);
        }
        else if (detec.entered==false)
        {
            animator.SetBool("appear", false);
        }
    }
}
