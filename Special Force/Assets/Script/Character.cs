using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Character : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Material originMatherial;

    [SerializeField] float health = 100;
    [SerializeField] float speed = 250;
    [SerializeField] Vector2 direction;
    [SerializeField] Material flashmaterial;

    private WaitForSeconds waitForSeconds = new WaitForSeconds(0.125f);

    float exitTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originMatherial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        // 이동 관련 함수
        Move();

        // 상태 변환
        State();

        // 이미지 반전
        InvertImage();
    }

    public void Move()
    {
        rigidbody2D.velocity = direction.normalized * speed * Time.fixedDeltaTime;
    }
    public void State()
    {
        if(rigidbody2D.velocity == Vector2.zero)
        {
            animator.SetBool("Walk",false);
        }

        else
        {
            animator.SetBool("Walk", true);
        }
    }

    public void InvertImage()
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }

        else
        {
            spriteRenderer.flipX = false;
        }
    }

    // 코루틴 함수 flash
    // 재질 정보를 flash Matrial로 교체.
    // 대기 0.125f 후에 원상태로 돌아가기.
    IEnumerator Flash()
    {
        spriteRenderer.material = flashmaterial;

        yield return waitForSeconds;

        spriteRenderer.material = originMatherial;
    }

    public void OnHit(float damage)
    {
        StartCoroutine(Flash());

        health -= damage;

        if (health < 0)
        {
            Debug.Log("체력깎임");
        }
    }
}
