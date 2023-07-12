using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "Player")
        {
            // Obtener la posición del jugador cuando colisiona
            Vector3 playerPosition = player.transform.position;

            // Instanciar el prefab en la posición del jugador
            Instantiate(explosion, playerPosition, Quaternion.identity);

            // Destruir al jugador actual
            Destroy(player.gameObject);

            Debug.Log("Collision");

            GameManager.Instance.IsPlayerAlive = false;

        }
    }

}
