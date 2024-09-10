using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhijia_ScraperConveyor : MonoBehaviour {

    [SerializeField] private Transform middle_up;
    [SerializeField] private Transform middle_bottom;

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(middle_bottom.position, middle_up.position);
    }
}
