using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Panel;
    public Text txtWinner;
    public Button restart;
    public GameObject player1;
    public GameObject player2;
    public Sprite RestartIdle;
    public Sprite RestartOver;
    public Sprite RestartClick;

    private AudioSource audiosoure;
    public AudioClip gameover;
    Animator ani1;
    Animator ani2;
    // Start is called before the first frame update
    void Start()
    {
        audiosoure = gameObject.GetComponent<AudioSource>();
        ani1 = player1.GetComponent<Animator>();
        ani2 = player2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Startgame()
    {
        // Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        Startgame();
    }


    public void Endgame(string namePlayer)
    {

        Debug.Log("End Game");
        // Time.timeScale = 0;
        Panel.SetActive(true);
        audiosoure.clip = gameover;
        audiosoure.Play();
        if (namePlayer == player1.name)
        {
            // player1.SetActive(false);
            txtWinner.text = "WINNER: PLAYER2";
            ani2.SetTrigger("Win");
            player1.GetComponent<TurnPlayer1>().setTurnplayer1_false();
        }
        if (namePlayer == player2.name)
        {
            // player2.SetActive(false);
            txtWinner.text = "WINNER: PLAYER1";
            ani1.SetTrigger("Win");
            player2.GetComponent<TurnPlayer2>().setTurnplayer2_false();
        }

    }
    public void RestartButtonClick()
    {
        restart.GetComponent<Image>().sprite = RestartClick;

    }
    public void RestartButtonOver()
    {
        restart.GetComponent<Image>().sprite = RestartOver;
    }
    public void RestartButtonIdle()
    {
        restart.GetComponent<Image>().sprite = RestartIdle;
    }
    public void Exit()
    {
        Debug.Log("Exit!!");
        Application.Quit();
    }
}
