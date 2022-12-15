using Unity.VisualScripting;
using UnityEngine;

namespace UnityMovementAI
{
    public class Wander2Unit : MovementUnitInterface
    {
        SteeringBasics steeringBasics;
        Wander2 wander;

        void Start()
        {
            steeringBasics = GetComponent<SteeringBasics>();
            this.AddComponent<Wander2>();
            moveType = GetComponent<Wander2>();
            wander = (Wander2)moveType;
        }

        void FixedUpdate()
        {
            Vector3 accel = wander.GetSteering();

            steeringBasics.Steer(accel);
            steeringBasics.LookWhereYoureGoing();
        }
    }
}