using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A MonoBehavior dependant timer that waits a certain amount of time before completing an action; supports looping.
/// </summary>
public class MonoTimer
{
    // MonoBehaviour to start / stop coroutines on
    private MonoBehaviour _monoBehaviour;

    // Has this timer completed ?
    public bool Completed => _completed;
    private bool _completed = true;

    // Is this timer looping ?
    public bool Looping = true;

    // Current running coroutine of this timer
    private Coroutine _coroutine;

    // Time / Loop time of this timer
    private float _time;

    // Action called when completed
    public Action OnCompleted;

    // Constructor, requires monobehaviour
    public MonoTimer(MonoBehaviour monoBehavior)
    {
        _monoBehaviour = monoBehavior;
    }

    /// <summary>
    /// Stop this timer and disables looping
    /// </summary>
    public void Stop()
    {
        Looping = false;

        if (_coroutine != null) _monoBehaviour.StopCoroutine(_coroutine);

        _completed = true;
        OnCompleted?.Invoke();
    }

    /// <summary>
    /// Starts this timer and sets the default time
    /// </summary>
    /// <param name="time">Param of the default time</param>
    /// <param name="looping">Optional param to enable looping | default: false</param>
    public void Start(float time, bool looping = false)
    {
        SetTime(time);

        Looping = looping;

        if (_coroutine != null) _monoBehaviour.StopCoroutine(_coroutine);

        _coroutine = _monoBehaviour.StartCoroutine(EnumeratorTimer());
    }

    /// <summary>
    /// Sets the default time of this timer
    /// </summary>
    /// <param name="time">Param of the default time</param>
    public void SetTime(float time)
    {
        _time = time;
    }

    /// <summary>
    /// Enumerator to wait for time
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator EnumeratorTimer()
    {
        _completed = false;
        yield return new WaitForSeconds(_time);
        _completed = true;
        OnCompleted?.Invoke();

        // If looping, restart
        if (Looping) _coroutine = _monoBehaviour.StartCoroutine(EnumeratorTimer());
        else _coroutine = null;
    }

}
