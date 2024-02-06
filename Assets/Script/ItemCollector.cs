using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource collectsound;

    private int score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Banana") || collision.gameObject.CompareTag("Apple"))
        {
            collectsound.Play();
            Destroy(collision.gameObject);
            score++;
            scoreText.text = " Fruits: " + score;

        }
    }
}
