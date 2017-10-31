using System.Collections;
using UnityEngine;

public class RightSide : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Player") {
            collision.gameObject.transform.position = new Vector3(-2.9f,collision.gameObject.transform.position.y,0);
        }
    }
}
