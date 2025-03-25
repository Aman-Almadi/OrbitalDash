using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private bool isShieldActive = false;
    public AudioClip collectibleSound;
    public AudioClip shieldSound;
    public AudioClip slowTimeSound;
    private AudioSource audioSource;

    [SerializeField] private float maxSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction in the X-Z plane (since it's top-down)
        Vector3 input = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Apply force to move the player
        rb.AddForce(input * speed, ForceMode.Force);

        // Clamp velocity to prevent excessive speed
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
        }
    }

    public void ApplySpeedBoost()
    {
        StartCoroutine(SpeedBoostRoutine());
    }

    private IEnumerator SpeedBoostRoutine()
    {
        float originalSpeed = speed;
        speed *= 2; // Double the speed
        yield return new WaitForSeconds(5f); // Boost lasts 5 seconds
        speed = originalSpeed;
    }

    public void ActivateShield()
    {
        isShieldActive = true;
        Invoke("DeactivateShield", 10f);
    }

    void DeactivateShield()
    {
        isShieldActive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (isShieldActive)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
