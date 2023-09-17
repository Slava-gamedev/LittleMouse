using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SturmRotation : MonoBehaviour
{
    private Vector3 direction;
    private GameObject player;
    public float RotationSpeed = 40;
    float t, x, y;
    public GameObject Spawner;
    public SpriteRenderer Tank;
    Quaternion SlowRotation, rotate;
    public EnemyDeath ED;
    private float Angle;
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
        if (Tank.flipX == false && ED.isDead != true)
        {
            if (rotate.eulerAngles.z >= 300 || rotate.eulerAngles.z <= 50)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, rotate, t);
                transform.rotation = SlowRotation;
            }
            else if (rotate.eulerAngles.z > 180)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 300), t);
                transform.rotation = SlowRotation;
            }
            else if (rotate.eulerAngles.z < 180)
            {
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 50), t);
                transform.rotation = SlowRotation;
            }
        }
        else if (ED.isDead != true)
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

