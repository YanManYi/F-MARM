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

    
        #region 禁止斜方向移动
        //if (inputY == 0) inputX = Input.GetAxisRaw("Horizontal");
        //if (inputX == 0) inputY = Input.GetAxisRaw("Vertical");

        #endregion


        #region 允许斜方向移动

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        //限制横向速度过快，因为正方形斜边距离大于两边距离
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
