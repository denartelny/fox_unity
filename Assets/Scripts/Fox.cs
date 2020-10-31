using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fox : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    //Скорость движения лисы
    public int speed;

    //Сила прыжка
    public int jump;

    public Boolean foxStandsOnLand = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Горизонтальное перемещение 
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        //Если нажали пробел (Space), то прыжок
        if (Input.GetKeyDown(KeyCode.Space) && foxStandsOnLand == true)
        {
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }


        //Если двигаемся, то включи анимацию бега и поеврни модельку в нужную стороны 
        if (Input.GetAxis("Horizontal") != 0)
        {

            //Запускаем анимацию бега 
            anim.SetBool("isRunning", true);

            //Поворот модельки
            FlipModel();

        }
        else
        {
            //иначе, останови анимацию бега
            anim.SetBool("isRunning", false);
        }
    }

    //Функция для поворота модельки лисенка
    private void FlipModel()
    {
        //Бежим вправо
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        //Бежим влево
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.tag == "Land")
        {
            foxStandsOnLand = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Land")
        {
            foxStandsOnLand = false;
        }
    }
}