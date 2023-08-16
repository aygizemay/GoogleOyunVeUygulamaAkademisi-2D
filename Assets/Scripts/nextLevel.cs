using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        // Awake fonksiyonu, nesne olu�turuldu�unda �a�r�l�r ve sahnedeki mevcut sahne bilgisini al�r.
        _scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // OnTriggerEnter2D fonksiyonu, tetikleyici bir alana girildi�inde otomatik olarak �a�r�l�r.
        if (other.gameObject.CompareTag("Player"))
        {
            // E�er etiket "Player" ise (yani oyuncu ile �arp��m��sa), a�a��daki kod �al���r.
            SceneManager.LoadScene(_scene.buildIndex + 1);
            // SceneManager.LoadScene, sahneyi y�klemek i�in kullan�l�r. _scene.buildIndex + 1, bir sonraki sahneyi y�kler.
        }
    }

    public void StartLevel()
    {
        // StartLevel ad�nda bir fonksiyon tan�mlanm��.
        SceneManager.LoadScene(_scene.buildIndex + 1);
        // Bu fonksiyon �a�r�ld���nda da bir sonraki sahneye ge�ilir.
    }
}