using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveController : MonoBehaviour
{
    public float mouseMoveSpeed = 25;
    private bool cursorFlag;

    // Start is called before the first frame update
    void Start()
    {
        cursorFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursorFlag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            cursorFlag = false;
        }
        if (cursorFlag)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(-mouseX * mouseMoveSpeed * Time.deltaTime, -mouseY * mouseMoveSpeed * Time.deltaTime, 0));
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView < 100)
            {
                Camera.main.fieldOfView += 2;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView > 30)
            {
                Camera.main.fieldOfView -= 2;
            }
        }
    }

}
