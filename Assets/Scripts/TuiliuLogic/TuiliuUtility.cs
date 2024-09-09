using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TuiliuUtility {
    /// <summary>
    /// ���������ιΰ�����N�������ԣ����Զ���������ΰ����ͻ������ƶ�����ģ�ͼ��㷽�������ߣ����
    /// </summary>
    /// <param name="S">�����г�</param>
    /// <param name="guabanLength">�ΰ峤��</param>
    /// <param name="guabanWidth">�ΰ���</param>
    /// <param name="angle">���֮��ļн�</param>
    /// <returns></returns>
    public static float CalcN(float S, float guabanLength, float guabanWidth, float angle) {
        float halfAngle = angle / 2f;
        float b = 2 * guabanWidth * Sin(halfAngle);
        float arcos = Acos(Cos(halfAngle) - (2 * S * Sin(halfAngle)) / (2 * guabanLength + b * Cos(halfAngle)));
        return 2 * arcos / angle - 1;
    }

    /// <summary>
    /// ��������������Nʱ�������г����ֵ�������ԣ����Զ���������ΰ����ͻ������ƶ�����ģ�ͼ��㷽�������ߣ����
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
    /// ��������������ΰ�����½ǵ���������г�
    /// </summary>
    /// <param name="index">����ֵ������ֵ��1 ~ N��Ӧ�������г̴�С����</param>
    /// <param name="N">���������ΰ���</param>
    /// <returns></returns>
    public static float CalcAnyMaxS(int index, int N) {
        return CalcAnyMaxS(index, ConfigManager.TuiliuConfig.maxAngle, N, ConfigManager.TuiliuConfig.guabanLength, ConfigManager.TuiliuConfig.guabanWidth);
    }

    /// <summary>
    /// ��������������ΰ�����½ǵ���������г�
    /// </summary>
    /// <param name="index">����ֵ������ֵ��1 ~ N��Ӧ�������г̴�С����</param>
    /// <param name="angle">�����ת��</param>
    /// <param name="N">���������ΰ���</param>
    /// <param name="guabanLength">�ΰ峤��</param>
    /// <param name="guabanWidth">�ΰ���</param>
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
    /// ��ùΰ�����ȷ�����ˮƽ��ļн� �� �ΰ�нǵı��� ��(i) = ��(N - i + 1)
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
    /// ����index��N����ΰ������ΰ�ļн�
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
