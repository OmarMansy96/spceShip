using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
   
    float bulletSpeed = 11f;
  
    public float BulletSpeed = 2f;
    void Start()
    {
       
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + bulletSpeed * Time.deltaTime);

        if(transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
