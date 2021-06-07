using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveController : MonoBehaviour
{
    public float mouseMoveSpeed = 10;
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
    }

}
