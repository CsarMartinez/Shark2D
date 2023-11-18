using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public BoxCollider2D foodSpawn;
    public float score;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        RandomPose();
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;

        if(score >= 3000)
        {
            scoreText.color = Color.red;
        }
        else if (score >= 2000)
        {
            scoreText.color = Color.blue;
        }
        else if (score >= 1000)
        {
            scoreText.color = Color.yellow;
        }
        else{
            scoreText.color = Color.white;
        }
        if(score == 1000)
        {
            scoreText.color = Color.yellow;
            scoreText.text = "Score: " + score + " ¡¡¡¡¡FIRST BLOOD!!!!";

        }

        if(score == 2000)
        {
            scoreText.color = Color.blue;
            scoreText.text = "Score: " + score + "  ¡¡¡¡¡ULTRA KILL!!!!";
        }

        if(score == 3000)
        {
            scoreText.color = Color.red;
            scoreText.text = "Score: " + score + "  ¡¡¡¡¡RAMPAGE!!!!";
        }
    }

    private void RandomPose()
    {
        Bounds bounds = this.foodSpawn.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            RandomPose();
            score += 100;
        }
      
    }


}
