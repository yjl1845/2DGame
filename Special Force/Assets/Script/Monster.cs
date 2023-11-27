using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum STATE
{
    WALK,
    ATTACK,
    DIE
}


public abstract class Monster : MonoBehaviour
{
    private float initSpeed;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private protected Animator animator;

    [SerializeField] STATE state;
    [SerializeField] Vector2 direction;
    [SerializeField] protected float speed = 100f;
    [SerializeField] Transform CharacterPosition;
    [SerializeField] protected float attack;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        initSpeed = speed;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        CharacterPosition = GameObject.Find("Charactor").transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        direction = (Vector2)CharacterPosition.position - (Vector2)transform.position;
    }

    protected virtual void FixedUpdate()
    {
        switch (state)
        {
            case STATE.WALK: Move();
                break;
            case STATE.ATTACK: Attack();
                break;
            case STATE DIE: Death();
                break;
        }
    }

    public void Damage()
    {
        CharacterPosition.GetComponent<Character>().OnHit(attack);
    }

    protected abstract void Attack();

    protected abstract void Death();

    protected void Move()
    {
        speed = initSpeed;

        animator.SetBool("Attack", false);

        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        InvertImage();
    }

    public void InvertImage()
    {
        spriteRenderer.flipX = (direction.x < 0) ? true : false;

       // if (direction.x > 0)
       // {
       //     spriteRenderer.flipX = true;
       // }
       // 
       // else
       // {
       //     spriteRenderer.flipX = false;
       // }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            state = STATE.ATTACK;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            state = STATE.WALK;
        }
    }
}
