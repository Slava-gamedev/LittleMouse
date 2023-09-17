using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShellSpawnerScript : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject ObjectToTakeRotation;
    private GameObject Camera;
    public Animator AnBarrel;
    private float timer = 0f;
    public bool UseBarrel = true;
    public float timeBetwFire = 6f;
    private bool canFire = true;
    private float Reload = 0;
    public Image ReloadBar;
    public GameObject Pillar;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire != true)
        {
            timer += Time.deltaTime;
            Reload += Time.deltaTime;
            ReloadBar.fillAmount = Mathf.Clamp(Reload / timeBetwFire, 0, 1);
            if (timer > timeBetwFire)
            {
                canFire = true;
                timer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire == true && Camera.GetComponent<LimitFPPS>().IsPaused != true && UseBarrel == true)
        {
            AnBarrel.SetBool("IsShooting", true);
            Invoke("setF", 0.3f);
            GameObject shell = Instantiate(ObjectToSpawn, transform.position, ObjectToTakeRotation.transform.rotation);

            float d = 0;
            d = PlayerPrefs.GetFloat("PlayerDamage");
            if (d > 50)
            {
                shell.GetComponent<ShellBehavior>().Damage = d;
            }
            canFire = false;
            Reload = 0;
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && Pillar != null)
            UseBarrel = true;
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Pillar != null)
            UseBarrel = false;

    }
    public void setF()
    {
        AnBarrel.SetBool("IsShooting", false);
    }

}
