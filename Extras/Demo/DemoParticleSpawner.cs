using UnityEngine;

public class DemoParticleSpawner : MonoBehaviour
{
    [TextArea]
    public string text;
    public GameObject particle1;

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Instantiate(particle1, transform.position, Quaternion.identity);
            Debug.Log("Spawning demo particle 1");
        }
    }
}
