using IceWasteland.AICore;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TargetLocator))]
public class Bee : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PointTarget[] targetPoints;
    private int randomPoint;

    private TargetLocator targetLocator;

    private PlayerTarget target => targetLocator.CurrentTarget;
    
    [Inject]
    public void Construct(PointTarget[] targetPoints)
    {
        this.targetPoints = targetPoints;
        RandomizePoint();
    }

    private void Start()
        => targetLocator = GetComponent<TargetLocator>();

    private void FixedUpdate()
    {
        if (target != null)
            Move(target.transform);
        else if (targetPoints[randomPoint] != null && targetPoints[randomPoint].transform.position != transform.position)
            Move(targetPoints[randomPoint].transform);
        else
            RandomizePoint();
    }

    private void Move(Transform target)
       => transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    private void RandomizePoint()
        => randomPoint = Random.Range(0, targetPoints.Length);
}