using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject newObjectPrefab;  // Prefab del nuevo objeto a instanciar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Destruir el objeto obstáculo
            Destroy(collision.gameObject);

            // Instanciar el nuevo objeto en la ubicación destruida
            Instantiate(newObjectPrefab, collision.transform.position, Quaternion.identity);
        }

        // Destruir la bala después de colisionar
        Destroy(gameObject);
    }
}
