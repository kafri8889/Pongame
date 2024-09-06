using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isPlayer2;
    public float speed = 20;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = speed * Time.deltaTime;
        bool isMultiPlayer = GlobalVariable.Get<string>("mode") == "duo";
        Vector2 pos = rigidBody.position;

        // Kontrol paddle menggunakan keyboard (misal untuk multiplayer mode)
        if ((Input.GetKey(KeyCode.W) && !isPlayer2) || (Input.GetKey(KeyCode.UpArrow) && isMultiPlayer && isPlayer2))
        {
            pos.y += movement;
        }
        else if ((Input.GetKey(KeyCode.S) && !isPlayer2) || (Input.GetKey(KeyCode.DownArrow) && isMultiPlayer && isPlayer2))
        {
            pos.y -= movement;
        }

        // Loop untuk memproses setiap sentuhan
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i); // Ambil sentuhan berdasarkan index

            // Konversi posisi sentuhan ke dunia 2D
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Kontrol paddle pemain 1 (bagian kiri layar)
            if (!isPlayer2 && touch.position.x < Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    pos.y = touchPosition.y;
                }
            }

            // Kontrol paddle pemain 2 (bagian kanan layar, jika multiplayer)
            if (isPlayer2 && touch.position.x >= Screen.width / 2 && isMultiPlayer)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    pos.y = touchPosition.y;
                }
            }
        }

        // Batas atas dan bawah
        float upperLimit = 2.72f;  // Sesuaikan dengan posisi batas atas di papan
        float lowerLimit = -2.66f; // Sesuaikan dengan posisi batas bawah di papan

        // Batasi posisi paddle agar tidak melewati batas
        pos.y = Mathf.Clamp(pos.y, lowerLimit, upperLimit);

        // Terapkan posisi baru ke paddle
        rigidBody.MovePosition(pos);
    }

    public void ResetPosition() {
        Vector2 pos = Vector2.zero;

        if (isPlayer2) {
            pos = new Vector2(7.641f, 0.1f);
        } else {
            pos = new Vector2(-7.647f, -0.12f);
        }

        rigidBody.position = pos;
    }
}
