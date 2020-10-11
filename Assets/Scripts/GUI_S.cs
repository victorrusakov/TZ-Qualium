using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_S : MonoBehaviour
{
    public Text txt;                              //переменная текста кнопки паузы
    public Text butTxt;                           //переменная текста кнопки Play
    public Button but;                            //переменная кнопки Play
    public Player_S player;                       

    //метод установки игры на паузу
    public void Pause() 
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;                   
            txt.text = ">";                       
        }
        else
        {
            Time.timeScale = 1;
            txt.text = "||";
        }
    }


    //метод начала игры
    public void Play()
    {
        player.isStart = true;                   //изменение переменной старта в скрипте главного персонажа  
        but.enabled = false;                     //отключение кнопки Play
        but.image.enabled = false;               //отключение отображения кнопки Play
        butTxt.enabled = false;                  //отключение текста на кнопке Play
    }
}
