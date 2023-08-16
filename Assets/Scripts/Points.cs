using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bu fonksiyon, bir tetikleyici alana giriþte otomatik olarak çaðrýlýr.

        if (collision.gameObject.CompareTag("Player"))
        {
            // Eðer etiket "Player" ise (yani oyuncu ile çarpýþmýþsa), aþaðýdaki kod çalýþýr.

            Destroy(gameObject);
            // "Destroy(gameObject);" kodu, tetikleyiciye giren nesneyi yani bu scriptin baðlý olduðu nesneyi yok eder.
            // Bu tip senaryolarda, örneðin oyuncu bir nesneye temas ettiðinde o nesnenin yok olmasý gerektiðinde kullanýlýr.
            // Bu sayede nesneleri toplama veya etkileþime girme gibi senaryolar gerçekleþtirilebilir.
        }
    }
}
