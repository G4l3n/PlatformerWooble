using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    private string GameTest;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            SceneManager.LoadScene(GameTest);
            Debug.Log("aaa");
        }
    }
}
