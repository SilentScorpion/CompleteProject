using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    //Reference to the FuzzBall's rigidbody
    Rigidbody2D rigidBody;
    //Check if the FuzzBall is colliding with the ground. Only then can he jump
    bool grounded;
    //Movement speed in x direction
    public float moveSpeed;
    //The original jump speed that is given to the Fuzzball
    public float jumpVelocity;
    //Accelerometer input
    float input;
    //Reference to the Fuzzball's boxcollider
    BoxCollider2D boxCollider;
    //By default, the Fuzzball faces towards the right
    bool facingRight = true;
    //Reference to the Animator component
    Animator playerAnimator;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    bool jump;
    private void Update() {

#if UNITY_EDITOR
        input = Input.GetAxisRaw("Horizontal");

        jump = Input.GetKeyDown(KeyCode.Space);

        if (jump && grounded) {
            //print("Bool set to true");
        }



#elif UNITY_ANDROID && !UNITY_EDITOR
         Vector2 accelerationInput = Input.acceleration.normalized;
        input = accelerationInput.x;
#endif
        rigidBody.velocity = new Vector2(moveSpeed * input, rigidBody.velocity.y);

        playerAnimator.SetFloat("Speed", Mathf.Abs(input));

        if (input > 0 && !facingRight)
            Flip();
        else if (input < 0 && facingRight)
            Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Platform")) {
           // grounded = true;
           // Jump(jumpVelocity);
        }

        else if (collision.collider.CompareTag("Spring")) {
            grounded = true;
            print("I've come here");
            Jump(jumpVelocity + 10f);
        }
    }

    void Jump(float velocity) {
        rigidBody.velocity = new Vector2(0, velocity);
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
