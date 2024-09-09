using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TuiliuConfig", menuName = "CreateConfig/TuiliuConfig", order = 0)]
public class TuiliuConfig : ScriptableObject {

    [Header("�ΰ�ʵ�ʳ���")]
    public float guabanLength;

    [Header("�ΰ�ʵ�ʿ��")]
    public float guabanWidth;

    [Header("���֮������н�")]
    public float maxAngle;

    [Header("���������ΰ�����")]
    public int maxN;

    [Header("����ú�ڵ������г�")]
    public float max_to_coal_wall;

    [Header("����ͷ����")]
    public float connectorLength;
}
