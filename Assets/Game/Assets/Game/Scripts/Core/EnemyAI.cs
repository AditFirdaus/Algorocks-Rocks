using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Player player => Player.instance;
    public Vector3 fromPlayerDirection => transform.position - player.transform.position;
    public Vector3 toPlayerDirection => player.transform.position - transform.position;

    public bool inDetectRange => Vector3.Distance(transform.position, player.transform.position) <= enemy.enemyStatus.detectRange;
    public bool inActionRange => Vector3.Distance(transform.position, player.transform.position) <= enemy.enemyStatus.actionRange;

    public Enemy enemy;
    public Rigidbody2D rb;
    public AIState state;

    public float steerStrength = 2;
    public float wanderStrength = 0.1f;

    Vector2 velocity;
    Vector2 desiredDirection;

    private void OnDrawGizmos()
    {
        if (!enemy) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemy.enemyStatus.detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemy.enemyStatus.actionRange);
    }

    private void Update()
    {
        AIManager();
    }

    public void AIManager()
    {

        if (!player) state = AIState.Idle;

        switch (state)
        {
            default:
                break;

            case AIState.Idle:
                enemy.gunManager.isFiring = false;
                MoveRandom();

                if (!player) break;

                if (inDetectRange)
                {
                    state = AIState.Detect;
                }

                break;

            case AIState.Detect:
                enemy.gunManager.isFiring = false;
                Seek();

                if (!inDetectRange)
                {
                    state = AIState.Idle;
                }

                if (inActionRange)
                {
                    state = AIState.Action;
                }

                break;

            case AIState.Action:
                enemy.gunManager.isFiring = true;
                Seek();

                if (!inActionRange)
                {
                    state = AIState.Detect;
                }

                break;
        }
    }

    public void MoveRandom()
    {
        desiredDirection = (desiredDirection + Random.insideUnitCircle * wanderStrength).normalized;

        Vector2 desiredVelocity = desiredDirection * enemy.enemyStatus.movementSpeed;
        Vector2 desiredSteeringForce = (desiredVelocity - velocity) * steerStrength;
        Vector2 acceleration = Vector2.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;

        velocity = Vector2.ClampMagnitude(velocity + acceleration * Time.deltaTime, enemy.enemyStatus.movementSpeed);
        rb.velocity = velocity;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        rb.angularVelocity = Mathf.DeltaAngle(rb.rotation, angle) * 5;
    }

    public void Seek()
    {
        Vector2 direction = toPlayerDirection.normalized;
        Vector2 targetPosition = player.transform.position + fromPlayerDirection.normalized * (enemy.enemyStatus.actionRange / 2);

        Vector2.SmoothDamp(transform.position, targetPosition + velocity / 2, ref velocity, 1, enemy.enemyStatus.movementSpeed);
        rb.velocity = velocity;

        desiredDirection = direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.angularVelocity = Mathf.DeltaAngle(rb.rotation, angle) * 5;
    }

}

public enum AIState
{
    Idle,
    Detect,
    Action
}
