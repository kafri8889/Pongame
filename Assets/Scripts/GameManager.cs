using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scorePlayer1Text; 
    public TextMeshProUGUI scorePlayer2Text; 
    public Player paddleLeft;
    public Player paddleRight;
    public Ball ball;
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    // Update is called once per frame
    void Update()
    {
        bool isMultiPlayer = GlobalVariable.Get<string>("mode") == "duo";

        if (!isMultiPlayer) {
            PaddleBot();
        }

        scorePlayer1Text.text = scorePlayer1.ToString();
        scorePlayer2Text.text = scorePlayer2.ToString();
    }

    private void PaddleBot() {
        Rigidbody2D rbball = ball.GetComponent<Rigidbody2D>();
        Rigidbody2D rbpr = paddleRight.GetComponent<Rigidbody2D>();
        Vector2 pos = rbpr.position;
        
        pos.y = rbball.position.y;

        // Batas atas dan bawah
        float upperLimit = 2.72f;  // Sesuaikan dengan posisi batas atas di papan
        float lowerLimit = -2.66f; // Sesuaikan dengan posisi batas bawah di papan

        // Batasi posisi paddle agar tidak melewati batas
        pos.y = Mathf.Clamp(pos.y, lowerLimit, upperLimit);

        rbpr.MovePosition(pos);
    }

    // Reset paddle and ball position
    public void ResetPosition() {
        paddleRight.ResetPosition();
        paddleLeft.ResetPosition();
        ball.ResetPosition();
    }
}
