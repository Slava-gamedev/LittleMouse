using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDeath : MonoBehaviour
{
    public float health = 100;
    private float maxHealth;
    public float Healing;
    public float DamFromPlayer = 5;
    private bool colliding = false, DeadFromPlayer=false;
    public GameObject HealthBar;
    public Animator death;
    private Vector3 scale;
    public bool isDead = false;
    public GameObject Gear;
    public GearScript Heal;
    private GameOverManager GO;
    public GameObject Plane;
    private AudioSource MainMusic;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Music = GameObject.Find("Music");
        MainMusic = Music.GetComponent<AudioSource>();
        GameObject gam_obj = GameObject.Find("Manager");
        GO = gam_obj.GetComponent<GameOverManager>();
        maxHealth = health;
        scale = HealthBar.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        colliding = false;
        scale.x = Mathf.Clamp(health / maxHealth, 0, 1);
        HealthBar.transform.localScale = scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && colliding == false)
        {
            health -= DamFromPlayer;
            colliding = true;
        }
        if (collision.gameObject.tag == "Player" && colliding == false)
        {
            health -= health;
            colliding = true;
            DeadFromPlayer = true;
        }
        if (health <= 0 && isDead == false)
        {
            GO.Quantity -= 1;
            isDead = true;
            if (GO.Quantity != 0 && DeadFromPlayer !=true)
                MainMusic.UnPause();
            death.SetBool("IsDead", true);
            Invoke("Dest", 0.7f);
        }
        if (GO.Quantity == 0)
        {
            GO.Invoke("Win", 1f);
        }
    }
    private void Dest()
    {
        GameObject gear = Instantiate(Gear, transform.position, Quaternion.identity);
        gear.GetComponent<GearScript>().HealPower = Healing;
        Destroy(Plane);
        
    }
}
