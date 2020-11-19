using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class FrogScript : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool CanJump = true;

    private bool movingRight = false;

    public Transform groundDetection;
   
    Rigidbody2D rb;
    Animator anim;

    //Сила прыжка
    public int jump;

    //Стоит лиса на земле, или нет
    public Boolean frogStandsOnLand = true;

    //Последний прыжок был вправо - если да то true
    private Boolean jumpToRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
         
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }*/
        if (CanJump == true)
        {
            //float movingForce = jump * -0.2f * (jumpToRight ? 1 : -1);// UnityEngine.Random.Range(-0.2f, 0.2f);

            float movingForce = jump * -0.2f * UnityEngine.Random.Range(-0.2f, 0.2f);
            //ускорение вверх
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            
            CanJump = false;
            //jumpToRight = !jumpToRight;
            /*if (movingForce <= 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }*/
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Land")
        {
            frogStandsOnLand = true;
            anim.SetBool("Idle", true);
            CanJump = false;
            Invoke("Idle_frog", 2);
            CanJump = true;
        }

    }

}
