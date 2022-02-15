using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameController gameController;
    public int maxHealth = 100;
    int currentHealth;
    public Healthbar healthbar;
    public GameObject player1;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.Setmaxhealth(maxHealth);
        ani = player1.GetComponent<Animator>();
        
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
        healthbar.Sethealth(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log(name + "died");
            ani.SetTrigger("Lose");
            gameController.GetComponent<GameController>().Endgame(name);
        }
            

    }
}
