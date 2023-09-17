using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnMove : MonoBehaviour
{
    public float Speed;
    private GameObject player;
    private SpriteRenderer tankSprite;
    public SpriteRenderer BarrelSprite;
    private bool facingRight = false;
    private bool IsFlipping = false;
    public Animator TankAn;
    public EnemyDeath EnDeath;
    public GameObject Point;
    public EnShellSpawner ESS;
    public Detection Det;
    public EdgeScript ES;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tankSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && EnDeath.isDead != true && gameObject != null && (Det.IsDetected != false))
        {
            if(ES.EdgeDetected == true)
            {
                if (facingRight == true && (ES.EdgeDetected == true))
                {
                    TankAn.SetBool("IsMoving", true);
                    transform.position += transform.right * (Time.deltaTime * Speed);
                    if (player.transform.position.x + 2 < transform.position.x)
                        ES.EdgeDetected = false;
                }
                if (facingRight == false && (ES.EdgeDetected == true))
                {
                    TankAn.SetBool("IsMoving", true);
                    transform.position -= transform.right * (Time.deltaTime * Speed);
                    if(player.transform.position.x > transform.position.x + 2)
                        ES.EdgeDetected = false;
                }  
            }
            if ((player.transform.position.x < transform.position.x) && ES.EdgeDetected != true)
            {
                if (Mathf.Abs(player.transform.position.x - transform.position.x) < 8 && IsFlipping != true)
                {
                    transform.position += transform.right * (Time.deltaTime * (Speed));
                    TankAn.SetBool("IsMoving", true);
                }
                else if (Mathf.Abs(player.transform.position.x - transform.position.x) > 11 && IsFlipping != true && ESS.canFire == true)
                {
                    transform.position -= transform.right * (Time.deltaTime * (Speed));
                    TankAn.SetBool("IsMoving", true);
                }
                else if (Mathf.Abs(player.transform.position.x - transform.position.x) < 17 && (ESS.canFire == false) && IsFlipping != true)
                {
                    transform.position += transform.right * (Time.deltaTime * (Speed));
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
            else if (player.transform.position.x > transform.position.x && ES.EdgeDetected != true)
            {
                if (Mathf.Abs(player.transform.position.x - transform.position.x) < 8 && IsFlipping != true)
                {
                    transform.position -= transform.right * (Time.deltaTime * (Speed));
                    TankAn.SetBool("IsMoving", true);
                }
                else if (Mathf.Abs(player.transform.position.x - transform.position.x) > 11 && IsFlipping != true && ESS.canFire == true)
                {
                    transform.position += transform.right * (Time.deltaTime * (Speed));
                    TankAn.SetBool("IsMoving", true);
                }
                else if (Mathf.Abs(player.transform.position.x - transform.position.x) < 18 && ESS.canFire == false && IsFlipping != true)
                {
                    transform.position -= transform.right * (Time.deltaTime * (Speed));
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
            Point.transform.localPosition = new Vector3(0.604f, 0.001f, 0);
        }
    }
    private void BarLeft()
    {
        if (Point != null)
        {
            BarrelSprite.flipY = false;
            Point.transform.localPosition = new Vector3(-0.59f, 0.001f, 0);
        }

    }
    private void flipF()
    {
        if (Point != null)
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
