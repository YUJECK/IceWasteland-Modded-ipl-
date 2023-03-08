using IceWasteland.AICore;
using IceWasteland.Player;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TargetTrigger))]
public class Bee : MonoBehaviour
{
    private float moveSpeed = 5f;

    private Transform target;

    [Inject]
    private void Construct(PlayerProvider playerProvider)
    {
        target = playerProvider.transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}