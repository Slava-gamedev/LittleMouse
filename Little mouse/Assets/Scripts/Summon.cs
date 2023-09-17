using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public EnemyDeath RD;
    public float cheatingTime=10f;
    private float timer = 0f;
    private int WaveCount = 0;
    private bool inBlindZone = false;
    public Transform[] spawn=new Transform[10];
    private GameObject player;
    public Animator help;
    public GameOverManager GOV;
    public GameObject SimpleTiger;
    public GameObject SmartTiger;
    public GameObject TankTank;
    public GameObject DickerMax;
    public GameObject SturmTiger;
    public GameObject Bomber;
    public GameObject Kamikadze;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (inBlindZone == true)
        {
            timer += Time.deltaTime;
        }
        if(player!= null && RD.health<1000) 
        {
            if (RD.health > 900 && WaveCount == 0)
            {
                help.SetBool("SOS", true);
                Invoke("fals", 1);
                FirstWave(); 
            }
            if (RD.health < 775 && WaveCount == 1)
            {
                help.SetBool("SOS", true);
                Invoke("fals", 1);
                SecondWave();
            }
            if (RD.health < 625 && WaveCount == 2)
            {
                help.SetBool("SOS", true);
                Invoke("fals", 1);
                ThirdWave();
            }
            if (RD.health < 475 && WaveCount == 3)
            {
                help.SetBool("SOS", true);
                Invoke("fals", 1);
                FourthWave();
            }
            if (RD.health < 325 && WaveCount == 4)
            {
                help.SetBool("SOS", true);
                Invoke("fals", 1);
                FifthWave();
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inBlindZone = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inBlindZone = false;
            timer = 0f;
        }

    }
    private void FirstWave()
    {
        if(player.transform.position.x > transform.position.x)
        {
            Instantiate(SturmTiger, spawn[0].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(SturmTiger, spawn[3].transform.position, Quaternion.identity);
        }
        WaveCount++;
        GOV.Quantity++;
    }
    private void SecondWave()
    {
        if (player.transform.position.x > transform.position.x)
        {
            Instantiate(SturmTiger, spawn[0].transform.position, Quaternion.identity);
            Instantiate(SimpleTiger, spawn[1].transform.position, Quaternion.identity);
            Instantiate(SimpleTiger, spawn[2].transform.position, Quaternion.identity);
            if(timer > cheatingTime)
                Instantiate(Bomber, spawn[7].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(SturmTiger, spawn[3].transform.position, Quaternion.identity);
            Instantiate(SimpleTiger, spawn[4].transform.position, Quaternion.identity);
            Instantiate(SimpleTiger, spawn[5].transform.position, Quaternion.identity);
            if (timer > cheatingTime)
                Instantiate(Bomber, spawn[8].transform.position, Quaternion.identity);
        }
        WaveCount++;
        GOV.Quantity += 3;
    }
    private void ThirdWave()
    {
        if (player.transform.position.x > transform.position.x)
        {
            Instantiate(SturmTiger, spawn[0].transform.position, Quaternion.identity);
            Instantiate(SmartTiger, spawn[1].transform.position, Quaternion.identity);
            Instantiate(SimpleTiger, spawn[2].transform.position, Quaternion.identity);
            if (timer > cheatingTime)
                Instantiate(Bomber, spawn[7].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(SturmTiger, spawn[3].transform.position, Quaternion.identity);
            Instantiate(SmartTiger, spawn[4].transform.position, Quaternion.identity);
            Instantiate(SimpleTiger, spawn[5].transform.position, Quaternion.identity);
            if (timer > cheatingTime)
                Instantiate(Bomber, spawn[8].transform.position, Quaternion.identity);
        }
        WaveCount++;
        GOV.Quantity += 3;
    }
    private void FourthWave()
    {
        if (player.transform.position.x > transform.position.x)
        {
            Instantiate(SturmTiger, spawn[0].transform.position, Quaternion.identity);
            Instantiate(SmartTiger, spawn[1].transform.position, Quaternion.identity);
            Instantiate(TankTank, spawn[2].transform.position, Quaternion.identity);
            if (timer > cheatingTime)
                Instantiate(Bomber, spawn[7].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(SturmTiger, spawn[3].transform.position, Quaternion.identity);
            Instantiate(SmartTiger, spawn[4].transform.position, Quaternion.identity);
            Instantiate(TankTank, spawn[5].transform.position, Quaternion.identity);
            if (timer > cheatingTime)
                Instantiate(Bomber, spawn[8].transform.position, Quaternion.identity);
        }
        WaveCount++;
        GOV.Quantity += 3;
    }
    private void FifthWave()
    {
        if (player.transform.position.x > transform.position.x)
        {
            Instantiate(SturmTiger, spawn[0].transform.position, Quaternion.identity);
            Instantiate(DickerMax, spawn[1].transform.position, Quaternion.identity);
            Instantiate(TankTank, spawn[2].transform.position, Quaternion.identity);
            if (timer > cheatingTime)
                Instantiate(Bomber, spawn[7].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(SturmTiger, spawn[3].transform.position, Quaternion.identity);
            Instantiate(DickerMax, spawn[4].transform.position, Quaternion.identity);
            Instantiate(TankTank, spawn[5].transform.position, Quaternion.identity);
            if (timer > cheatingTime)
                Instantiate(Bomber, spawn[8].transform.position, Quaternion.identity);
        }
        WaveCount++;
        GOV.Quantity += 3;
    }
    private void fals()
    {
        help.SetBool("SOS", false);
    }
}
