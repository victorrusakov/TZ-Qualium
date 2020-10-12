using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_S : MonoBehaviour
{
    public bool isStart;                        
    public bool isPlay;                         
    public float moveSpeed = 5f;  
    public Points_S points;

    private GameObject[] waypoints;
    private int waypointId = 0;
    
    void Start()
    {
        waypoints = points.myWaypoints;                                                                 //присвоение массива с точками для траектории движения
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isStart)    //проверка на возможность начала игры и нажатие правой кнопки мыши
        {
            isPlay = true;
            points.SpawnPoint();                                                                        //расстановка точек в случайных местах
        }
        else if (Input.touchCount > 0)                  //проверка на нажатия на экран
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && isStart) //проверка на возможность начала игры и нажатие на экран
            {
                isPlay = true;
                points.SpawnPoint();
            }

        }
    }

    void FixedUpdate()
    {
        if(isPlay) PlayerMovement();                                                                    //движение главного персонажа
    }


    //метод для движения главного персонажа
    void PlayerMovement()
    {
        isStart = false;                                                                                

        if (waypoints.Length != 0)
        {
            
            if (Vector3.Distance(waypoints[waypointId].transform.position, transform.position) <= 0)
            {
                waypoints[waypointId].SetActive(false);                                                //отключение точки при достижении ее координат
                waypointId++;
            }

            //сброс счетчика точек в 0 при достижении последней точки
            if (waypointId >= waypoints.Length)
            {
                waypointId = 0;
                isPlay = false;
                isStart = true;
            }
            transform.LookAt(waypoints[waypointId].transform);                                          //смотрим на точку к которой движемся                                   
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointId].transform.position, moveSpeed * Time.deltaTime); //задание движения к точке

        }
    }

    
}
