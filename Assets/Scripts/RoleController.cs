using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    private CharacterController characterController;
    public float gravity = 10;
    private Vector3 moveDirection = new Vector3(0,0,0);
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(characterController.transform.position.x);
        if (characterController.transform.position.x != hit.point.x + 50 &&
            characterController.transform.position.x != hit.point.x - 50)
        {
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //需要碰撞到物体才可以
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isCollider = Physics.Raycast(ray, out hit);
            if (isCollider)
            {
                if (hit.collider.gameObject.tag.Equals("Environment"))  //移动
                {
                    Debug.Log("Move to:" + hit.point.ToString());
                    if (characterController.isGrounded)
                    {
                        moveDirection.x = hit.point.x - characterController.transform.position.x;
                    }
                    moveDirection.y -= gravity * Time.deltaTime;
                }
                if (hit.collider.gameObject.tag.Equals("Character"))
                {
                    Debug.Log("Get Character");
                    characterController = hit.collider.gameObject.GetComponent<CharacterController>();
                }
            }
        }
    }

}
