using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : MonoBehaviour
{
    public ScoreManager _scoreManager;
    public GameObject fractile;

    public Animator animator;
    public bool isStart = false;

    public Animator retryAnimator;
    public bool isOver = false;

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

    public void Jump() {
        Debug.Log("Jump");
        if (grounded == true || (allowDoubleJump && jumpCount < jumpLimit))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            grounded = false;
            jumpCount++;
            _scoreManager.addScore(1);
            _scoreManager.updateHighScore();

            if (!isStart) {
                isStart = true;
                animator.SetBool("IsStart", true);
            }
        }
    }

    void Die() {
        Debug.Log("Die");
        Instantiate(fractile, transform.position, transform.rotation);
        Destroy(this.gameObject);

        if (!isOver) {
            isOver = true;
            retryAnimator.SetBool("IsOver", true);
        }
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
