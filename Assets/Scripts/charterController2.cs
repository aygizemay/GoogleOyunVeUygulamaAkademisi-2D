using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController2 : MonoBehaviour
{
    public float jumpForce = 150.0f;  // Z�plama kuvveti
    public float speed = 2.0f;  // Hareket h�z�
    float moveDirection;  // Hareket y�n�
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    private bool jump;  // Z�plama durumu
    private bool grounded = true;  // Zeminde olup olmad���n� tutan de�i�ken

    private Animator anim;  // Animator bile�eni

    void Awake()
    {
        anim = GetComponent<Animator>();  // Nesnenin Animator bile�enini al�yoruz.
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();  // Nesnenin Rigidbody2D bile�enini al�yoruz.
        _spriteRenderer = GetComponent<SpriteRenderer>();  // Nesnenin SpriteRenderer bile�enini al�yoruz.
    }


    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
        if (jump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    void Update()
    {
        if (grounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;  // Karakteri yatayda �evirme
                anim.SetFloat("speed", speed);  // Animator'a h�z� set etme
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = +1.0f;
                _spriteRenderer.flipX = false;  // Karakteri yatayda �evirme
                anim.SetFloat("speed", speed);  // Animator'a h�z� set etme
            }
        }
        else if (grounded)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);  // Hareketsiz durum i�in Animator'a h�z� 0 set etme
        }

        if (grounded && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");  // Z�plama animasyonunu tetikleme
            anim.SetBool("grounded", false);  // Zeminde de�il durumunu Animator'a set etme
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("grounded", true);  // Zeminde durumunu Animator'a set etme
            grounded = true;
        }
    }
}

