using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio1 : MonoBehaviour
{
    private AudioSource audiosoure;
    // public AudioClip moveclip;
    public AudioClip hurtclip;
    public AudioClip fireclip;
    Animator ani;
    /*bool isimpact = false;
    bool isplayfire = false;*/
    // Start is called before the first frame update
    void Start()
    {
        audiosoure = gameObject.GetComponent<AudioSource>();
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* float x = Input.GetAxis("Horizontal");
         Debug.Log(x);
         if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
         {
             audiosoure.loop = true;
             audiosoure.clip = moveclip;
             audiosoure.Play();

         }

         if (x > -0.01 && x < 0.01)
         {

             if (Input.GetMouseButton(0))
             {
                audiosoure.clip = fireclip;
                audiosoure.Play();
             }
             if (isimpact == true)
             {
                 audiosoure.clip = hurtclip;
                 audiosoure.Play();
                 isimpact = false;
             }
         }*/
        if (Input.GetMouseButton(0))
        {
            audiosoure.clip = fireclip;
            audiosoure.Play();
        }
    }
    public void Audio_1()
    {
        ani.SetTrigger("Hurt");
        // isimpact = true;
        audiosoure.clip = hurtclip;
        audiosoure.Play();
    }
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fireball"))
        {
            ani.SetTrigger("Hurt");
            // isimpact = true;
            audiosoure.clip = hurtclip;
            audiosoure.Play();

        }
    }*/

}
