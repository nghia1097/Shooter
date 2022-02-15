using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer2 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject Bow;
    public bool isTurnPlayer2;
    public bool isMove2;

    // Start is called before the first frame update
    void Start()
    {
        isTurnPlayer2 = !(player1.GetComponent<TurnPlayer1>().isturnPlayer1);
    }

    public void setTurnplayer2_false()
    {
        isTurnPlayer2 = false;
    }
    public void setTurnplayer2_true()
    {
        isTurnPlayer2 = true;
    }
    public void setMove2_false()
    {
        isMove2 = false;
    }
    public void setMove2_true()
    {
        isMove2 = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(isMove2 == false)
            player2.GetComponent<Movement>().enabled = false;
        if (isTurnPlayer2 == true)
        {
            player2.GetComponent<Movement>().enabled = true;
            Bow.SetActive(true);
            gameObject.GetComponent<Audio2>().enabled = true;
        }
        else
        {
            player2.GetComponent<Movement>().enabled = false;
            Bow.SetActive(false);
            gameObject.GetComponent<Audio2>().enabled = false;
        }
    }
}
