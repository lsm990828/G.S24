using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRobot : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool jDown;

    bool isJump;
    Vector3 moveVec;

    Rigidbody rigid;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
         moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if(jDown && !isJump){
            rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision collision)//바닥 오브젝트의 태그를 새로 추가하여 지정 Floor로 만들고 지정한다, 모든 지형의 모듈은 정적static)으로 변경, 모든 지형들은 리지드 바다 추가후 use gravity해제, is kinematic 체크
    {
        if(collision.gameObject.tag == "Floor"){
            isJump = false;
        }
    }

}
