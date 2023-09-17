using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject Shop;
    public GameObject menu;
    public static int health=0, healUp=0, damUp=0,Points=0,avPoints;
    public static float damage=0;
    private string availablePoints;
    public Text Score;
    public UpgradeButton upg1;
    public UpgradeButton upg2;
    public Level2Upgrade l2up1;
    public Level2Upgrade l2up2;
    // Start is called before the first frame update
    void Start()
    {
        avPoints = PlayerPrefs.GetInt("UpgradePoints");
        Points = avPoints;
    }

    // Update is called once per frame
    void Update()
    {
        availablePoints = Points.ToString();
        Score.text = "Your Points: " + availablePoints;
    }
    public void CloseShop()
    {
        avPoints = PlayerPrefs.GetInt("UpgradePoints");
        Points = avPoints; 
        Shop.SetActive(false);
        menu.SetActive(true);
        upg1.canUse = true;
        upg2.canUse = true;
        l2up1.canUse = true;
        l2up2.canUse = true;
    }
    public void OpenShop()
    {
        avPoints = PlayerPrefs.GetInt("UpgradePoints");
        Points = avPoints;
        Shop.SetActive(true);
        menu.SetActive(false);
    }
    public void saveUpgrades()
    {
        if(health != 0 && damage == 0)
        {
            PlayerPrefs.SetInt("HealthUpg", healUp);
            PlayerPrefs.SetInt("PlayerHealth", health);
        }
        else if(health == 0 && damage!=0) 
        {
            PlayerPrefs.SetInt("DamageUpg", damUp);
            PlayerPrefs.SetFloat("PlayerDamage", damage);
        }
        else if (health != 0 && damage!=0)
        {
            PlayerPrefs.SetInt("HealthUpg", healUp);
            PlayerPrefs.SetInt("PlayerHealth", health);
            PlayerPrefs.SetInt("DamageUpg", damUp);
            PlayerPrefs.SetFloat("PlayerDamage", damage);
        }
        PlayerPrefs.SetInt("UpgradePoints", Points);
        Shop.SetActive(false);
        menu.SetActive(true);
        upg1.canUse = true;
        upg2.canUse = true;
        l2up1.canUse = true;
        l2up2.canUse = true;
    }
}
