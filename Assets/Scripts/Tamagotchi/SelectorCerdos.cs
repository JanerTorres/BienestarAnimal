using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorCerdos : MonoBehaviour
{
    public Vector3 posicionActual;
    public Vector3 angulosActuales;
    public MovimientoHexagonal movimientoHexagonal;
    public GestorTamagotchi tama;
    public bool enCentro;

    void Start()
    {
        movimientoHexagonal = GetComponent<MovimientoHexagonal>();
        tama = GetComponent<GestorTamagotchi>();
    }
    
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (MorionTools.MouseEnUI()) return;
        if (!enCentro)
        {
            MoverAlCero();
            GestionCerdoUI.singleton.Activar(tama, this);
            tama.animCerdo.animator.SetFloat("velocidad", 0);
        }
    }

    void MoverAlCero()
    {
        posicionActual = transform.position;
        angulosActuales = transform.eulerAngles;
        movimientoHexagonal.enabled = false;
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        enCentro = true;
    }

    public void VolverAlPiso()
    {
        movimientoHexagonal.enabled = true;
        transform.position = posicionActual;
        transform.eulerAngles = angulosActuales;
        enCentro = false;
    }
}
