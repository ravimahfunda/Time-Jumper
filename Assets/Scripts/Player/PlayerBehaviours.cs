using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : MonoBehaviour
{
    public GameObject fractile;

    public float jumpPower;
    public bool allowDoubleJump;

    private bool grounded = true;
    private bool isGrounded;
    private int jumpCount;
    private const int jumpLimit = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void Jump() {
        Debug.Log("Jump");
        if (grounded == true || (allowDoubleJump && jumpCount < jumpLimit))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            grounded = false;
            jumpCount++;
        }
    }

    void Die() {
        Debug.Log("Die");
        Instantiate(fractile, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arm")) {
            Die();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            jumpCount = 0;
        }
    }


}
