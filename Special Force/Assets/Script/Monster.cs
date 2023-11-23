using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    [SerializeField] Vector2 direction;
    [SerializeField] float speed = 100f;
    [SerializeField] Transform CharacterPosition;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        CharacterPosition = GameObject.Find("Charactor").transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
       direction = (Vector2) CharacterPosition.position - (Vector2) transform.position;
    }

    protected virtual void FixedUpdate()
    {
        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;

        InvertImage();
    }

    protected abstract void Attack();

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
}
