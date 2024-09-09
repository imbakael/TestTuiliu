using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuiliuFormula : MonoBehaviour {

    [SerializeField] private float zhongbucao_length;
    [SerializeField] private float zhongbucao_width;
    [SerializeField] private float maxAngle;
    [SerializeField] private float maxS;
    [SerializeField] private int N;

    [Button("������������������������N")]
    private void CalcN() {
        Debug.Log("N = " + TuiliuUtility.CalcN(maxS, zhongbucao_length, zhongbucao_width, maxAngle));
    }

    [Button("����������������������г�S")]
    private void CalcS() {
        Debug.Log("S = " + TuiliuUtility.CalcMaxS(maxAngle, N, zhongbucao_length, zhongbucao_width));
    }
}
