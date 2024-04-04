using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private GameObject _spot;
    [SerializeField] private float _hp = 100f;


    public void TakeDmg(float dmgTaken)
    {
        if (_hp > 0)
        {
            Debug.Log("takingdmg");
            _hp -= dmgTaken;
            Color c = this.GetComponent<SpriteRenderer>().color;
            c.r += .0015f;
            c.g += .0015f;
            c.b += .0015f;
            GetComponent<SpriteRenderer>().color = c;
        }
        if (_hp <= 0)
        {
            GameObject.Instantiate(_spot, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}