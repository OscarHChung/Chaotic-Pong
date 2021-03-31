using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    int randomThreshold = Random.Range(500, 1500);
    int randomCounter = 0;

    // Start is called before the first frame update
    void Start()
    {

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);

        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true); //right
        paddle2.Init(false); //left

    }

    // Update is called once per frame
    void Update()
    {
        //randomness time
        if (randomCounter == randomThreshold)
        {
            Instantiate(ball);
            randomCounter = 0;
            randomThreshold = Random.Range(2000, 7000);
        }
        randomCounter++;
    }
}
