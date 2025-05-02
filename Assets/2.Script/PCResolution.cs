using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCResolution : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1080, 1920, false);
    }
}

/// <summary>
/// ������ �����ϰ� ���� ���� ����Ǵ� Ŭ������ �޼ҵ忡��
/// Screen.SetResolution(1080, 1920, true); �� ���� �ػ󵵸� ������ �� �ֽ��ϴ�.
/// �Ű����� => (����, ����, FullScreen ����)
/// 
/// ���� �پ��� �ػ� ������ ���� �Ʒ��� ���� ���� ���µ�
/// ����ó�� PC���� �� ��ũ������ �������� ��쿡�� �ػ� ���� �Է��ϸ�
/// ��/�� ���� �κ��� ������ ȭ������ ó���˴ϴ�.
/// Screen.SetResolution(Screen.width, Screen.width * 16/9, false);
/// </summary>
