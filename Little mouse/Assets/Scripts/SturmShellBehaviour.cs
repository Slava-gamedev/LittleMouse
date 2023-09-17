using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturmShellBehaviour : MonoBehaviour
{
    private Rigidbody2D Shell;
    private SpriteRenderer ShellSprite;
    public float Damage;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Shell= GetComponent<Rigidbody2D>();
        ShellSprite = GetComponent<SpriteRenderer>();
        ShellSprite.flipX = true;
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 vector= Shell.velocity;
        vector.Normalize();
        float Angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, Angle);
        transform.rotation = rotate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Detector" && collision.gameObject.tag != "SturmShell" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Bomber" && collision.gameObject.tag != "EnemyShell" )
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.6f);
            Destroy(gameObject);
        }

    }
}
