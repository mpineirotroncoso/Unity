using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1st : MonoBehaviour
{
    public GameObject quack;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = quack.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        Vector3 quackRotation = quack.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, quackRotation.y, currentRotation.z);
    }
}
