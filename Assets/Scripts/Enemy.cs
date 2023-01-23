using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   
    public GameObject Enemies;
    float repeatTime=1f;
    
    void Start()
    {
        InvokeRepeating("AddEnemy", repeatTime, repeatTime);
       
    }

    
    void Update()
    {
       


    }

    void AddEnemy()
    {
        repeatTime = Random.Range(1, 4);
        Instantiate(Enemies,transform.position,transform.rotation);
    }
   
}
