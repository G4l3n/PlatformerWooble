using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Damage : MonoBehaviour
{
    public List<GameObject> Healt;


    void Update()
    {
        if (Healt.Count == 0)
        {
            Debug.Log("MORT");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            for (int i = 0; i < Healt.Count; i--)
            {
                Healt[i].transform.DOScale(0, 0.5f);
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        Healt.RemoveAt(0);
        StopCoroutine(Die());
    }

}
