using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioSource collectSound;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider thingIHit)
    {
        if(thingIHit.gameObject.CompareTag("Coin"))
        {
            //update score
            score += 100;
            collectSound.Play();
            UpdateScoreText();

            //destroy aka collect the coin
            Destroy(thingIHit.gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
