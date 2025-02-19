using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotator : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (0, 0, 125) * Time.deltaTime);

            Vector3 tamano = new Vector3(0.5f, 0.5f, 0.5f);

for (int i = 0; i < 1; i++)
{
    GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    bullet.transform.position = playerTransform.position + new Vector3(0, 1, 0);
    bullet.transform.localScale = tamano;
    bullet.AddComponent<Rigidbody>();
    bullet.GetComponent<Rigidbody>().AddForce(playerTransform.up * 1000);
    bullet.GetComponent<Renderer>().material.color = Color.grey;
    bullet.tag = "Bullet";
    bullet.AddComponent<SphereCollider>();
    bullet.GetComponent<SphereCollider>().isTrigger = true;

    Destroy(bullet, 30.0f);
}
    }
}
