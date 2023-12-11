using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammod : MonoBehaviour
{
    public Camera cameraToModify;
    public bool disminuirCalidad = false;
    public int calidadActual { get; private set; } // Variable pública para almacenar la calidad actual
    public float divisionesMitad = 1f; // Número de veces que se dividirá a la mitad la calidad

    private int calidadNormal; // Guarda el nivel de calidad antes de disminuir

    void Start()
    {
        // Guardar el nivel de calidad inicial
        calidadNormal = QualitySettings.GetQualityLevel();
        calidadActual = calidadNormal; // Establecer la calidad actual al iniciar
    }

    void Update()
    {
        if (cameraToModify != null)
        {
            // Actualizar la variable calidadActual
            calidadActual = QualitySettings.GetQualityLevel();

            // Verificar si se activó el cambio de calidad
            if (disminuirCalidad)
            {
                // Disminuir la calidad múltiples veces a la mitad
                int nuevaCalidad = calidadNormal;
                for (int i = 0; i < divisionesMitad; i++)
                {
                    nuevaCalidad /= 2;
                }
                QualitySettings.SetQualityLevel(nuevaCalidad, true);
            }
            else
            {
                // Restaurar la calidad normal
                QualitySettings.SetQualityLevel(calidadNormal, true);
            }
        }
    }
}
