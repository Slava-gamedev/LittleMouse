using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    private float health = 200;
    private float maxHealth;
    private float DamFromEnemy;
    private bool colliding=false;
    public bool dead = false;
    public Image HealthBar;
    public Animator Death;
    public GameObject Barrel;
    public GameObject AntiAir;
    public GameOverManager BTM;
    private  float HealP;
    // Start is called before the first frame update
    void Start()
    {
        int h;
        h = PlayerPrefs.GetInt("PlayerHealth");
        if (h > 200)
        {
            health = h;
        }
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        colliding = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "EnemyShell" && colliding == false))
        {
            DamFromEnemy = collision.gameObject.GetComponent<SmShellBehaviour>().Damage;
            health -= DamFromEnemy;
            colliding = true;
            HealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }
        else if (collision.gameObject.tag == "SturmShell" && colliding == false)
        {
            DamFromEnemy = collision.gameObject.GetComponent<SturmShellBehaviour>().Damage;
            health -= DamFromEnemy;
            colliding = true;
            HealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }
        else if (collision.gameObject.tag == "Kamikadze" && colliding == false)
        {
            health -= health;
            colliding = true;
            HealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }
        if (health <= 0)
        {
            if(AntiAir!= null)
                Destroy(AntiAir);
            dead= true;
            Death.SetBool("IsDead", true);
            Destroy(Barrel);
            Invoke("death", 1f);
        }
        if(collision.gameObject.tag == "Gear" && colliding == false)
        {
            colliding = true;
            HealP = collision.gameObject.GetComponent<GearScript>().HealPower;
            health = Mathf.Clamp((health + HealP), 0, maxHealth);
            HealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
            Destroy(collision.gameObject);
        }    
    }
    private void death()
    {
        Destroy(gameObject);
        BTM.GameOver();
    }
}
