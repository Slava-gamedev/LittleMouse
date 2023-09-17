using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnShellSpawner : MonoBehaviour
{
    public GameObject Point;
    public GameObject AnotherPoint;
    public GameObject ObjectToSpawn;
    public GameObject ObjectToTakeRotation;
    private float timer = 0f;
    public float distance;
    public float timeBetwFire = 4f;
    public bool canFire = true, behind=false;
    public float moveSpeed = 16f;
    private GameObject player;
    public float ShellDamage;
    public Animator Shoot;
    public SmShellBehaviour SB;
    public SpriteRenderer barrel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (barrel != null && player != null)
        {
            if (AnotherPoint.transform.position.x - player.transform.position.x  < -0.6f && barrel.flipY!= true)
            {
                behind = true;
            }
            else if(AnotherPoint.transform.position.x - player.transform.position.x > 0.6f && barrel.flipY == true )
            {
                behind = true;
            }
            else
            {
                behind = false;
            }
        }
        if (player != null)
            if ( canFire == true && (Vector2.Distance(player.transform.position, transform.position) < distance) && behind !=true)
            {
                Shoot.SetBool("IsShooting", true);
                Invoke("fals", 0.4f);
                Vector3 direct = (Point.transform.position - AnotherPoint.transform.position);
                GameObject Shell = Instantiate(ObjectToSpawn, transform.position, ObjectToTakeRotation.transform.rotation);
                canFire = false;
                Rigidbody2D RB= Shell.GetComponent<Rigidbody2D>();
                Shell.GetComponent<SmShellBehaviour>().Damage= ShellDamage;
                RB.velocity = new Vector3(direct.x, direct.y).normalized * moveSpeed;
            }
    }
    private void fals()
    {
        Shoot.SetBool("IsShooting", false);
    }
}
