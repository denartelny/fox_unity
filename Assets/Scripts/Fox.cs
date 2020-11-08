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
    
    //Стоит лиса на земле, или нет
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
            anim.SetBool("isJumping", true);
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("isCrouching", true);
            speed /=2;
        }
        else
        if (Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("isCrouching", false);
            speed *= 2;
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
            SceneManager.LoadScene("SampleScene");
        }
        if (collision.gameObject.tag == "House(L.2)")
        {
            SceneManager.LoadScene("SampleScene");
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
            anim.SetBool("isJumping", false);
        }
        
    }
}