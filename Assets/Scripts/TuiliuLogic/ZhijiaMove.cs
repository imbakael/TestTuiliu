using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhijiaMove : MonoBehaviour {

    [SerializeField] private Transform[] corners;

    [SerializeField] private Transform selfRoot;

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        for (int i = 0; i < corners.Length; i++) {
            if (i == corners.Length - 1) {
                Gizmos.DrawLine(corners[i].position, corners[0].position);
            } else {
                Gizmos.DrawLine(corners[i].position, corners[i + 1].position);
            }
        }

    }
}
