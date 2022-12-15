using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

namespace UnityMovementAI
{
    public class PursueUnit : MovementUnitInterface
    {
        public MovementAIRigidbody target;

        SteeringBasics steeringBasics;
        Pursue pursue;

        void Start()
        {
            target = GameController.Player.GetComponent<MovementAIRigidbody>();
            Assert.IsNotNull(target, "NO TARGET");
            steeringBasics = GetComponent<SteeringBasics>();
            this.AddComponent<Pursue>();
            moveType = GetComponent<Pursue>();
            pursue = (Pursue)moveType;
        }

        void FixedUpdate()
        {
            Vector3 accel = pursue.GetSteering(target);

            steeringBasics.Steer(accel);
            steeringBasics.LookWhereYoureGoing();
        }
    }
}