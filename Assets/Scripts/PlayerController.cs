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

    public Camera mainCamera;

    public Camera thirdPersonCamera;

    public VirtualJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        mainCamera.enabled = true;
        thirdPersonCamera.enabled = false;
        Application.targetFrameRate = 120;
    }


    private void FixedUpdate()
    {
        // Capturar input del teclado
        float moveX = Input.GetAxis("Horizontal"); // Teclas A/D o Flechas izquierda/derecha
        float moveY = Input.GetAxis("Vertical");   // Teclas W/S o Flechas arriba/abajo

        // Capturar input del joystick
        Vector2 joystickInput = joystick.GetInput();

        // Combinar ambos inputs
        float finalX = (moveX != 0) ? moveX : joystickInput.x;
        float finalY = (moveY != 0) ? moveY : joystickInput.y;

        // Comprobar qué cámara está activada
        if (mainCamera.enabled)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;

            // Asegurar que solo se mueva en el plano horizontal
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Aplicar movimiento basado en la orientación de la cámara
            Vector3 movement = cameraForward * finalY + cameraRight * finalX;
            rb.AddForce(movement * speed);
        }
        else
        {
            // Modo tercera persona
            Vector3 movement = new Vector3(finalX, 0.0f, finalY);
            rb.AddForce(movement * speed);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(SmoothMove(playerTransform.position, new Vector3(playerTransform.position.x, playerTransform.position.y + 10, playerTransform.position.z), 0.5f));
        }

        // cambiar camara con C
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // disparar objeto
            Debug.Log("Disparar");
            Disparar();

        }
    }

    public void ToggleCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
    }

    public void Disparar()
    {
        Vector3 tamano = new Vector3(0.5f, 0.5f, 0.5f);

        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.position = playerTransform.position + new Vector3(0, 1, 0);
            bullet.transform.localScale = tamano;
            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * 1000);
            bullet.tag = "Bullet";
            bullet.AddComponent<SphereCollider>();
            bullet.GetComponent<SphereCollider>().isTrigger = true;
            Destroy(bullet, 30.0f);
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
            if (count >= 8)
            {
                Bloqueo.SetActive(false);
            }
            SetCountText();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Void"))
        {
            playerTransform.position = new Vector3(15, 0, 0);
        }

        if (other.gameObject.CompareTag("duck"))
        {
            //playerTransform.position = new Vector3(0, 100, 0);
            StartCoroutine(SmoothMove(playerTransform.position, new Vector3(0, 100, 0), 2.0f));
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //StartCoroutine(SmoothMove(playerTransform.position, new Vector3(0, 100, 0), 2.0f));
            if (!winTextObject.activeSelf)
            {
                playerTransform.position = new Vector3(15, 1, 0);
            }
        }
        if (other.gameObject.CompareTag("Acelerator"))
        {
            // fuerza hacia la derecha
            rb.AddForce(new Vector3(10000, 0, 0));
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
        countText.text = "Puntos: " + count.ToString();
        if (count >= 16)
        {
            winTextObject.SetActive(true);
        }
    }
}
