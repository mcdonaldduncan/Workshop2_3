using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    Rigidbody rb;
    Transform m_Transform;

    Vector3 moveValue = Vector3.zero;

    bool canJump;
    bool isJumping;

    float score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Transform = transform;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        // This is an example of the old input collection via Update
        // This is not how modern input collection works but it is good to know the simplest version
        // We will cover modern input collection later this semester
        moveValue = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveValue += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveValue += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveValue += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveValue += Vector3.left;
        }

        transform.Translate(moveValue.normalized * moveSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        if (isJumping && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
            canJump = false;
        }

        //rb.AddForce(moveValue * moveSpeed, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collided with ground!");
            canJump = true;
        }
        else
        {
            Debug.Log("Collided with something else!");
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);
            other.gameObject.SetActive(false);

            Instantiate(other.gameObject);
        }
    }

}
