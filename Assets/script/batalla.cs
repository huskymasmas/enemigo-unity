using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class batalla : MonoBehaviour
{
    public float i;
    public int j;
    SpriteRenderer sprite;
    
    public TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        texto.text = "batalla enemgio white";
    }

    // Update is called once per frame
    void Update()
    {

        i = 0.01f + i;

        if (i >= 20) {
            transform.position = new Vector2(Random.Range(1.01f, 7.9f), Random.Range(-1.6f, 1.89f));

           

            int opcionescolor = Random.Range(0, 5);
            switch (opcionescolor) {
                case 0:
                    texto.text = "batalla enemgio white";
                    sprite.color = Color.white; break;
                case 1:
                    texto.text = "batalla enemgio blue";
                    sprite.color = Color.blue; break;
                case 3:
                    texto.text = "batalla enemgio gray";
                    sprite.color = Color.gray; break;
                case 4:
                    texto.text = "batalla enemgio red";
                    sprite.color = Color.red; break;
                case 5:
                    texto.text = "batalla enemgio cyan";
                    sprite.color = Color.cyan; break;
            }
            i = 0;

        }

        
    }
}