using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Feet") {
            if (collision.transform.parent.GetComponent<Rigidbody2D>().velocity.y < 0) {
                
            print("This is working");
            StartCoroutine(Delay());

            }
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
    }

}
