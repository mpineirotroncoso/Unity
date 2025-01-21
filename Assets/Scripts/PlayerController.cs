using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed = 0; 

    private int count;
    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    public GameObject Bloqueo;

    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        count = 0; 
        SetCountText();
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(SmoothMove(playerTransform.position, new Vector3(playerTransform.position.x, playerTransform.position.y+10, playerTransform.position.z), 0.5f));
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other) 
   {
        Debug.Log("Colision");
        if (other.gameObject.CompareTag("PickUp")) 
       {
            count = count + 1;
            if (count >= 8) {
                Bloqueo.SetActive(false);
            }
            SetCountText();
            other.gameObject.SetActive(false);
       }

       if (other.gameObject.CompareTag("Void")) 
       {
            playerTransform.position = new Vector3(15, 0, 0);
       }

       if (other.gameObject.CompareTag("duck")) {
            //playerTransform.position = new Vector3(0, 100, 0);
            StartCoroutine(SmoothMove(playerTransform.position, new Vector3(0, 100, 0), 2.0f));
       }
   }

    IEnumerator SmoothMove(Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            playerTransform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        playerTransform.position = end;
    }
    
    void SetCountText() 
   {
       countText.text =  "Puntos: " + count.ToString();
        if (count >= 16)
       {
           winTextObject.SetActive(true);
       }
   }
}
