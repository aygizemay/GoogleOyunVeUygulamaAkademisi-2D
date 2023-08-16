using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))
        {
            _audio.Play();
            Destroy(other.gameObject);
            score.totalScore++;  // Puaný bir artýrýyoruz.
            _text.text = score.totalScore.ToString();
        }
    }
}
