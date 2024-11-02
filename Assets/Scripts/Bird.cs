using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public bool is_dead = false;
    public float velocity = 1.7f;
    public Rigidbody2D rb_2d;
    public GameManager manager_game;
    public GameObject death_screen;
    public bool game_started = false;
    public GameObject start_screen;
    public Text high_score_text;
    public Text score_text;

    private void Start()
    {
        Time.timeScale = 0;
        death_screen.SetActive(false);
        start_screen.SetActive(true);
    }



    void Update()
    {
        if (!game_started)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                game_started = true;
                Time.timeScale = 1; 
                start_screen.SetActive(false);
                high_score_text.gameObject.SetActive(true);
                score_text.gameObject.SetActive(true);

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb_2d.velocity = Vector2.up * velocity;
                FindObjectOfType<SoundManager>().play_click_sound();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("gold"))
        {
            manager_game.update_score();
            Destroy(collision.gameObject);
            FindObjectOfType<SoundManager>().play_coin_sound();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "death")
        {
            is_dead = true;
            Time.timeScale = 0;
            death_screen.SetActive(true);
            Destroy(manager_game.score_text);
            Destroy(manager_game.high_score_text);
            FindObjectOfType<SoundManager>().play_death_sound();

        }
    }
    
}
