using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float jumpValue = 5f;
    [SerializeField] private float playerSpeed = 10f;

    private Rigidbody rb;
    private Vector3 playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput.currentActionMap.Enable();
    }

    /// <summary>
    /// Gets called from Unity not code, makes the object jump vertically
    /// </summary>
    void OnJump()
    {
        rb.velocity = new Vector3(0, jumpValue, 0);
    }

    /// <summary>
    /// Gets the value from the keyboard and updates the movement variable
    /// </summary>
    /// <param name="iValue">value read in from the keyboard</param>
    void OnMove(InputValue iValue)
    {
        Vector2 inputMovement = iValue.Get<Vector2>();
        playerMovement.x = inputMovement.x * playerSpeed;
        playerMovement.z = inputMovement.y * playerSpeed;
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    void Update()
    {
        rb.velocity = new Vector3(playerMovement.x, rb.velocity.y, playerMovement.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the player collides (jumps on) the enemy's head
        if(collision.gameObject.CompareTag("EnemyHead"))
        {
            //destroy the parent
            Destroy(collision.transform.parent.gameObject);
            OnJump();
        }
    }
}
