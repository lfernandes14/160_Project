using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xSpeed * 360 * Time.deltaTime, ySpeed * 360 * Time.deltaTime, zSpeed * 360 * Time.deltaTime);
    }
}
