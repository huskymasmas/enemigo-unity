using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_personaje : MonoBehaviour
{
    float hor;
    float ver;
    public float velocidad;
    public GameObject camva1 , personaje;
    Rigidbody2D rb;
    public GameObject grupo;
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        Vector2 movimiento = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Transicion());
       
    }
    IEnumerator Transicion()
    {
        camva1.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        LeanTween.alpha(grupo.GetComponent<RectTransform>(), 0f, 1f).setDelay(0.2f);
        grupo.GetComponent<CanvasGroup>().blocksRaycasts = false;
        batalla[] enemigos = FindObjectsOfType<batalla>();
        foreach (batalla enemigo in enemigos)
        {
            enemigo.enabled = false; 
        }
        yield return new WaitForSeconds(4f); 
        Debug.Log("Transici�n completada");
        foreach (batalla enemigo in enemigos)
        {
            enemigo.enabled = true;
        }
      
        yield return new WaitForSeconds(1f);
        camva1.SetActive(false);
        LeanTween.alpha(grupo.GetComponent<RectTransform>(), 1f, 0f).setDelay(1f);
    }




}
