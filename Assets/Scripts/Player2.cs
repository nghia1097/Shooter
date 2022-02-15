using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject bow1;
    public GameObject bow2;

    bool isturnPlayer1, isturnPlayer2;
    bool isshootPlayer1, isshootPlayer2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        isturnPlayer1 = player1.GetComponent<TurnPlayer1>().isturnPlayer1;

        isturnPlayer2 = player2.GetComponent<TurnPlayer2>().isTurnPlayer2;

        isshootPlayer1 = bow1.GetComponent<Bow>().isshootPlayer1;
        // isshootPlayer1 = player1.GetComponentInChildren<Bow>().isshootPlayer1;

        isshootPlayer2 = bow2.GetComponent<Bow>().isshootPlayer2;
        // isshootPlayer2 = player1.GetComponentInChildren<Bow>().isshootPlayer2;

        /*Debug.Log(isturnPlayer1);
        Debug.Log(isturnPlayer2);*/

        if (other.gameObject.CompareTag("Fireball"))
        {
            
            if (isturnPlayer2 == true && isshootPlayer2 == true)
            {
                player2.GetComponent<TurnPlayer2>().setTurnplayer2_false();
                player1.GetComponent<TurnPlayer1>().setTurnplayer1_true();
                bow2.GetComponent<Bow>().resetshootPlayer2();
            }
            /*Debug.Log(isturnPlayer1);
            Debug.Log(isshootPlayer1);*/
            if(isturnPlayer1 == true )
            {
                player1.GetComponent<TurnPlayer1>().setTurnplayer1_false();
                player2.GetComponent<TurnPlayer2>().setTurnplayer2_true();
                bow1.GetComponent<Bow>().resetshootPlayer1();
                // player1.GetComponentInChildren<Bow>().resetshootPlayer1();
                // Debug.Log("impact player2");
                player2.GetComponent<Audio2>().Audio_2();
                player2.GetComponent<Enemy_2>().TakeDamge_Player(40);
                player2.GetComponent<TurnPlayer2>().setMove2_true();
            }
        }
    }
}
