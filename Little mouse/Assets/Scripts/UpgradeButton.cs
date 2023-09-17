using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private Button button;
    public int requiredPoints;
    private string nam;
    public  bool canUse=true;
    // Start is called before the first frame update
    void Start()
    {
        nam = gameObject.name;
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopManager.Points < requiredPoints || (nam == "Health1" && PlayerPrefs.GetInt("HealthUpg") >= 1) || (nam == "Damage1" && PlayerPrefs.GetInt("DamageUpg") >= 1) || canUse==false)
        {
            button.interactable = false;
        }
        else if (ShopManager.Points >= requiredPoints || (nam == "Health1" && PlayerPrefs.GetInt("HealthUpg") < 1) || (nam == "Damage1" && PlayerPrefs.GetInt("DamageUpg") < 1))
            button.interactable = true;
    }
    public void level1()
    {
        switch(nam)
        {
            case "Health1":
                ShopManager.health = 250;
                ShopManager.healUp = 1;
                ShopManager.Points -= 2;
                //PlayerPrefs.SetInt("HealthUpg",1);
                //PlayerPrefs.SetInt("PlayerHealth", 250);
                button.interactable = false;
                break;
            case "Damage1":
                ShopManager.damage = 63;
                ShopManager.damUp = 1;
                ShopManager.Points -= 2;
                //PlayerPrefs.SetInt("DamageUpg", 1);
                //PlayerPrefs.SetFloat("PlayerDamage", 62.5f);
                button.interactable = false;
                break;
        }
        canUse= false;
    }
}
