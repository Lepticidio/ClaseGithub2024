using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public int objetoSeleccionado = 0, objetoEquipado = -1;

    public List<Item> items = new List<Item>();

    public List<Image> iconos = new List<Image>();
    public List<Image> marcosDeSeleccion = new List<Image>();


    public GameObject equipamiento;

    public Transform huesoMano;

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

            if(objetoEquipado > objetoSeleccionado)
            {
                objetoEquipado--;
            }
            else
            {
                objetoEquipado = -1;
                Desequipar();
            }
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
                if(i == objetoEquipado)
                {
                    iconos[i].color = new Color(1f, 1f, 0f);
                }
                else
                {
                    iconos[i].color = Color.white;
                }
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Equipar();
        }
    }

    public void Desequipar()
    {

        Destroy(equipamiento.gameObject);
    }
    public void Equipar()
    {

        objetoEquipado = objetoSeleccionado;

        Desequipar();

        if (objetoSeleccionado < items.Count)
        {
            string nombre = items[objetoSeleccionado].nombre;

            GameObject prefabObjeto = Resources.Load<GameObject>("Prefabs/Equipamiento/" + nombre);

            equipamiento = Instantiate(prefabObjeto, huesoMano.position, huesoMano.rotation);
            equipamiento.transform.Rotate(Vector3.forward, 90);
            equipamiento.transform.SetParent(huesoMano);
        }
        ActualizarInterfaz();

    }
}
