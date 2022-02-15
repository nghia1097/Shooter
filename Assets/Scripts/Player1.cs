using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject bow2;
    public GameObject bow1;
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

        isshootPlayer2 = bow2.GetComponent<Bow>().isshootPlayer2;

        /*Debug.Log(isturnPlayer1);
        Debug.Log(isturnPlayer2);*/

        if (other.gameObject.CompareTag("Fireball"))
        {
            Debug.Log(isturnPlayer1);
            Debug.Log(isshootPlayer1);
            if (isturnPlayer1 == true && isshootPlayer1 == true)
            {
                player1.GetComponent<TurnPlayer1>().setTurnplayer1_false();
                player2.GetComponent<TurnPlayer2>().setTurnplayer2_true();
                bow1.GetComponent<Bow>().resetshootPlayer1();

            }
            if(isturnPlayer2 == true)
            {
                player2.GetComponent<TurnPlayer2>().setTurnplayer2_false();
                player1.GetComponent<TurnPlayer1>().setTurnplayer1_true();
                bow2.GetComponent<Bow>().resetshootPlayer2();
                player1.GetComponent<Audio1>().Audio_1();
                player1.GetComponent<Enemy>().TakeDamge_Player(40);
                player1.GetComponent<TurnPlayer1>().setisMove1_true();
                // Debug.Log("impact player1");
            }
        }
    }
}
