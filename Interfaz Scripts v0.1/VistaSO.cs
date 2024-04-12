using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomUI/VistaSO", fileName = "VistaSO")] //para configurar desde Unity
public class VistaSO : ScriptableObject
{
    public TemasSO temas;
    public RectOffset padding;
    public float spacing;
}
