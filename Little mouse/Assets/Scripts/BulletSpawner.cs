using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject Point;
    public GameObject AnotherPoint;
    public GameObject ObjectToTakeRotation;
    private GameObject Camera;
    private float timer = 0f;
    public float timeBetwFire =1f, moveSpeed=1, bulDamage;
    private bool canFire = true;
    public Animator Shoot;
    public ShellSpawnerScript Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire != true)
        {
            timer += Time.deltaTime;
            if (timer > timeBetwFire)
            {
                canFire = true;
                timer = 0f;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && canFire == true && Camera.GetComponent<LimitFPPS>().IsPaused != true && Spawner.UseBarrel == false)
        {
            Vector2  direct=  Point.transform.position - AnotherPoint.transform.position;
            direct.Normalize();
            Shoot.SetBool("IsShooting", true);
            GameObject Bullet = Instantiate(ObjectToSpawn, transform.position, ObjectToTakeRotation.transform.rotation);
            Rigidbody2D Rb= Bullet.GetComponent<Rigidbody2D>();
            Bullet.GetComponent<BulletScript>().Damage = bulDamage;
            Rb.velocity = new Vector2(direct.x, direct.y) * moveSpeed;
            canFire = false;
        }
        else
            Shoot.SetBool("IsShooting", false);
    }
}
