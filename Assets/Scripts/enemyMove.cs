using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyMove : MonoBehaviour
{
    
    public GameObject Explosion;

    public static Color newWaveColor = Color.white;
    
    void Start()
    {
       float enemyPos = Random.Range(-2f, 2f);
       transform.position = new Vector2(transform.position.x + enemyPos, transform.position.y  );
       GetComponent<SpriteRenderer>().color = newWaveColor;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - GameControl.enemiesSpeed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Player.score--;

            Destroy(gameObject);
        }
       

      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag=="Bullets")
        {

            Player.score++;
            if (Player.score % 10 == 0)
            {
                GameControl.enemiesSpeed = GameControl.enemiesSpeed + 1f;
                newWaveColor = new Color(Random.value, Random.value, Random.value);


            }

            Destroy(collision.gameObject);
            var explosion = Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(explosion, 1.5f);
            Destroy(gameObject);
        }
    }

}