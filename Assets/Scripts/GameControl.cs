using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameControl : MonoBehaviour
{
    public Text HiScore;
    public static float enemiesSpeed = 3;
   
    void Start()
    {

    }

   
    void Update()
    {
        HiScore.text = "High Score: " + PlayerPrefs.GetInt("HIGH_SCORE", 0).ToString();
    }

    public static void Reset()
    {
        enemiesSpeed = 3f;
    }


}
