using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score, TimePlayed, Pins;
    public GameObject B_Ball, GameOverPanel, GamePanel;
    public Text ShowScore, Details;

    void Start()
    {
        Score = 0;
        TimePlayed = 1;
        Pins = 10;
        GameOverPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    private void Update()
    {
        //**--------Showing details about the Ball-----------**
        Details.text = "   Stats" +
                       "\n\nScore = " + Score + 
                       "\n\nShot number = " + TimePlayed +
                       "\n\nPins left = " + Pins +
                       "\n\nPosition = " + B_Ball.transform.position.x.ToString("F3") + 
                       "\n\nRotation = " + B_Ball.transform.rotation.y.ToString("F3") + 
                       "\n\nSpeed = " + B_Ball.GetComponent<Rigidbody>().velocity.z.ToString("F3");
        //**--------Showing details about the Ball-----------**
        ////////////////////////////////////////////////////
        //**------------Reseting the game--------------**
        if (Input.GetKey(KeyCode.Return) && GameOverPanel.activeInHierarchy == true)
        {
            SceneManager.LoadScene(0);
            /*Score = 0;
            TimePlayed = 0;
            GameOverPanel.SetActive(false);
            GamePanel.SetActive(true);
            FindObjectOfType<Ball>().PlayTime = true;*/
        }
        //**------------Reseting the game--------------**
    }
    public void TurnOver()
    {
        if (TimePlayed > 2)
        {
            FindObjectOfType<Ball>().PlayTime = false;
            GameOverPanel.SetActive(true);
            GamePanel.SetActive(false);
            ShowScore.text = Score.ToString();
        }
        if (TimePlayed > 2 && Score == 10)
        {
            FindObjectOfType<Ball>().PlayTime = false;
            GameOverPanel.SetActive(true);
            GamePanel.SetActive(false);
            ShowScore.text = "Stride";
        }
        if (TimePlayed == 2 && Score == 10)
        {
            FindObjectOfType<Ball>().PlayTime = false;
            GameOverPanel.SetActive(true);
            GamePanel.SetActive(false);
            ShowScore.text = "Strike";
        }
    }
}