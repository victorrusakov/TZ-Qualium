using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_S : MonoBehaviour
{
    public GameObject[] myWaypoints;
    private int myWaypointId = 0;

    //метод распределения точек из массива по случайным координатам
    public void SpawnPoint()
    {
        if (myWaypoints.Length != 0)
        {

           while(myWaypointId < myWaypoints.Length)
            {
                myWaypoints[myWaypointId].transform.position = new Vector3(Random.Range(-10f, 10f), 2f, Random.Range(-5f, 5f));  //распределение точки в случайную позицию
                myWaypoints[myWaypointId].SetActive(true);                                                                       //включение точки
                myWaypointId++;
            }
           //сброс счетчика точек
            if (myWaypointId >= myWaypoints.Length)
            {
                myWaypointId = 0;
            }
        }
       
    }
}
