using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehavior : MonoBehaviour
{
    private GameObject Point;
    private GameObject AnotherPoint;
    private GameObject player;
    private Rigidbody2D bul;
    public float moveSpeed = 10f;
    public GameObject explosion;
    public float Damage=50;
    // Start is called before the first frame update
    void Start()
    {
        //int d = 0;
        //d = PlayerPrefs.GetInt("PlayerDamage");
        //if (d > 50)
        //{
        //    Damage = d;
        //}
        player = GameObject.FindGameObjectWithTag("Player");
        Point = GameObject.FindGameObjectWithTag("Point");
        AnotherPoint = GameObject.FindGameObjectWithTag("AnotherPoint");
        bul = GetComponent<Rigidbody2D>();
        Vector3 direct = (Point.transform.position - AnotherPoint.transform.position);
        bul.velocity = new Vector3(direct.x, direct.y).normalized * moveSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 vector = transform.position - player.transform.position;
        float distFromPlayer =Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        if (distFromPlayer > 20)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Detector")
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.6f);
            Destroy(gameObject);
        } 
    }
}
