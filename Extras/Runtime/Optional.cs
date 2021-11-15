using UnityEngine;
using System;

// Inspired by https://gist.github.com/aarthificial/f2dbb58e4dbafd0a93713a380b9612af
// Optional Inspector Variable

[Serializable]
public struct Optional<T>
{
    [SerializeField] private bool enabled;
    [SerializeField] private T value;

    public bool Enabled => enabled;
    public T Value => value;

    public Optional(T val)
    {
        enabled = true;
        value = val;
    }
}
