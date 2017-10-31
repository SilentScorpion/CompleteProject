using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject platform;
    public int leftRight;
    public bool switchUp;
    public float speed;
    public float maxX;
    public float speedMax;
    public float speedMin;
    public float dir;
    private void OnEnable() {
        leftRight = Random.Range(0, 2);
        if (leftRight == 1) {
            switchUp = true;
        }
        else {
            switchUp = false;
        }
        speed = Random.Range(speedMin, speedMax);
    }

    private void Update() {
        MovementNew();
    }
    
    void Movement() {
        if (platform.transform.position.x >= maxX && switchUp) {
            switchUp = false;
            leftRight = 0;
        }
        else if (platform.transform.position.x <= -maxX && !switchUp) {
            switchUp = true;
            leftRight = 1;
        }
        else {
            if (leftRight == 0) {
                platform.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            }
            else if (leftRight == 1) {
                platform.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            }
        }
    }


    void MovementNew() {
        if (platform != null) {

        if (platform.transform.localPosition.x >= maxX) {
            dir = -1;
        }
        else if (platform.transform.localPosition.x <= -maxX) {
            dir = 1;
        }
        platform.transform.Translate(new Vector3(speed * dir, 0, 0) * Time.deltaTime);
        }
    }
}
