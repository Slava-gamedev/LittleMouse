using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float Speed;
    public int minus;
    public float bY;
    public float LbX;
    public float RbX;
    public float dist;
    private GameObject player;
    private SpriteRenderer tankSprite;
    public SpriteRenderer BarrelSprite;
    private bool facingRight = false;
    private bool IsFlipping = false;
    public Animator TankAn;
    public EnemyDeath EnDeath;
    public GameObject Point;
    public Detection Det;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tankSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null &&  EnDeath.isDead != true && (Det.IsDetected != false))
        {
            if (player.transform.position.x < transform.position.x)
            {
                if (Mathf.Abs(player.transform.position.x - transform.position.x) > (dist -1) && IsFlipping != true)
                {
                    if (Mathf.Abs(player.transform.position.x - transform.position.x) < dist)
                        transform.position -= transform.right * (Time.deltaTime * (Speed - minus));
                    else
                        transform.position -= transform.right * (Time.deltaTime * Speed);
                    TankAn.SetBool("IsMoving", true);
                }
                else
                    TankAn.SetBool("IsMoving", false);
                if (facingRight == true)
                {
                    IsFlipping = true;
                    Invoke("BarLeft", 0.5f);
                    Invoke("flipF", 0.5f);
                    Invoke("fals", 0.5f);
                    facingRight = false;
                }

            }
            else if (player.transform.position.x > transform.position.x)
            {
                if (Mathf.Abs(player.transform.position.x - transform.position.x) > (dist - 1) && IsFlipping != true)
                {
                    if (Mathf.Abs(player.transform.position.x - transform.position.x) < dist)
                        transform.position += transform.right * (Time.deltaTime * (Speed - minus));
                    else
                        transform.position += transform.right * (Time.deltaTime * Speed);
                    TankAn.SetBool("IsMoving", true);
                }
                else
                    TankAn.SetBool("IsMoving", false);
                if (facingRight == false)
                {
                    IsFlipping = true;
                    Invoke("BarRight", 0.5f);
                    Invoke("flipT", 0.5f);
                    Invoke("fals", 0.5f);
                    facingRight = true;
                }
            }
        }   
    }
    private void BarRight()
    {
        if (Point != null)
        {
            BarrelSprite.flipY = true;
            Point.transform.localPosition = new Vector3(RbX, bY, 0); //(0.604f, 0.001f, 0);
        }
    }
    private void BarLeft()
    {
        if ( Point != null)
        {
            BarrelSprite.flipY = false;
            Point.transform.localPosition = new Vector3(LbX, bY, 0);//-0.59f, 0.001f, 0);
        }
        
    }
    private void flipF()
    {
        if ( Point!= null)
        {
            tankSprite.flipX = false;
            Point.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void flipT()
    {
        if (Point != null)
        {
            tankSprite.flipX = true;
            Point.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    private void fals()
    {
        IsFlipping = false;
    }
}
