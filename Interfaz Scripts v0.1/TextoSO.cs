using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomUI/TextoSO", fileName = "Texto")] //crea un objeto programable para aplicar los temas/estilos desde Unity
public class TextoSO : ScriptableObject
{
    public TemasSO temas;

    public TMP_FontAsset fuente;
    public float tamano;
}
