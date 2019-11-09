using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }
	// Use this for initialization
	void Start ()
    {
        agentCollider = GetComponent<Collider2D>();
	}
    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }
    public void Move(Vector2 movement)
    {
        transform.up = movement;
        transform.position += (Vector3)movement * Time.deltaTime;
    }
}
