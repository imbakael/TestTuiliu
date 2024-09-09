using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TuiliuUtility {
    /// <summary>
    /// 计算弯曲段刮板数量N，引用自：《自动化工作面刮板输送机横向移动矩形模型计算方法》作者：李昊
    /// </summary>
    /// <param name="S">推移行程</param>
    /// <param name="guabanLength">刮板长度</param>
    /// <param name="guabanWidth">刮板宽度</param>
    /// <param name="angle">溜槽之间的夹角</param>
    /// <returns></returns>
    public static float CalcN(float S, float guabanLength, float guabanWidth, float angle) {
        float halfAngle = angle / 2f;
        float b = 2 * guabanWidth * Sin(halfAngle);
        float arcos = Acos(Cos(halfAngle) - (2 * S * Sin(halfAngle)) / (2 * guabanLength + b * Cos(halfAngle)));
        return 2 * arcos / angle - 1;
    }

    /// <summary>
    /// 计算弯曲段数量N时的推移行程最大值，引用自：《自动化工作面刮板输送机横向移动矩形模型计算方法》作者：李昊
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="N"></param>
    /// <param name="guabanLength"></param>
    /// <param name="guabanWidth"></param>
    /// <returns></returns>
    public static float CalcMaxS(float angle, int N, float guabanLength, float guabanWidth) {
        float halfAngle = angle / 2f;
        float b = 2 * guabanWidth * Sin(halfAngle);
        float first = Cos(halfAngle) - Cos((N + 1) * halfAngle);
        float second = 2 * Sin(halfAngle);
        float three = 2 * guabanLength + b * Cos(halfAngle);
        return first * three / second;
    }

    public static float CalcMaxS(int N) {
        return CalcMaxS(ConfigManager.TuiliuConfig.maxAngle, N, ConfigManager.TuiliuConfig.guabanLength, ConfigManager.TuiliuConfig.guabanWidth);
    }

    public static float CalcAnyMaxS(int N) {
        return CalcAnyMaxS(N, ConfigManager.TuiliuConfig.maxAngle, N, ConfigManager.TuiliuConfig.guabanLength, ConfigManager.TuiliuConfig.guabanWidth);
    }

    /// <summary>
    /// 计算弯曲段任意刮板的右下角的最大推移行程
    /// </summary>
    /// <param name="index">索引值，索引值从1 ~ N对应的推移行程从小到大</param>
    /// <param name="N">弯曲段最大刮板数</param>
    /// <returns></returns>
    public static float CalcAnyMaxS(int index, int N) {
        return CalcAnyMaxS(index, ConfigManager.TuiliuConfig.maxAngle, N, ConfigManager.TuiliuConfig.guabanLength, ConfigManager.TuiliuConfig.guabanWidth);
    }

    /// <summary>
    /// 计算弯曲段任意刮板的右下角的最大推移行程
    /// </summary>
    /// <param name="index">索引值，索引值从1 ~ N对应的推移行程从小到大</param>
    /// <param name="angle">最大旋转角</param>
    /// <param name="N">弯曲段最大刮板数</param>
    /// <param name="guabanLength">刮板长度</param>
    /// <param name="guabanWidth">刮板宽度</param>
    /// <returns></returns>
    public static float CalcAnyMaxS(int index, float angle, int N, float guabanLength, float guabanWidth) {
        float sum = 0;
        for (int i = 1; i <= index; i++) {
            float theta = GetAngleTime(i, N) * angle;
            float jiajiao = GetJiajiao(i, N, angle);
            sum += guabanLength * Sin(theta) + guabanWidth * (1 - Cos(jiajiao));
        }
        return sum;
    }

    /// <summary>
    /// 获得刮板机长度方向与水平轴的夹角 与 刮板夹角的倍数 θ(i) = θ(N - i + 1)
    /// </summary>
    /// <param name="index"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    public static int GetAngleTime(int index, int N) {
        if (index > (N + 1) / 2) {
            return N - index + 1;
        } else {
            return index;
        }
    }

    /// <summary>
    /// 根据index和N计算刮板与左侧刮板的夹角
    /// </summary>
    /// <param name="index"></param>
    /// <param name="N"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    private static float GetJiajiao(int index, int N, float angle) {
        if (N % 2 == 0 && (index == ((N / 2) + 1))) {
            return 0;
        }
        return angle;
    }

    public static float Sin(float angle) {
        return Mathf.Sin(angle * Mathf.Deg2Rad);
    }

    public static float Cos(float angle) {
        return Mathf.Cos(angle * Mathf.Deg2Rad);
    }

    public static float Asin(float value) {
        return Mathf.Asin(value) * Mathf.Rad2Deg;
    }

    public static float Acos(float value) {
        return Mathf.Acos(value) * Mathf.Rad2Deg;
    }
}
