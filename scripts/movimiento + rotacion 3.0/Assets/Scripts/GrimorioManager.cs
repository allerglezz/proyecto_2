using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimorioManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Jugador;
    [SerializeField] GameObject Indicaciones;
    [SerializeField] GameObject Inventario;
    [SerializeField] GameObject Ajustes;
    [SerializeField] GameObject Coleccionables;
    private PlayerMovement movement;
    public static bool Pausado = false;
    public void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        Indicaciones.SetActive(false);
        Menu.SetActive(false);
        Coleccionables.SetActive(false);
        Inventario.SetActive(false);
        Ajustes.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log(movement);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Pausado == false)
            {
                PausarJuego();
            }
            else
            {
                ContinuarJuego();
            }
            movement.setPause();
        }
    }
    public void PausarJuego()
    {
        Time.timeScale = 0f;
        Pausado = true;
        Menu.SetActive(true);
        Indicaciones.SetActive(true);
        Coleccionables.SetActive(false);
        Inventario.SetActive(false);
        Ajustes.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinuarJuego()
    {
        Time.timeScale = 1f;
        Pausado = false;
        Indicaciones.SetActive(false);
        Coleccionables.SetActive(false);
        Inventario.SetActive(false);
        Ajustes.SetActive(false);
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
