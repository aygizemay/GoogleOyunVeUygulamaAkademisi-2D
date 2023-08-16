using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcterController : MonoBehaviour
{
    public float speed = 1.0f;                // Karakterin h�z�
    private Rigidbody2D r2d;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;   // Kamera nesnesi

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }

    private void Update()
    {
        // Bo�luk tu�una bas�l�rsa h�z� ayarla
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
        }
        else
        {
            speed = 0.0f;
        }

        // Yatay hareketi isle ve karakter pozisyonunu g�ncelle
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * Time.deltaTime), charPos.y);
        transform.position = charPos;

        // H�z� ve animasyonlar� i�le
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }

        // Karakterin y�z�n� �evir
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void LateUpdate()
    {
        // Kamera pozisyonunu g�ncelle (istege ba�l�)
        // _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }
}
