using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;

    float radius;
    Vector2 direction;
    Color c;
    int randomCounter = 0;
    int randomThreshold = Random.Range(100, 500);

    int randomCounterTwo = 0;
    int randomThresholdTwo = Random.Range(200, 600);

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        radius = transform.localScale.x / 2;
        GetComponent<Renderer>().material.color = Color.white;
    }

    void Recenter()
    {
        transform.position = new Vector2(0, 0);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        speed = Random.Range(2f, 12f);

        Vector2 newScale = transform.localScale;
        newScale *= Random.Range(0.5f, 1.5f);
        transform.localScale = newScale;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        //ball hits top or bottom wall
        if((transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) || (transform.position.y > GameManager.topRight.y - radius && direction.y > 0))
        {
            direction.y = -direction.y;

            c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            GetComponent<Renderer>().material.color = c;
            speed = Random.Range(2f, 12f);
        }

        //ball enters left or right wall
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            GameObject.FindWithTag("RightScore").GetComponent<RightScore>().updateScore();
            Recenter();
            SoundManagerScript.PlayRandomSound();
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            GameObject.FindWithTag("LeftScore").GetComponent<LeftScore>().updateScore();
            Recenter();
            SoundManagerScript.PlayRandomSound();
        }

        //randomness time
        if(randomCounter == randomThreshold)
        {
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            speed = Random.Range(2f, 12f);
            randomCounter = 0;
            randomThreshold = Random.Range(100, 500);
        }
        randomCounter++;

        if (randomCounterTwo == randomThresholdTwo)
        {
            Vector2 newScale = transform.localScale;
            newScale *= Random.Range(0.5f, 1.5f);
            transform.localScale = newScale;
            radius = transform.localScale.x / 2;
            randomCounterTwo = 0;
            randomThresholdTwo = Random.Range(200, 600);
        }
        randomCounterTwo++;
    }

    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<Renderer>().material.color = c;
        speed = Random.Range(2f, 12f);

        if (otherCollision.tag == "Paddle")
        {
            bool isRight = otherCollision.GetComponent<Paddle>().isRight;

            if(isRight && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}
