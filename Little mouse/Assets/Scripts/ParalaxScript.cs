using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour
{
    private GameObject cam;
    public float paralax_speed, mnoj,dovs;
    private float Start_point, length;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        Start_point = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float mov = (cam.transform.position.x * (1 - paralax_speed));
        float distance = cam.transform.position.x * paralax_speed;      
        if (mov > Start_point + dovs * length /*cam.transform.position.x - Start_point > 2.4f * length*/)
        {
            Start_point += mnoj * length;
           // transform.position = new Vector3(Start_point, transform.position.y, transform.position.z);
        }
        else if (mov < Start_point - dovs * length /*Start_point - cam.transform.position.x > 2.4f * length*/)
        {
            Start_point -= mnoj * length;
            //transform.position = new Vector3(Start_point, transform.position.y, transform.position.z);
        }
        transform.position = new Vector3(Start_point + distance, transform.position.y, transform.position.z);
    }
}
