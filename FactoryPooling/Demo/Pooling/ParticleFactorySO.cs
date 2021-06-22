using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTools.Factory;

[CreateAssetMenu(fileName = "NewParticleFactory", menuName = "TinyTools/Demos/Pooling/Particle Factory")]
public class ParticleFactorySO : FactorySO<ParticleSystem>
{
    public override ParticleSystem Create()
    {
        return new GameObject("ParticleSystem").AddComponent<ParticleSystem>();
    }
}
