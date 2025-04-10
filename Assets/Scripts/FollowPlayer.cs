using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    /// <summary>
    /// Happens a fraction of a second after Update & FixedUpdate
    /// </summary>
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
