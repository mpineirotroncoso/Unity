using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    private Transform elevatorTransform;
    // Start is called before the first frame update
    void Start()
    {
        elevatorTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool isMoving = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isMoving)
        {
            // subir el elevador
            StartCoroutine(SmoothMove(elevatorTransform.position, new Vector3(elevatorTransform.position.x, 27, elevatorTransform.position.z), 10));
        }
    }

    IEnumerator SmoothMove(Vector3 start, Vector3 end, float duration)
    {
        isMoving = true;

        float elapsed = 0;
        while (elapsed < duration)
        {
            elevatorTransform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        elevatorTransform.position = end;

        // esperar
        yield return new WaitForSeconds(5);

        // bajar el elevador
        elapsed = 0;
        while (elapsed < duration)
        {
            elevatorTransform.position = Vector3.Lerp(end, start, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        elevatorTransform.position = start;

        isMoving = false;
    }
}
