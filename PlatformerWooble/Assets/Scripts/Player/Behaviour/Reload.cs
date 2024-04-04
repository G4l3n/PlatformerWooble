using UnityEngine;
using UnityEngine.Events;

public class Reload : MonoBehaviour
{
    public Switch Switch;

    public float Magazine = 0;
    public int _max;
    [SerializeField]
    private int _add;
    [SerializeField] private UnityEvent _loading;


    void FixedUpdate()
    {
        if(Switch.Night == false)
        {
            if (Magazine < _max)
            {
                Magazine += _add;
                _loading?.Invoke();
            }
        }
    }
}
