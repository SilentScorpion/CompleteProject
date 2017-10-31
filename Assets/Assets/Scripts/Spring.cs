using System.Collections;
using UnityEngine;
public class Spring : MonoBehaviour {

    Animator springAnimator;
    public float jumpSpeed;

    private void Start() {
        springAnimator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Feet")) 
        {
            print("Feet collided with spring");
            springAnimator.SetInteger("setActive", 1);
            StartCoroutine(Delay());
            GetComponent<AudioSource>().Play();
            Transform player = collision.transform.parent;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(0.75f);
        springAnimator.SetInteger("setActive", 0);
    }
}
