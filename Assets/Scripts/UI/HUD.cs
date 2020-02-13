using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    static Text scoreText;
    static Text ballsLeftText;
    static int score;
    static int ballsLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ballsLeft = ConfigurationUtils.BallsPerGame;
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>(); 
        scoreText.text = "Score: "+score.ToString();
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>(); 
        ballsLeftText.text = "Balls Left: "+ballsLeft.ToString();
    }

    public static void addScore(int scoreP){
        score += scoreP;
        scoreText.text = "Score: "+score.ToString();
    }

    public static void DiscountBall(){
        ballsLeft -= 1;
        ballsLeftText.text = "Balls Left: "+ballsLeft.ToString();
        if(ballsLeft<0)ballsLeft=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            MenuManager.GoToMenu(MenuName.PAUSE);
        }
    }
}
