using UnityEngine;
using TinyTools.Pooling;
using TinyTools.Factory;

[CreateAssetMenu(fileName = "NewParticlePool", menuName = "TinyTools/Demos/Pooling/Particle Pool")]
public class ParticlePoolSO : ComponentPoolSO<ParticleSystem>
{
    [SerializeField] private ParticleFactorySO _factory;

    public override IFactory<ParticleSystem> Factory
    {
        get
        {
            return _factory;
        }
        set
        {
            _factory = value as ParticleFactorySO;
        }
    }
}
