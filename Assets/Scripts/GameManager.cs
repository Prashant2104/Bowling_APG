using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score, TimePlayed;
    public GameObject B_Ball, GameOverPanel, GamePanel;
    public Text ShowScore, Details;

    void Start()
    {
        Score = 0;
        TimePlayed = 1;
        GameOverPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    private void Update()
    {
        Details.text = "Score = " + Score + 
                       "\n\nShot number = " + TimePlayed +
                       "\n\nPosition = " +(decimal)B_Ball.transform.position.x + 
                       "\n\nRotation = " + (decimal)B_Ball.transform.rotation.y + 
                       "\n\nSpeed = " + B_Ball.GetComponent<Rigidbody>().velocity;

        if(Input.GetKey(KeyCode.Return))
        {
            Score = 0;
            TimePlayed = 0;
            GameOverPanel.SetActive(false);
            GamePanel.SetActive(true);
            FindObjectOfType<Ball>().PlayTime = true;
        }
    }
    public void TurnOver()
    {
        if (TimePlayed > 2 || Score == 10)
        {
            FindObjectOfType<Ball>().PlayTime = false;
            GameOverPanel.SetActive(true);
            GamePanel.SetActive(true);
            ShowScore.text = Score.ToString();
        }
    }
}