using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KamikadzeMovement : MonoBehaviour
{
    public float Speed, distance;
    private GameObject player;
    private Rigidbody2D RB;
    private SpriteRenderer Kamikadze;
    private float side;
    public Detection Det;
    public PlaneDeath Death;
    private AudioSource Music, MainMusic;
    private bool once= false;
    private Vector2 vector;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gam_obj = GameObject.Find("Music");
        MainMusic = gam_obj.GetComponent<AudioSource>();
        Music = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        Kamikadze = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Det.IsDetected != false && once !=true)
        {
            MainMusic.Pause();
            Music.Play();
            once= true;
        }    

        float step = Speed * Time.deltaTime;
        if (player != null && Death.isDead != true && (Det.IsDetected != false))
        {
            
            if(player.transform.position.x + distance < transform.position.x) 
            {
                Kamikadze.flipX= false;
                transform.position -=  transform.right * (Time.deltaTime * Speed);
            }
            else if(player.transform.position.x - distance > transform.position.x)
            {
                Kamikadze.flipX = true;
                transform.position +=  transform.right * (Time.deltaTime * Speed);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
                if(Kamikadze.flipX == true)
                     vector =  player.transform.position - transform.position ; 
                else
                     vector = transform.position - player.transform.position ;
                vector.Normalize();
                float Angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
                Quaternion rotate = Quaternion.Euler(0, 0, Angle);
                transform.rotation = rotate;
            }
        }
    }
}
