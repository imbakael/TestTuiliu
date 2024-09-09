using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TuiliuConfig", menuName = "CreateConfig/TuiliuConfig", order = 0)]
public class TuiliuConfig : ScriptableObject {

    [Header("刮板实际长度")]
    public float guabanLength;

    [Header("刮板实际宽度")]
    public float guabanWidth;

    [Header("溜槽之间的最大夹角")]
    public float maxAngle;

    [Header("弯曲段最大刮板数量")]
    public int maxN;

    [Header("顶到煤壁的推移行程")]
    public float max_to_coal_wall;

    [Header("连接头长度")]
    public float connectorLength;
}
