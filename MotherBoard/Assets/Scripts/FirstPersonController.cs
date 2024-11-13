using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float walkSpeed = 5f; // Velocidad de caminar
    public float runSpeed = 10f; // Velocidad de correr
    public float mouseSensitivity = 2f; // Sensibilidad del mouse
    public float jumpForce = 5f; // Fuerza de salto
    public float gravity = -9.81f; // Gravedad personalizada
    public float climbSpeed = 3f; // Velocidad de subida en escaleras

    private CharacterController controller;
    private Vector3 velocity; // Almacenará la velocidad de caída
    private bool isGrounded; // Para comprobar si está en el suelo
    private bool isClimbing; // Comprobación de si está subiendo una escalera

    private Transform playerCamera; // Cámara principal
    private float xRotation = 0f; // Rotación en el eje X

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro
    }

    void Update()
    {
        // Comprobamos si está en el suelo
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantiene al jugador en el suelo
        }

        // Movimiento en los ejes X y Z
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Verificamos si el jugador está presionando Shift para correr
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        if (isClimbing)
        {
            // Movimiento hacia arriba o abajo en escaleras
            float moveY = Input.GetAxis("Vertical");
            controller.Move(new Vector3(0, moveY * climbSpeed, 0) * Time.deltaTime);
        }
        else
        {
            // Movimiento normal en el suelo
            controller.Move(move * currentSpeed * Time.deltaTime);

            // Saltar
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }

            // Aplicar gravedad
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        // Rotación con el mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación vertical

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // Rotación del cuerpo del jugador
    }

    // Método para detectar si está tocando una escalera
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder")) // Asegúrate de que la escalera tenga el tag "Ladder"
        {
            isClimbing = true; // Activa el modo de escalada
            velocity.y = 0; // Resetea la velocidad vertical al comenzar a escalar
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            isClimbing = false; // Desactiva el modo de escalada al salir de la escalera
        }
    }
}