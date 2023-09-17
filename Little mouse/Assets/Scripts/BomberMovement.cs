using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMovement : MonoBehaviour
{
    public float Speed, distance, height;
    private GameObject player;
    private SpriteRenderer Bomber;
    private bool noPoint = true, desiredHeight=false;
    private Vector3 pointToMove, Point1, Point2;
    private float side, timer=0f;
    public Detection Det;
    public PlaneDeath Death;
    public ObstacleDetector OD;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Bomber = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Death.isDead != true && (Det.IsDetected != false))
        {
            Point1 = new Vector3(player.transform.position.x - distance, 0);
            Point2 = new Vector3(player.transform.position.x + distance, 0);
            if (Mathf.Abs(Point1.x - transform.position.x) > Mathf.Abs(Point2.x - transform.position.x) && noPoint == true)
            {
                pointToMove = Point1;
                Bomber.flipX = false;
                noPoint = false;
                side = -1;
            }
            else if (noPoint == true)
            {
                pointToMove = Point2;
                Bomber.flipX = true;
                noPoint = false;
                side = 1;
            }

            if ((transform.position.x >= pointToMove.x && side == -1) || (transform.position.x <= pointToMove.x && side == 1))
            {
                transform.position += side * transform.right * (Time.deltaTime * Speed);
            }
            else
                noPoint = true;

            if(OD.ObstacleDetected == false)
            {
                if (transform.position.y - player.transform.position.y > height && OD.ObstacleDetected == false && desiredHeight == false)
                {
                    transform.position -= transform.up * (Time.deltaTime * Speed);
                }
                else if (transform.position.y - player.transform.position.y < height && desiredHeight == false)
                {
                    transform.position += transform.up * (Time.deltaTime * Speed);
                }
            
                if (transform.position.y - player.transform.position.y > height - 0.5f  && transform.position.y - player.transform.position.y < height + 0.5f && OD.ObstacleDetected == false)
                    desiredHeight = true;
                else
                    desiredHeight= false;
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 0.5f)
                {
                    OD.ObstacleDetected = false;
                    timer = 0f;
                }
                transform.position += transform.up * (Time.deltaTime * Speed);
            }

        }
    }
}
