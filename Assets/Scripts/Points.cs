using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bu fonksiyon, bir tetikleyici alana giri�te otomatik olarak �a�r�l�r.

        if (collision.gameObject.CompareTag("Player"))
        {
            // E�er etiket "Player" ise (yani oyuncu ile �arp��m��sa), a�a��daki kod �al���r.

            Destroy(gameObject);
            // "Destroy(gameObject);" kodu, tetikleyiciye giren nesneyi yani bu scriptin ba�l� oldu�u nesneyi yok eder.
            // Bu tip senaryolarda, �rne�in oyuncu bir nesneye temas etti�inde o nesnenin yok olmas� gerekti�inde kullan�l�r.
            // Bu sayede nesneleri toplama veya etkile�ime girme gibi senaryolar ger�ekle�tirilebilir.
        }
    }
}
