using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { }
    //Количество жизней при старте игры 
    public int health;

    //Те картинки, который мы только что создали 
    public Image hearts;

    //Когда жизнь есть
    public Sprite fullHeart;

    //Когда жизнь пустая 
    public Sprite emptyHeart; 


// Update is called once per frame
void Update()
    {
        if (health > hearts.Length)
        {
            health = hearts.Length;
        }


        if (health < 1)
        {
            //Конец игры
            SceneManager.LoadScene("SampleScene");
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < hearts.Length)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
