using UnityEngine;

public class UnscaledParticleSystem : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (ps != null)
        {
            ps.Simulate(Time.unscaledDeltaTime, true, false);
        }
    }
}
