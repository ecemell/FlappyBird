using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public float zýplama_aralýðý;
    Rigidbody2D rb;
    public TextMeshProUGUI skor_text;
    public float skor;
    public GameObject deadPanel;
    public Button RestartButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        skor = 0;
        RestartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * zýplama_aralýðý;
        }

        skor_text.text = skor.ToString();
    }

    void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "Scorer")
        {
            skor++;
        }
    }

    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "pipe")
        {
            Time.timeScale = 0;
            deadPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
