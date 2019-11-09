
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/StayInRadius")]

public class StayInRadiusBehaviour : FlockingBehaviour
{
    private Vector2 center;
    [SerializeField]
    private float radius = 15f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9)
        {
            return Vector2.zero;
        }
        return centerOffset * t * t;
    }
}
