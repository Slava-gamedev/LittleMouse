using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherButtonManager : MonoBehaviour
{
    public GameObject ScrollArea;
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openScroll()
    {
        ScrollArea.SetActive(true);
        Menu.SetActive(false);
    }
    public void closeScroll()
    {
        ScrollArea.SetActive(false);
        Menu.SetActive(true);
    }
}
