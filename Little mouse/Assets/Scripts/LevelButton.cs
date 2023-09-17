using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Text Level;
    private Button but;
    public string LevelNum;
    public int LN;
    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        LevelNum = Level.text;
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetFloat("PlayerDamage", 75);
        //PlayerPrefs.SetInt("PlayerHealth", 300);
        LN = Convert.ToInt32(LevelNum);
        string FLC = PlayerPrefs.GetString("FirstLevelCompleted");

        if (FLC != "yes")
        {
            PlayerPrefs.SetInt("UpgradePoints", 0);
        }
        int Last = PlayerPrefs.GetInt("lastCompletedLevel");
        if ((LN <= Last + 1 && FLC == "yes") || LN == 1)
            but.interactable = true;
        else
            but.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_" + LevelNum); 
    }
}
