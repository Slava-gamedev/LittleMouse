using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        string CurrentScene = Convert.ToString(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(CurrentScene);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        string Level = Convert.ToString(SceneManager.GetActiveScene().name);
        string number = "";
        for (int i = 6; i < Level.Length; i++)
        {
            number += Level[i];
        }
        int n = Convert.ToInt32(number);
        n+=1;
        string n_level = Convert.ToString(n);
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_" + n_level);
    }
}
