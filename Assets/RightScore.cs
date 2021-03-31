using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScore : MonoBehaviour
{
    public GameObject txt;

    [SerializeField]
    public int rightScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = rightScore.ToString();
    }
    public void updateScore()
    {
        rightScore++;
    }

}