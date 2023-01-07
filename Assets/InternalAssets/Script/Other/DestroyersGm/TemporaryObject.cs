using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class TemporaryObject : MonoBehaviour
{
    [SerializeField] float deadTime;

    void Start() => StartTImer();
    private async void StartTImer()
    {
        Debug.Log($"Started timer to {gameObject.name}. Will be destroyed by {deadTime} milliseconds");

        await UniTask.Delay(TimeSpan.FromSeconds(deadTime));
        Destroy(gameObject);
    }
}