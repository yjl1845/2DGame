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

    [SerializeField] float speed = 250;
    [SerializeField] Vector2 direction;
    [SerializeField] Material flashmaterial;

    float exitTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        originMatherial = spriteRenderer.material;

        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        colutin();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    public void Action()
    {

    }

    public void FixedUpdate()
    {
        // �̵� ���� �Լ�
        Move();

        // ���� ��ȯ
        State();

        // �̹��� ����
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

    // �ڷ�ƾ �Լ� flash
    // ���� ������ flash Matrial�� ��ü.
    // ��� 0.125f �Ŀ� �����·� ���ư���.
    IEnumerator colutin()
    {
        gameObject.GetComponent<MeshRenderer>().material = flashmaterial;
        yield return new WaitForSeconds(0.125f);
        gameObject.GetComponent<MeshRenderer>().material = originMatherial;
    }
}