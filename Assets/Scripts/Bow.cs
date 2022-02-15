using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float lauchForce = 0f;
    public GameObject arrow;
    public Transform shotPoint;
    //
    public GameObject player1;
    private Animator ani_player1, ani_player2;
    //
    public GameObject point;
    GameObject[] points;
    public int numberOfPonits;
    public float spaceBetweenPoints;
    Vector2 Direction;
    // 
    public GameObject player2;
    // 
    bool isturnplayer1, isturnplayer2;
    public bool isshootPlayer1, isshootPlayer2; 

    // Start is called before the first frame update
    void Start()
    {
        // animator
        ani_player1 = player1.GetComponent<Animator>();
        ani_player2 = player2.GetComponent<Animator>();
        //
        points = new GameObject[numberOfPonits];
        for (int i = 0; i < numberOfPonits; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // get turnplayer
        isturnplayer1 = player1.GetComponent<TurnPlayer1>().isturnPlayer1;

        isturnplayer2 = player2.GetComponent<TurnPlayer2>().isTurnPlayer2;


        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = bowPosition - mousePosition;
        transform.right = Direction;
        if (Input.GetKey(KeyCode.UpArrow))
            lauchForce += 0.01f;
        if (Input.GetKey(KeyCode.DownArrow))
            lauchForce -= 0.01f;

        for (int i = 0; i < numberOfPonits; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }


        if (Input.GetMouseButtonDown(0))
        {
            // animation attack
            if (isturnplayer1 == true)
            
            {
                player1.GetComponent<TurnPlayer1>().setisMove1_false();
                
                if (isshootPlayer1 == false)
                {
                    Shoot();
                    ani_player1.SetTrigger("Attack");
                }
                isshootPlayer1 = true;
            }
            if (isturnplayer2 == true)
            {
                player2.GetComponent<TurnPlayer2>().setMove2_false();
                if(isshootPlayer2 == false)
                {
                    Shoot();
                    ani_player2.SetTrigger("Attack");
                }
                isshootPlayer2 = true;
            }
            //Shoot();
        }

    }
    public void resetshootPlayer1()
    {
        isshootPlayer1 = false;
    }
    public void resetshootPlayer2()
    {
        isshootPlayer2 = false;
    }
    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;  
    }
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (Direction.normalized * lauchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

}
