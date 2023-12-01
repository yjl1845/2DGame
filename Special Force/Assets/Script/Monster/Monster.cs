using System.Collections;
using UnityEditor;
using UnityEngine;

public enum STATE
{
    WALK,
    ATTACK,
    HIT,
    DIE
}


public abstract class Monster : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private protected Animator animator;

    [SerializeField] STATE state;
    [SerializeField] Vector2 direction;
    [SerializeField] Transform CharacterPosition;

    [SerializeField] protected float speed = 100f;
    [SerializeField] protected float attack;
    [SerializeField] protected float health;
    [SerializeField] private float power = 10;

    [SerializeField] Sound sound = new Sound();

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
            case STATE.HIT:
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

    public IEnumerator OnHit(float Damage)
    {
        state = STATE.HIT;

        rigidbody2D.velocity = Vector2.zero;

        health -= Damage;
        
        AudioManager.instance.Sound(sound.audioClip[0]);

        if(health <= 0)
        {
            state = STATE.DIE;
            yield break;
        }

        rigidbody2D.AddForce(-direction * power, ForceMode2D.Force);

        yield return Corutincash.waitForSeconds(0.25f);

        state = STATE.WALK;
    }

    public void Release()
    {
        Destroy(gameObject);
    }

    protected void Move()
    {
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
            if(state != STATE.DIE)
            {
                state = STATE.WALK;
            }
        }
    }
}
