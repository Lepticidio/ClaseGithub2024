using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public string nombre;
    public Sprite sprite;
    public float durabilidad = 100;
}

public class ObjetoRecogible : MonoBehaviour
{
    public Item item;
    public Sprite icono;
    public string nombre;

    private void Start()
    {
        item = new Item();

        item.sprite = icono;
        item.nombre = nombre;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Jugador" && collision.gameObject.name != "DetectorSuelo")
        {
            collision.gameObject.GetComponent<Inventario>().AddItem(item);
            Destroy(gameObject);
        }
    }
}
