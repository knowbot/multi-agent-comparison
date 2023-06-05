using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class CellAgent : Agent
{
    [SerializeField] List<Food> foodInSight = new List<Food>();
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float rotationSpeed = 90f;
    [SerializeField] float moveForward = 0;
    [SerializeField] float rotate = 0;

    public override void CollectObservations(VectorSensor sensor)
    {
        // Energy
        // Age
        // Distance to closest food
        // Angle to closest food
        // Number of foods seen

        // sensor.AddObservation(minDist);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        //moveForward = vectorAction[0];
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxisRaw("Vertical");
        actionsOut[1] = Input.GetAxisRaw("Horizontal");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Food>(out Food food))
        {
            foodInSight.Add(food);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Food>(out Food food))
        {
            foodInSight.Remove(food);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Food>(out Food food))
        {
            // eat food
            SetReward(+1f);
        }
    }
}
