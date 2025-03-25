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
        
        if (Player == null) return;

        Vector3 direction = Player.position - transform.position;
        direction.y = 0f; // keep movement flat

        float distance = direction.magnitude;

        if (distance > stoppingDistance)
        {
            Vector3 move = direction.normalized * moveSpeed * Time.deltaTime;
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

        
        if (distance <= attackDistance && Time.time >= lastAttackTime + attackDelay)
        {
            Attack();
            lastAttackTime = Time.time;
        }


        void Attack()
        {
            if (_animator != null)
                _animator.SetTrigger("Attack");
        }
        
    }
}


