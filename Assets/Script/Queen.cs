using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour {


    public AntAnimator animator;

    Vector2 target;

    bool isWaiting = false;

    // Update is called once per frame
    void Update() {

        if (animator.isWalking == false) {
            if (isWaiting == false) {
                Invoke("StartWalking", 0.5f);
                isWaiting = true;
            }
        } else {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime);
            if (Vector2.Distance(transform.position, target) < 0.05f) {
                animator.isWalking = false;
            }
        }

    }


    void StartWalking() {
        target = Random.insideUnitCircle * 0.8f;
        animator.isWalking = true;
        isWaiting = false;
    }
}
