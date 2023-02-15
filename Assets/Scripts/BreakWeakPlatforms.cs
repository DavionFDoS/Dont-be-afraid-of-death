using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWeakPlatforms : MonoBehaviour
{
    private const string Breakable = "Breakable";
    private int _breakable;
    void Start()
    {
        _breakable = LayerMask.NameToLayer(Breakable);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == _breakable)
        {
            Destroy(collision.gameObject);
        }
    }
}
