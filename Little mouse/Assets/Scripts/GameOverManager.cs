using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public AudioSource MainMusic;
    public GameObject Pause;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    private GameObject Camera;
    public int Quantity;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameOverScreen.SetActive(false);
        WinScreen.SetActive(false);
        Quantity = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Bomber").Length + GameObject.FindGameObjectsWithTag("Kamikadze").Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Win()
    {
        string Level = Convert.ToString(SceneManager.GetActiveScene().name);
        string number = "";
        for (int i = 6; i < Level.Length; i++)
        {
            number += Level[i];
        }
        int n = Convert.ToInt32(number);
        int l = PlayerPrefs.GetInt("lastCompletedLevel");
        //string f = PlayerPrefs.GetString("FirstLevelCompleted");
        if (n == 1  )
        {
            PlayerPrefs.SetString("FirstLevelCompleted", "yes");
           // PlayerPrefs.SetInt("UpgradePoints", 1);
        }

        if(n>l)
        {
            int u = PlayerPrefs.GetInt("UpgradePoints");
            int b = u + 1;
            PlayerPrefs.SetInt("lastCompletedLevel", n);
            PlayerPrefs.SetInt("UpgradePoints", b);
        }
        MainMusic.Stop();
        GameOverScreen.SetActive(false);
        WinScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        MainMusic.Stop();
        WinScreen.SetActive(false);
        GameOverScreen.SetActive(true);
    }
    public void ClosePause()
    {
        Camera.GetComponent<LimitFPPS>().IsPaused = false;
        Time.timeScale = 1;
        MainMusic.UnPause();
        Pause.SetActive(false);
    }
}
