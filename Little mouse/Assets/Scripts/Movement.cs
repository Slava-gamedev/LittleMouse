using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public LeftScript LS;
    public RightScript RS;
    public GameObject Trigger;
    public SpriteRenderer tankSprite;
    public SpriteRenderer barrel;
    private bool facingRight = false;
    private bool IsFlipping=false;
    public Animator TankAn;
    public GameObject Point;
    public PlayerDeath PD;
    public GameObject Pillar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && IsFlipping!=true && PD.dead !=true && LS.CanMoveLeft==true)
        {
            transform.position -= transform.right * (Time.deltaTime * Speed);
            TankAn.SetBool("IsMoving", true);
        }
        else if (Input.GetKey(KeyCode.D) && IsFlipping != true && PD.dead != true && RS.CanMoveRight == true)
        {
            transform.position += transform.right * (Time.deltaTime * Speed);
            TankAn.SetBool("IsMoving", true); 
        }
        else
            TankAn.SetBool("IsMoving", false);
        if(Input.GetKeyDown(KeyCode.S) && PD.dead != true)
        {
            if (facingRight == true)
            {
                IsFlipping = true;
                Invoke("BarLeft", 1);
                Invoke("flipF", 1);
                Invoke("fals", 1);
                facingRight = false;
            }
            else
            {
                IsFlipping = true;
                Invoke("BarRight", 1);
                Invoke("flipT", 1);
                Invoke("fals", 1);
                facingRight = true;
            }
        }
    }
    private void BarRight()
    {
        if (Trigger != null && Point !=null)
        {
            Trigger.transform.localPosition = new Vector3(-0.81f, 0, 0);
            Point.transform.localPosition = new Vector3(0.45f, 0.13f, 0);
        }
        if(Pillar!= null)
            Pillar.transform.localPosition = new Vector3(-0.43f, 0.558f, 0);
    }
    private void BarLeft()
    {
        if (Trigger != null && Point != null)
        {
            Trigger.transform.localPosition = new Vector3(0, 0, 0);
            Point.transform.localPosition = new Vector3(-0.47f, 0.13f, 0);
        }
        if (Pillar != null)
            Pillar.transform.localPosition = new Vector3(0.56f, 0.558f, 0);
    }
    private void flipF()
    {
        if ( Point != null)
        {
            tankSprite.flipX = false;
            barrel.flipY = false;
            Point.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }
    private void flipT()
    {
        if (Point != null)
        {
            tankSprite.flipX = true;
            barrel.flipY = true;
            Point.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    private void fals()
    { 
        IsFlipping = false; 
    }
}
