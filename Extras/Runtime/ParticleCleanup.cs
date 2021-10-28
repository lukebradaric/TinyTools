using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleCleanup : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }
}
