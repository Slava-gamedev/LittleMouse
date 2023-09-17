using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealThrow : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float CloseTime, Healing;
    private float X, Y;
    public bool canFire = false;
    public float moveSpeed = 16f;
    private GameObject player;
    public EnemyDeath RatDeath;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if(RatDeath.WasHit==true)
            {
                canFire = true;
            }
            if (canFire == true)
            {
                X = (player.transform.position.x - transform.position.x) / CloseTime;
                GameObject gear = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
                canFire = false;
                Y = (player.transform.position.y - transform.position.y) * 0.9f + (CloseTime * 10) / 2;
                Rigidbody2D RB = gear.GetComponent<Rigidbody2D>();
                gear.GetComponent<GearScript>().HealPower = Healing;
                RB.velocity = new Vector3(X, Y) * moveSpeed;
                RatDeath.WasHit = false;
            }
        }
    }
}
