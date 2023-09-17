using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
{
    Vector3 MousePosition;
    private Vector3 direction;
    public SpriteRenderer player;
    private float RotationSpeed=40;
    float t;
    public ShellSpawnerScript Sh;
    Quaternion SlowRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Sh.UseBarrel == true)
        {
            t = Time.deltaTime * RotationSpeed;
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = transform.position - MousePosition;
            direction.Normalize();
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //if (player.flipX == false)
            //    Angle = Mathf.Clamp(Angle, -30f, 30f);
            //else
            //    Angle = Mathf.Clamp(Angle, -180f, 90f);
            Quaternion rotate = Quaternion.Euler(0, 0, Angle);
            if (player.flipX == false)
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
            else
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
}
