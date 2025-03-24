using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        // Move downward each frame
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroying when out of bounds
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
