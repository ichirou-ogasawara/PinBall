using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    private float visiblePosZ = -6.5f;
    private int score = 0; //得点計算用変数

    private GameObject gameoverText;
    private GameObject scoreText; //得点表示用変数

    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
        this.scoreText.GetComponent<Text> ().text = "Score:" + this.score.ToString(); //初期得点を表示
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag; //tagを変数として宣言

        if (yourTag == "SmallStarTag")
        {
            this.score += 10;
        }
        else if (yourTag == "LargeStarTag")
        {
            this.score += 20;
        }
        else if (yourTag == "SmallCloudTag")
        {
            this.score += 30;
        }
        else if (yourTag == "LargeCloudTag")
        {
            this.score += 50;
        }

        this.scoreText.GetComponent<Text> ().text = "Score:" + this.score.ToString(); //計算した得点を表示

    }
    
}
