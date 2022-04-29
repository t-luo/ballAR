using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScorePoint : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject hoop;
    int score = 0;
    Vector3 ogPos;
    float direction = 0.01f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) {
            score += 1;
            scoreText.text = "Score: " + score;
        }
    }

    void Update()
    {
        if (score > 5)
        {
            Move();
        } else
        {
            ogPos = hoop.transform.position;
        }
    }

    void Move()
    {   
        if (hoop.transform.position.x > ogPos.x + 1)
        {
            direction = -0.01f;
        } else if (hoop.transform.position.x < ogPos.x - 1)
        {
            direction = 0.01f;
        }
        hoop.transform.position = new Vector3(hoop.transform.position.x + direction, hoop.transform.position.y, hoop.transform.position.z);

    }
    
}
