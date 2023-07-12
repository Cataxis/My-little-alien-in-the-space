using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab de la bala a lanzar
    public float launchForce = 10f;  // Fuerza de lanzamiento
    public float cooldownTime = 0.5f;  // Tiempo de espera entre cada disparo

    private float cooldownTimer = 0f;  // Temporizador de enfriamiento
    private bool canShoot = true;  // Variable que indica si se puede disparar

    private void Update()
    {
        // Verificar si se puede disparar y se presiona la barra espaciadora o el gatillo RT
        if (canShoot && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)))
        {
            LaunchBullet();
            StartCooldown();
            Debug.Log("Joystick button pressed");

        }

        // Actualizar el temporizador de enfriamiento
        if (!canShoot)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                canShoot = true;
            }
        }
    }

    private void LaunchBullet()
    {
        // Crear una instancia de la bala
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Obtener el componente Rigidbody2D de la bala
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Aplicar la fuerza de lanzamiento a la bala
        bulletRigidbody.AddForce(transform.right * launchForce, ForceMode2D.Impulse);
    }

    private void StartCooldown()
    {
        canShoot = false;
        cooldownTimer = cooldownTime;
    }
}
