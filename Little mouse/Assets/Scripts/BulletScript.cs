using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Damage;
    public GameObject explosion;
    private Rigidbody2D bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);
        Vector2 vector = bullet.velocity;
        vector.Normalize();
        float Angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, Angle);
        transform.rotation = rotate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Detector" && collision.tag != "Bullet" && collision.tag!="Enemy" )
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.6f);
        }
            
    }
}
