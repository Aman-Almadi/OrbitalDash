using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType {  Score, SpeedBoost }
    public CollectibleType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (type)
            {
                case CollectibleType.Score:
                    GameManager.Instance.IncreaseScore(10);
                    break;
                case CollectibleType.SpeedBoost:
                    other.GetComponent<PlayerController>().ApplySpeedBoost();
                    break;
            }
            other.GetComponent<PlayerController>().PlaySound(other.GetComponent<PlayerController>().collectibleSound);
            Destroy(gameObject);
        }
    }
}
