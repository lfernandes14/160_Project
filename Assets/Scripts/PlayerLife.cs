using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private bool isDead = false;
    [SerializeField] private float reloadDelay = 1.5f;
    [SerializeField] private int dyingYValue = -9;
    [SerializeField] private AudioSource deadSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            //make player disappear
            GetComponent<MeshRenderer>().enabled = false;

            //stop player movement
            GetComponent<PlayerController>().enabled = false;

            //turn off physics (gravity) for the player
            GetComponent<Rigidbody>().isKinematic = false;

            //DIE
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        deadSound.Play();

        Invoke("ReloadScene", reloadDelay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Checks if the player falls off the platform
    /// </summary>
    void Update()
    {
        if (transform.position.y < dyingYValue && !isDead)
        {
            //DIE!
            Die();
        }
    }
}
