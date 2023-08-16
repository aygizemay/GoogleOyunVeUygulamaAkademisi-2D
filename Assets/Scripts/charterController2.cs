using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController2 : MonoBehaviour
{
    public float jumpForce = 150.0f;  // Zýplama kuvveti
    public float speed = 2.0f;  // Hareket hýzý
    float moveDirection;  // Hareket yönü
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    private bool jump;  // Zýplama durumu
    private bool grounded = true;  // Zeminde olup olmadýðýný tutan deðiþken

    private Animator anim;  // Animator bileþeni

    void Awake()
    {
        anim = GetComponent<Animator>();  // Nesnenin Animator bileþenini alýyoruz.
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();  // Nesnenin Rigidbody2D bileþenini alýyoruz.
        _spriteRenderer = GetComponent<SpriteRenderer>();  // Nesnenin SpriteRenderer bileþenini alýyoruz.
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
                _spriteRenderer.flipX = true;  // Karakteri yatayda çevirme
                anim.SetFloat("speed", speed);  // Animator'a hýzý set etme
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = +1.0f;
                _spriteRenderer.flipX = false;  // Karakteri yatayda çevirme
                anim.SetFloat("speed", speed);  // Animator'a hýzý set etme
            }
        }
        else if (grounded)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);  // Hareketsiz durum için Animator'a hýzý 0 set etme
        }

        if (grounded && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");  // Zýplama animasyonunu tetikleme
            anim.SetBool("grounded", false);  // Zeminde deðil durumunu Animator'a set etme
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

