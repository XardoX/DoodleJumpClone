using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D m_Rigidbody;
    public float m_jumpPower = 20.3f;
    public float m_moveSpeed = 5f;

    int zmiennaA = 2; //integer inaczej liczba całkowita

    bool zmiennaB = true; //przyjmuje wartośći true lub false

    string zmiennaC = "Zmienna tekstowa";

    [SerializeField]
    float horizontalInput;

    [SerializeField]
    float groundCheckDistance;

    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    bool isGrounded = false;

    int jumpCount;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        CheckIfGrounded();
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.position + new Vector3(horizontalInput * m_moveSpeed * Time.deltaTime, 0f, 0f);
        transform.position = newPosition;
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount<1)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            jumpCount++;
            m_Rigidbody.AddForce(transform.up * m_jumpPower, ForceMode2D.Impulse);
        }



    }

    void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - Vector3.up*0.05f, -Vector2.up, groundCheckDistance, groundMask);
        
        Debug.DrawRay(transform.position - Vector3.up * 0.05f, -Vector2.up * groundCheckDistance, Color.magenta);

        // If it hits something...
        if (hit.collider != null)
        {
            isGrounded = true;
            jumpCount = 0;
        } else
        {
            isGrounded = false;
        }

    }
}
