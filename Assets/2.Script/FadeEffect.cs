using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private float fadeTime = 0.5f; // ���̵� ȿ������ �Ϸ�Ǵ� �ð�
    [SerializeField] private AnimationCurve fadeCurve; // ���̵� ȿ�Ȱ� ����Ǵ� ����
                                                       // ������ �ƴ� �Ӽ����� ������ �� ���

    private TextMeshProUGUI fadeText; // ���̵� ȿ���� ����Ǵ� Text UI

    private float endAlpha; // ���̵� ȿ�� ��� �Ϸ� �� Alpha ��

    private void Awake()
    {
        fadeText = GetComponent<TextMeshProUGUI>();

        // UI���� ���� �����Ǿ� �ִ� ���İ��� �ٸ��� ������ FadIn�� ����Ǵ� ���İ���  ���� ����
        endAlpha = fadeText.color.a;
    }

    public void FadeIn()
    {
        // UI�� ���İ��� 0���� 1��
        StartCoroutine(Fade(0, endAlpha));
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = fadeText.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            fadeText.color = color;

            yield return null;
        }
    }
}
