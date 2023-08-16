using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        // Awake fonksiyonu, nesne oluþturulduðunda çaðrýlýr ve sahnedeki mevcut sahne bilgisini alýr.
        _scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // OnTriggerEnter2D fonksiyonu, tetikleyici bir alana girildiðinde otomatik olarak çaðrýlýr.
        if (other.gameObject.CompareTag("Player"))
        {
            // Eðer etiket "Player" ise (yani oyuncu ile çarpýþmýþsa), aþaðýdaki kod çalýþýr.
            SceneManager.LoadScene(_scene.buildIndex + 1);
            // SceneManager.LoadScene, sahneyi yüklemek için kullanýlýr. _scene.buildIndex + 1, bir sonraki sahneyi yükler.
        }
    }

    public void StartLevel()
    {
        // StartLevel adýnda bir fonksiyon tanýmlanmýþ.
        SceneManager.LoadScene(_scene.buildIndex + 1);
        // Bu fonksiyon çaðrýldýðýnda da bir sonraki sahneye geçilir.
    }
}