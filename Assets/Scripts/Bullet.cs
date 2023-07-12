using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject newObjectPrefab;  // Prefab del nuevo objeto a instanciar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Destruir el objeto obst�culo
            Destroy(collision.gameObject);

            // Instanciar el nuevo objeto en la ubicaci�n destruida
            Instantiate(newObjectPrefab, collision.transform.position, Quaternion.identity);
        }

        // Destruir la bala despu�s de colisionar
        Destroy(gameObject);
    }
}
