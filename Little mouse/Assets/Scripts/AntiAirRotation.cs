using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirRotation : MonoBehaviour
{
    private Vector3 mouseP;
    public SpriteRenderer gun;
    private Quaternion SlowRotation;
    public float RotationSpeed;
    private float t;
    public ShellSpawnerScript ShSpawn;
    
   // public GameObject bspawn;
    private void Start()
    {

    }
    void Update()
    {
        if (ShSpawn.UseBarrel == false)
        {
            t = Time.deltaTime * RotationSpeed;
            mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direct = (transform.position - mouseP);
            direct.Normalize();
            float Angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            Quaternion rotate = Quaternion.Euler(0, 0, Angle);
            if (rotate.eulerAngles.z > 180 && rotate.eulerAngles.z < 360)
            {
                if ((transform.eulerAngles.z) < 90 || (transform.eulerAngles.z) >= 270)
                {
                    gun.flipY = false;
                    SlowRotation = Quaternion.RotateTowards(transform.rotation, rotate, t);
                    transform.rotation = SlowRotation;
                }
                else if ((transform.eulerAngles.z) < 270 && (transform.eulerAngles.z) > 90)
                {
                    gun.flipY = true;
                    SlowRotation = Quaternion.RotateTowards(transform.rotation, rotate, t);
                    transform.rotation = SlowRotation;
                }
            }
            else if (rotate.eulerAngles.z < 180 && rotate.eulerAngles.z > 90)
            {
                if ((transform.eulerAngles.z) < 270 && (transform.eulerAngles.z) > 90)
                    gun.flipY = true;
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 180), t);
                transform.rotation = SlowRotation;
            }
            else
            {
                if ((transform.eulerAngles.z) < 90 || (transform.eulerAngles.z) >= 270)
                    gun.flipY = false;
                SlowRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), t);
                transform.rotation = SlowRotation;
            }
        }
    }
}
