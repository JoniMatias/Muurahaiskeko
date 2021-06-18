using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAnimator : MonoBehaviour {

    public SpriteRenderer body;
    public SpriteRenderer leg1;
    public SpriteRenderer leg2;
    public SpriteRenderer leg3;

    private Vector2 leg1InitPos;
    private Vector2 leg2InitPos;
    private Vector2 leg3InitPos;


    public bool isWalking = false;

    private void Start() {
        leg1InitPos = leg1.transform.localPosition;
        leg2InitPos = leg2.transform.localPosition;
        leg3InitPos = leg3.transform.localPosition;
    }

    void Update() {

        if (isWalking) {
            leg1.transform.localPosition = leg1InitPos + new Vector2(0.05f, 0) * Mathf.Sin(Time.time * 12f);
            leg2.transform.localPosition = leg2InitPos + new Vector2(0.02f, 0) * Mathf.Cos(Time.time * 10f);
            leg3.transform.localPosition = leg3InitPos + new Vector2(0.05f, 0) * Mathf.Sin(Time.time * 9f);
        }

    }
}
