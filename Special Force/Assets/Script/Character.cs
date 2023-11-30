using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Character : MonoBehaviour
{
    private Weapon weapon;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Material originMatherial;

    [SerializeField] float health = 100;
    [SerializeField] float speed = 250;
    [SerializeField] Vector2 direction;
    [SerializeField] int weaponCount;

    [SerializeField] Material flashmaterial;
    [SerializeField] List<Weapon> weaponList;

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

        // 무기 교체 함수
        ChangeWeapon();
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

        yield return Corutincash.waitForSeconds(0.125f);

        spriteRenderer.material = originMatherial;
    }

    public void ChangeWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           if(weaponCount <= weaponList.Count -1)
            {
                weaponCount = 0;
            }
            weapon = weaponList[weaponCount++];

            weapon.Attack();
        }
    }

    public void OnHit(float damage)
    {
        StartCoroutine(Flash());

        health -= damage;

        if (health < 0)
        {
            animator.Play("Death");
        }
    }
}
