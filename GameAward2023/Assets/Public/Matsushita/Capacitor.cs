using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacitor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Junk") || col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<junkBase>().HitCapacitor();
        }
    }
}
