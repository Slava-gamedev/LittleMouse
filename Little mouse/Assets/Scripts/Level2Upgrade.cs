using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Upgrade : MonoBehaviour
{
    private Button button;
    private string nam;
    public int requiredPoints;
    public bool canUse = true;
    // Start is called before the first frame update
    void Start()
    {
        nam= gameObject.name;
        button = GetComponent<Button>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopManager.Points < requiredPoints || (nam == "Health2" && PlayerPrefs.GetInt("HealthUpg") > 1) || (nam == "Damage2" && PlayerPrefs.GetInt("DamageUpg") > 1) || canUse==false)
        {
            button.interactable = false;
        }
        else if (ShopManager.Points >= requiredPoints || (nam == "Health2" && PlayerPrefs.GetInt("HealthUpg") == 1) || (nam == "Damage2" && PlayerPrefs.GetInt("DamageUpg") == 1))
            button.interactable = true;
    }
    public void level2()
    {

        switch (nam)
        {
            case "Health2":
                ShopManager.health = 300;
                ShopManager.healUp = 2;
                ShopManager.Points -= 5;
                //PlayerPrefs.SetInt("HealthUpg", 2);
                //PlayerPrefs.SetInt("PlayerHealth", 300);
                button.interactable = false;
                break;
            case "Damage2":
                ShopManager.damage = 75;
                ShopManager.damUp = 2;
                ShopManager.Points -= 5;
                //PlayerPrefs.SetInt("DamageUpg", 2);
                //PlayerPrefs.SetFloat("PlayerDamage", 75);
                button.interactable = false;
                break;
        }
        canUse= false;
    }
}