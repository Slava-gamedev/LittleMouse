using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float health = 140;
    private float maxHealth;
    public float Healing;
    private float DamFromPlayer;
    private bool colliding=false;
    public GameObject HealthBar;
    public GameObject barrel;
    public Animator death;
    private Vector3 scale;
    public bool isDead = false, longer = false, WasHit=false;
    public GameObject Gear;
    public GearScript Heal;
    private GameOverManager GO;
    public GameObject Tank;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gam_obj = GameObject.Find("Manager");
        GO = gam_obj.GetComponent<GameOverManager>();
        maxHealth = health;
        scale = HealthBar.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        colliding= false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shell" && colliding == false)
        {
            DamFromPlayer = collision.gameObject.GetComponent<ShellBehavior>().Damage;
            health -= DamFromPlayer;
            scale.x = Mathf.Clamp(health / maxHealth, 0, 1);
            HealthBar.transform.localScale = scale;
            colliding = true;
            WasHit= true;

            if (health <= 0 && isDead== false)
            {
                GO.Quantity -= 1;
                isDead = true;
                death.SetBool("IsDead", true);
                Destroy(barrel);
                if(longer==true)
                    Invoke("Dest", 1.2f);
                else
                    Invoke("Dest", 0.7f);
            }

            if (GO.Quantity == 0)
            {
               GO.Invoke("Win", 1f);
            }
        }
    }
    private void Dest()
    {
        GameObject gear = Instantiate(Gear, transform.position, Quaternion.identity);
        gear.GetComponent<GearScript>().HealPower = Healing;
        Destroy(Tank); 
    }

}
