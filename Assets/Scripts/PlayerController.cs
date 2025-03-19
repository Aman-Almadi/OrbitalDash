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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
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
