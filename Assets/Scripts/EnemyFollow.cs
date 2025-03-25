using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public Transform Player;
    public float moveSpeed = 3f;
    public float stoppingDistance = 3f;
    public float attackDistance = 2f;
    public float attackDelay = 1.5f;

    private CharacterController controller;

    private Animator _animator;

    //Adjustments for gravity
    private float vertVelocity = 0f;
    public float gravity = -9.81f;

    private float lastAttackTime = -Mathf.Infinity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Gravity Control
        if (!controller.isGrounded)
        {
            vertVelocity += gravity * Time.deltaTime;
        }
        else
        {
            vertVelocity = -1f; // small value to stay grounded
        }

        if (Player == null) return;

        Vector3 direction = Player.position - transform.position;
        direction.y = 0f; // keep movement flat

        float distance = direction.magnitude;

        if (distance > stoppingDistance)
        {
            Vector3 move = direction.normalized * moveSpeed * Time.deltaTime;
            move.y = vertVelocity;

            controller.Move(move);

            // Rotate to face player
            if (move != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            if (_animator != null)
                _animator.SetBool("isWalking", true);
        }
        else
        {
            // Play idle animation
            if (_animator != null)
                _animator.SetBool("isWalking", false);
        }

        //Atack distance
        if (distance <= attackDistance && Time.time >= lastAttackTime + attackDelay)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }
    
    //Sets trigger to do attack animation
    void Attack()
    {
        if (_animator != null)
            _animator.SetTrigger("Attack");
    }
    
}



