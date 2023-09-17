using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject Point;
    private float timer = 0f;
    public float distance, time, BombDamage;
    public float timeBetwFire = 4f;
    private float X, Y;
    public bool canFire = true;
    public float moveSpeed = 16f;
    private GameObject player;
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
                X = (player.transform.position.x - Point.transform.position.x) / time;
                GameObject Bomb = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
                canFire = false;
                Y = (player.transform.position.y - Point.transform.position.y) * 0.9f + (time * 10) / 2;
                Rigidbody2D RB = Bomb.GetComponent<Rigidbody2D>();
                Bomb.GetComponent<SturmShellBehaviour>().Damage = BombDamage;
                RB.velocity = new Vector3(X, Y) * moveSpeed;
                
            }
        }
    }
}
