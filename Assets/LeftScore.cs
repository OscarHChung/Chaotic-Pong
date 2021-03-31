using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftScore : MonoBehaviour
{
    public GameObject txt;
    public int leftScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = leftScore.ToString();
    }

    public void updateScore()
    {
        leftScore++;
    }

}
