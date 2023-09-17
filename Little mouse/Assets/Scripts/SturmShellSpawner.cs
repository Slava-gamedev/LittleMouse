using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SturmShellSpawner : MonoBehaviour
{
    public GameObject Point;
    public GameObject ObjectToSpawn;
    public GameObject ObjectToTakeRotation;
    private float timer = 0f;
    public float distance, time, CloseTime, ShellDamage, CloseShellDamage;
    public float timeBetwFire = 4f;
    private float X, Y;
    public bool canFire = true;
    public float moveSpeed = 16f;
    private GameObject player;
    public Animator Shoot;
    public Detection Det;
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
        if (player != null && (Det.IsDetected != false))
        {
            if (canFire == true && (Vector2.Distance(player.transform.position, transform.position) < distance))
            {
                if (Vector2.Distance(player.transform.position, transform.position) < 20)
                {
                    X = (player.transform.position.x - Point.transform.position.x) / CloseTime;
                    Shoot.SetBool("IsShooting", true);
                    Invoke("fals", 0.35f);
                    GameObject Shell = Instantiate(ObjectToSpawn, transform.position, ObjectToTakeRotation.transform.rotation);
                    canFire = false;
                    Y = (player.transform.position.y - Point.transform.position.y) * 0.9f + (CloseTime * 10) / 2;
                    Rigidbody2D RB = Shell.GetComponent<Rigidbody2D>();
                    Shell.GetComponent<SturmShellBehaviour>().Damage = CloseShellDamage;
                    RB.velocity = new Vector3(X, Y) * moveSpeed;
                }
                else
                {
                    X = ( player.transform.position.x - Point.transform.position.x) / time;
                    Shoot.SetBool("IsShooting", true);
                    Invoke("fals", 0.35f);
                    GameObject Shell = Instantiate(ObjectToSpawn, transform.position, ObjectToTakeRotation.transform.rotation);
                    canFire = false;
                    Y = (player.transform.position.y - Point.transform.position.y) * 0.3f + (time * 10) / 2;
                    Rigidbody2D RB = Shell.GetComponent<Rigidbody2D>();
                    Shell.GetComponent<SturmShellBehaviour>().Damage = ShellDamage;
                    RB.velocity = new Vector3(X, Y) * moveSpeed;
                }
            }
            //revX = (Point.transform.position.x - player.transform.position.x) / CloseTime;
            //revY = (Point.transform.position.y - player.transform.position.y) * 0.3f + (CloseTime * 10) / 2;
        }
    }
    private void fals()
    {
        Shoot.SetBool("IsShooting", false);
    }
}
