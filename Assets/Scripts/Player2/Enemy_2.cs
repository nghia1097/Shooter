using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public GameObject player2;
    Animator ani;
    public GameController gameController;
    public int maxHealth = 100;
    int currentHealth;
    public Healthbar_2 healthbar_2 ;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar_2.Setmaxhealth(maxHealth);
        ani = player2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamge_Player(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        // Debug.Log(currentHealth);
        // healBar_player
        healthbar_2.Sethealth(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log(name + "died");
            ani.SetTrigger("Lose");
            gameController.GetComponent<GameController>().Endgame(name);
        }
            

    }
}
