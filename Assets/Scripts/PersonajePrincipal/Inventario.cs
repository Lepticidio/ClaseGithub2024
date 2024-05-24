using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public int objetoSeleccionado = 0;

    public List<Item> items = new List<Item>();

    public List<Image> iconos = new List<Image>();
    public List<Image> marcosDeSeleccion = new List<Image>();

    public void AddItem(Item item)
    {
        items.Add(item);
        ActualizarInterfaz();
    }

    public void SoltarActual()
    {
        if(items.Count > 0)
        {
            string nombre = items[objetoSeleccionado].nombre;
            items.RemoveAt(objetoSeleccionado);
            ActualizarInterfaz();

            GameObject prefabObjeto = Resources.Load<GameObject>("Prefabs/Objetos/" + nombre);

            Instantiate(prefabObjeto, transform.position + new Vector3(2, 1, 0), Quaternion.identity);
        }
    }

    public void ActualizarInterfaz()
    {
        for(int i = 0; i < iconos.Count; i++)
        {
            if(items.Count > i)
            {
                iconos[i].sprite = items[i].sprite;
                iconos[i].color = Color.white;
            }
            else
            {
                iconos[i].color = Color.clear;
            }
        }
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0 && objetoSeleccionado < iconos.Count- 1)
        {
            marcosDeSeleccion[objetoSeleccionado].gameObject.SetActive(false);
            objetoSeleccionado++;
        }
        else if (Input.mouseScrollDelta.y < 0 && objetoSeleccionado > 0)
        {
            marcosDeSeleccion[objetoSeleccionado].gameObject.SetActive(false);
            objetoSeleccionado--;
        }

        if(Input.GetMouseButtonDown(1))
        {
            SoltarActual();
        }
        marcosDeSeleccion[objetoSeleccionado].gameObject.SetActive(true);
    }
}
