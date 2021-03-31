using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;

    string input;
    public bool isRight;

    int randomCounter = 0;
    int randomThreshold = Random.Range(300, 700);

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 10f;
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;

        if(isRightPaddle)
        {
            pos = new Vector2(GameManager.topRight.x,0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else
        {
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }

        transform.position = pos;
        transform.name = input;

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if(transform.position.y < GameManager.bottomLeft.y + height/2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);

        if (randomCounter == randomThreshold)
        {
            speed = Random.Range(0.1f, 100f);
            randomCounter = 0;
            randomThreshold = Random.Range(300, 700);

            Vector2 newScale = transform.localScale;
            newScale *= Random.Range(0.925f, 1.05f);
            transform.localScale = newScale;
        }
        randomCounter++;
    }
}
