using UnityEngine;

namespace UnityMovementAI
{
    [RequireComponent(typeof(SteeringBasics))]
    public class Wander2 : MovementInterface
    {
        public float wanderRadius = 3f;

        public float wanderDistance = 1f;

        /// <summary>
        /// Maximum amount of random displacement a second
        /// </summary>
        public float wanderJitter = 45f;

        public Vector3 wanderTarget;

        [SerializeField]
        float offset = 2.0f;

        SteeringBasics steeringBasics;

        MovementAIRigidbody rb;

        void Awake()
        {
            steeringBasics = GetComponent<SteeringBasics>();

            rb = GetComponent<MovementAIRigidbody>();
        }

        void Start()
        {
            /* Set up the wander target. Doing this in Start() because the MovementAIRigidbody
             * sets itself up in Awake(). */
            float theta = Random.value * 2 * Mathf.PI;

            /* Create a vector to a target position on the wander circle */

            wanderTarget = new Vector3(wanderRadius * Mathf.Cos(theta), wanderRadius * Mathf.Sin(theta), 0f);

        }

        public Vector3 GetSteering()
        {
            /* Get the jitter for this time frame */
            float jitter = wanderJitter * Time.deltaTime;

            /* Add a small random vector to the target's position */

            wanderTarget += new Vector3(Random.Range(-1f, 1f) * jitter, Random.Range(-1f, 1f) * jitter, 0f);
            


            /* Make the wanderTarget fit on the wander circle again */
            wanderTarget.Normalize();
            wanderTarget *= wanderRadius;

            /* Move the target in front of the character */
            Vector3 targetPosition = transform.position + transform.right * wanderDistance + wanderTarget;

            if ((targetPosition.x > GameController.maxBounds.x - offset) ||
                (targetPosition.x < GameController.minBounds.x + offset))
            {
                targetPosition.x = -(targetPosition.x);
            }
            if ((targetPosition.y > GameController.maxBounds.y - offset) ||
                (targetPosition.y < GameController.minBounds.y + offset))
            {
                targetPosition.y = -(targetPosition.y);
            }

            Debug.DrawLine(transform.position, targetPosition);

            return steeringBasics.Seek(targetPosition);
        }
    }
}