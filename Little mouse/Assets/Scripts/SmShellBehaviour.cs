using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmShellBehaviour : MonoBehaviour
{
    
    public float Damage;
    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
         Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Detector" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "EnemyShell" && collision.gameObject.tag != "SturmShell")
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect,0.6f);
            Destroy(gameObject);
        }
            
    }
}
