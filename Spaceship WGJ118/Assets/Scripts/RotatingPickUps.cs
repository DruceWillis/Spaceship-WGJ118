using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingPickUps : MonoBehaviour
{
    [SerializeField] float scaleSpeed = 1.001f;
    bool growing = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float size = transform.localScale.x;
        //Debug.Log(size);
        if (growing)
        {
            transform.localScale = new Vector3(transform.localScale.x * scaleSpeed, transform.localScale.y * scaleSpeed, 1);
            if (transform.localScale.x >= 0.75f)
                growing = false;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x / scaleSpeed, transform.localScale.y / scaleSpeed, 1);
            if (transform.localScale.x <= 0.65f)
                growing = true;
        }
    }

}
