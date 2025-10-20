using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collsion : MonoBehaviour
{
  
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Colisión con: ");
    }
}
