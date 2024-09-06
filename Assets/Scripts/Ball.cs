using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameManager gm;
    public float speed = 8f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Launch ball with random direction
        // Arah acak untuk bola (antara -1 atau 1 pada sumbu X dan Y)
        float randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        float randomY = Random.Range(0, 2) == 0 ? -1 : 1;

        // Beri kecepatan awal ke bola
        Vector2 randomDirection = new Vector2(randomX, randomY).normalized; // Normalize untuk menjaga arah tetap sama
        rb.velocity = randomDirection * speed; // Set kecepatan bola
    }

    void FixedUpdate()
    {
        // Jaga kecepatan bola tetap konstan
        rb.velocity = rb.velocity.normalized * speed;
    }
    
    public void ResetPosition() {
        rb.velocity = Vector2.zero;
        rb.position = new Vector2(-0.03f, -0.01f);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    { 
        GetComponent<AudioSource>().Play();

        if (collision.gameObject.CompareTag("left_board_barrier")) 
        { 
            gm.scorePlayer2 += 1;
            gm.ResetPosition();
            Start();
        } 
        else if (collision.gameObject.CompareTag("right_board_barrier")) 
        { 
            gm.scorePlayer1 += 1;
            gm.ResetPosition();
            Start();
        } 
    }
}
