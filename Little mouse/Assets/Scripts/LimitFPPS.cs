using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LimitFPPS : MonoBehaviour
{
    public GameObject Player;
    private GameObject Win, Over,Canvas;
    public AudioSource MainMusic;
    public GameObject Pause;
    public bool IsPaused=false;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Win = Canvas.transform.Find("Win_Screen").gameObject;
        Over = Canvas.transform.Find("GameOver").gameObject;
        Application.targetFrameRate = 40;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && (!Win.activeSelf) && (!Over.activeSelf))
        {
           MainMusic.Pause();
           Time.timeScale = 0;
           IsPaused= true;
           Pause.SetActive(true);
        }
        if(Player!= null)
          transform.position= new Vector3(Player.transform.position.x, Player.transform.position.y + 4.5f, -10) ;
    }
}
