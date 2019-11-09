using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]

public class CompositeBehaviour : FlockingBehaviour
{
    public FlockingBehaviour[] behaviours;
    public float[] weights;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //HANDLE DATA MISMATCH
        if (weights.Length != behaviours.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero;
        }

        //SET UP MOVE
        Vector2 move = Vector2.zero;

        //ITERATE THROUGH BEHAVIOURS
        for (int i = 0; i < behaviours.Length; i++)
        {
            Vector2 partialMove = behaviours[i].CalculateMove(agent, context, flock) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }
        return move;
    }
}
