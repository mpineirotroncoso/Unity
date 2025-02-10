using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) {
            
            float randomx = Random.Range(-100.0f, 100.0f);
            float randomz = Random.Range (-100.0f, 100.0f);

            other.gameObject.GetComponent<Transform>().position = new Vector3(randomx, 100, randomz);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
}
