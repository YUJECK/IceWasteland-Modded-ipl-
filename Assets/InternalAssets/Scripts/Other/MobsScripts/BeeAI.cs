using IceWasteland;
using IceWasteland.AICore;
using System;
using UnityEngine;

[RequireComponent(typeof(TargetTrigger))]
public class BeeAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private TargetTrigger targetTrigger;
    private Vector3 randomPoint;

    public Vector3 TargetPosition
    {
        get
        {
            if (targetTrigger.CurrentTarget != null) return targetTrigger.CurrentTarget.transform.position;
            else
            {
                if (randomPoint == transform.position) randomPoint = GlobalServiceLocator.GetService<SpawnPlace>().GetPosition();
                return randomPoint;
            }
        }
        private set { }
    }

    private void Awake()
    {
        targetTrigger = GetComponent<TargetTrigger>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPosition, moveSpeed * Time.deltaTime);
    }
}