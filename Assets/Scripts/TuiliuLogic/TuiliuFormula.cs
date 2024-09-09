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

    [Button("根据其他参数求溜槽最大数量N")]
    private void CalcN() {
        Debug.Log("N = " + TuiliuUtility.CalcN(maxS, zhongbucao_length, zhongbucao_width, maxAngle));
    }

    [Button("根据其他参数求最大推移行程S")]
    private void CalcS() {
        Debug.Log("S = " + TuiliuUtility.CalcMaxS(maxAngle, N, zhongbucao_length, zhongbucao_width));
    }
}
