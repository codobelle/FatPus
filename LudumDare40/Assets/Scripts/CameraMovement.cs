using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public static float moveSpeed;
    Transform cameraC;
    float vertical;
    // Use this for initialization
    void Start()
    {
        cameraC = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraC.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }
}
