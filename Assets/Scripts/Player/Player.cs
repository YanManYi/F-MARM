using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [Range(1,10)]
    public float speed;

    private float inputX;
    private float inputY;

    private Vector2 movementInput;

    //TODO:

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    private void Update()
    {
        PlayerInput();
    }


    private void FixedUpdate()
    {
        Movement();
    }
    private void PlayerInput()
    {

    
        #region ��ֹб�����ƶ�
        //if (inputY == 0) inputX = Input.GetAxisRaw("Horizontal");
        //if (inputX == 0) inputY = Input.GetAxisRaw("Vertical");

        #endregion


        #region ����б�����ƶ�

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        //���ƺ����ٶȹ��죬��Ϊ������б�߾���������߾���
        if (inputX != 0 && inputY != 0)
        {
            inputX = Input.GetAxisRaw("Horizontal") * 0.6f;
            inputY = Input.GetAxisRaw("Vertical") * 0.6f;
        }

        #endregion



        movementInput = new Vector2(inputX, inputY);

    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.deltaTime);

    }




}
