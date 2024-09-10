using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraperConveyor : MonoBehaviour {

    [SerializeField] private Transform[] corners;
    [SerializeField] private Transform bottom_middle;

    public Transform GetCorner(CornerType cornerType) {
        return corners[(int)cornerType];
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        for (int i = 0; i < corners.Length; i++) {
            if (i == corners.Length - 1) {
                Gizmos.DrawLine(corners[i].position, corners[0].position);
            } else {
                Gizmos.DrawLine(corners[i].position, corners[i + 1].position);
            }
        }

        Gizmos.color = Color.yellow;
        if (bottom_middle != null) {
            
        }
    }
}
