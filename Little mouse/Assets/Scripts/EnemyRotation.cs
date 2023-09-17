using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    private GameObject player;
    private Vector3 direction;
    public float RotationSpeed = 40;
    float t;
    public SpriteRenderer Tank;
    public SpriteRenderer barrel;
    Quaternion SlowRotation;
    public EnemyDeath ED;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        t = Time.deltaTime * RotationSpeed;
        if (player != null) 
            direction = transform.position - player.transform.position;
        direction.Normalize();
        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, Angle);
        if (Tank.flipX == false && ED.isDead != true && barrel==null)
        {
            if (rotate.eulerAngles.z >= 330 || rotate.eulerAngles.z <= 30)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, rotate, t);
                transform.rotation = SlowRotation;
            }
            else if (rotate.eulerAngles.z > 180)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 330), t);
                transform.rotation = SlowRotation;
            }
            else if (rotate.eulerAngles.z < 180)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 30), t);
                transform.rotation = SlowRotation;
            }
        }
        else if((Tank.flipX == true || barrel!=null) && ED.isDead != true)
        {
            if (rotate.eulerAngles.z >= 150 && rotate.eulerAngles.z <= 210)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, rotate, t);
                transform.rotation = SlowRotation;
            }
            else if (rotate.eulerAngles.z < 150)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 150), t);
                transform.rotation = SlowRotation;
            }
            else if (rotate.eulerAngles.z > 210)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 210), t);
                transform.rotation = SlowRotation;
            }
        }
    }
    
}
