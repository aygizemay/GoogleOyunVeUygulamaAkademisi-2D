using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesControls : MonoBehaviour
{
    private void Awake()
    {
        switch (score.lives)  // "score" yerine "Score" yazýlmalý
        {
            case 3:
                break;
            case 2:
                transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                break;

            case 0:
                SceneManager.LoadScene(4);
                break;
              
            default:
                break;
        }
    }
}
