using System;
using UnityEngine;

public abstract class GenericEventChannel<T> : ScriptableObject
{
    private event Action<T> eventChannel;

    public void Raise(T parameter)
    {
        eventChannel?.Invoke(parameter);
    }

    public void AddListener(Action<T> subscriber)
    {
        eventChannel += subscriber;
    }

    public void RemoveListener(Action<T> subscriber)
    {
        eventChannel -= subscriber;
    }
}
