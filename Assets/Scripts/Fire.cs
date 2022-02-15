using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private AudioSource audiosoure;
    public AudioClip gameover;
    public GameController gameController;
    public GameObject player1;
    public GameObject player2;
    public GameObject bow_player1;
    public GameObject bow_player2;
    bool isturnPlayer1, isturnPlayer2;
    bool isshootPlayer1, isshootPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        audiosoure = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isturnPlayer1 = player1.GetComponent<TurnPlayer1>().isturnPlayer1;

        isturnPlayer2 = player2.GetComponent<TurnPlayer2>().isTurnPlayer2;

        isshootPlayer1 = bow_player1.GetComponent<Bow>().isshootPlayer1;

        isshootPlayer2 = bow_player2.GetComponent<Bow>().isshootPlayer2;



        Debug.Log(isturnPlayer1);
        Debug.Log(isturnPlayer2);

        if (other.gameObject.CompareTag("Fireball"))
        {
            Debug.Log("impact fire");
            Debug.Log(isshootPlayer2);
            Debug.Log(isturnPlayer2);
            if (isturnPlayer1 == true && isshootPlayer1 == true)
            {
                player1.GetComponent<TurnPlayer1>().setTurnplayer1_false();
                player2.GetComponent<TurnPlayer2>().setTurnplayer2_true();
                player2.GetComponent<TurnPlayer2>().setMove2_true();
                bow_player1.GetComponent<Bow>().resetshootPlayer1();
            }
            if (isturnPlayer2 == true && isshootPlayer2 == true)
            {
                player2.GetComponent<TurnPlayer2>().setTurnplayer2_false();
                player1.GetComponent<TurnPlayer1>().setTurnplayer1_true();
                player1.GetComponent<TurnPlayer1>().setisMove1_true();
                bow_player2.GetComponent<Bow>().resetshootPlayer2();
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            audiosoure.clip = gameover;
            audiosoure.Play();
            Debug.Log(other.gameObject.name);
            gameController.GetComponent<GameController>().Endgame(other.gameObject.name);
        }

    }
}
