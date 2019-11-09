using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]

public class SteeredCohesionBehaviour : FilteredFlockBehaviour
{
    Vector2 currentVelocity;
    [SerializeField]
    private float agentSmoothing = 0.5f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours, no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        // add all points and average
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
            cohesionMove += (Vector2)item.position;

        cohesionMove /= context.Count;
        //create offset from agent pos
        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothing);

        return cohesionMove;
    }
}
