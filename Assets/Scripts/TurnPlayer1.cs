using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer1 : MonoBehaviour
{
    public GameObject Bow;
    public bool isturnPlayer1;
    public bool ismove1;
    private Movement move;
    public void setTurnplayer1_false()
    {
        isturnPlayer1 = false;
    }
    public void setTurnplayer1_true()
    {
        isturnPlayer1 = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        ismove1 = true;
        isturnPlayer1 = true;
        move = gameObject.GetComponent<Movement>();
    }
    public void setisMove1_false()
    {
        ismove1 = false;
    }
    public void setisMove1_true()
    {
        ismove1 = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (ismove1 == false)
            move.enabled = false;
        if (isturnPlayer1 == true)
        {
            move.enabled = true;
            Bow.SetActive(true);
            gameObject.GetComponent<Audio1>().enabled = true;
        }
        else
        {
            move.enabled = false;
            Bow.SetActive(false);
            gameObject.GetComponent<Audio1>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
