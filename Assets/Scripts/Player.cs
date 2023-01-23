using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
   
    public GameObject DiePanel;
    public GameObject Bullet;

    public float Speed = 500f;

    public Joystick JoystickTool;
    
    public AudioSource GameOverSound;
    public AudioSource ShootingSound;
    public AudioSource BackGround;
    
    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] Transform rightLimit;
    [SerializeField] Transform leftLimit;
    [SerializeField] Transform upLimit;
    [SerializeField] Transform downLimit;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        score = 0;
        
        InvokeRepeating("Shooting", .5f, .5f );

    }

    private float HorizontalAxis()
    {

        var h = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(h) > 0)
        {
            return h;

        }
        else
        {
            return JoystickTool.Horizontal;
        }
    }
    private float VerticalAxis()
    {
        var v = Input.GetAxisRaw("Vertical");
        if(Mathf.Abs(v) > 0)
        {
            return v;
        }
        else
        {
            return JoystickTool.Vertical;
        }
    }
    
    
    void Update()
    {
        scoreText.text = score.ToString();

            movement.x = HorizontalAxis();
            movement.y = VerticalAxis();



      
        
        var exceedsRightLimit = (movement.x + transform.position.x) >= rightLimit.position.x;
        var exceedsLeftLimit = (movement.x + transform.position.x) <= leftLimit.position.x;

        if (exceedsRightLimit || exceedsLeftLimit )
        {
            movement.x = 0;
        }

        var exceedsUpLimit = (movement.y + transform.position.y) >= upLimit.position.y;
        var exceedsDownLimit = (movement.y + transform.position.y) <= downLimit.position.y;
        
        if (exceedsUpLimit || exceedsDownLimit)
        {
            movement.y = 0;
        }

        rb.velocity = movement * Speed * Time.deltaTime; 
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemies")
        {
              
            if(score > PlayerPrefs.GetInt("HIGH_SCORE",0))
            { 
                PlayerPrefs.SetInt("HIGH_SCORE", score);
               

            }
            GameControl.Reset();

            Time.timeScale = 0;
            DiePanel.gameObject.SetActive(true);
            GameOverSound.Play();
            BackGround.Stop();
        }

    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        BackGround.Play();

    }

    void Shooting()
    {
        GameObject newBullet = Instantiate(Bullet,transform.position, Bullet.transform.rotation) ;
        ShootingSound.Play();
    }

    public void ResetScore()
    {
       // PlayerPrefs.SetInt("HIGH_SCORE", 0);
        PlayerPrefs.DeleteKey("HIGH_SCORE");
    }
}
