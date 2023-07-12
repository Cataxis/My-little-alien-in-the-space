using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Si hay al menos un toque en la pantalla...
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Obtenemos el primer toque

            // Si el toque se está moviendo...
            if (touch.phase == TouchPhase.Moved)
            {
                // Convertimos la posición del toque de coordenadas de pantalla a coordenadas del mundo
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // Calculamos la dirección hacia la cual el jugador debe moverse, es decir, desde su posición actual hasta la posición del toque
                playerDirection = (touchPosition - (Vector2)transform.position).normalized;
            }
        }

        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            TogglePauseGame();
        }
    }

    private void TogglePauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    private void FixedUpdate()
    {
        float movementSpeed = playerSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(0, playerDirection.y * movementSpeed);
    }
}
