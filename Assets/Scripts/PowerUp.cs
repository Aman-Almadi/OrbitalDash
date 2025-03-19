using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType {  Shield, SlowTime }
    public PowerUpType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (type)
            {
                case PowerUpType.Shield:
                    other.GetComponent<PlayerController>().ActivateShield();
                    break;
                case PowerUpType.SlowTime:
                    Time.timeScale = 0.5f;
                    Invoke("ResetTimeScale", 5f);
                    break;
            }
            other.GetComponent<PlayerController>().PlaySound(type == PowerUpType.Shield ? other.GetComponent<PlayerController>().shieldSound : other.GetComponent<PlayerController>().slowTimeSound);
            Destroy(gameObject);
        }
    }

    void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }
}
