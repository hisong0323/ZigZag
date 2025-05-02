using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("GameStart UI")]
    [SerializeField] private FadeEffect[] fadeGameStart; // ���ӽ��� �� FadeIn �Ǿ�� �ϴ� UI��
    [SerializeField] private GameObject panelGameStart; // ���ӽ��� Panel ������Ʈ
    [SerializeField] private TextMeshProUGUI textGameStartBestScore; // ���ӽ��� �� �ְ� ���� ��¿� Text UI
    [Header("InGame UI")]
    [SerializeField] private TextMeshProUGUI textInGameScore; // ���ӿ��� ȹ���� ���� ��¿� Text UI

    [Header("GameOver UI")]
    [SerializeField] private GameObject panelGameOver; // ���ӿ��� Panel ������Ʈ
    [SerializeField] private TextMeshProUGUI textGameOverScore; //���ӿ��� �Ǿ��� �� ���ӿ��� ȹ���� ���� ��¿� Text UI
    [SerializeField] private TextMeshProUGUI textGameOverBestScore; // ���ӿ��� �Ǿ��� ���ְ� ���� ��¿� Text UI
    [SerializeField] private float timeStopTime; // �ð�����(Time.timeScale�� 0�� �� �� ���� �ҿ� �ð�

    private int currentScore = 0; // ���ӿ��� ȹ���� ���� ������

    // ���ӽ��� ���θ� ��Ÿ���� ������Ƽ
    public bool IsGameStart { private set; get; } = false;
    // ���ӿ��� ���θ� ��Ÿ���� ������Ƽ
    public bool IsGameOver { private set; get; } = false;

    private IEnumerator Start()
    {
        // �ð� ������ 1��� ����
        Time.timeScale = 1;

        // ����Ǿ� �ִ� �ְ������� �ҷ��ͼ� ���
        int bestScore = PlayerPrefs.GetInt("BestScore");
        textGameStartBestScore.text = bestScore.ToString();
        // ����Ÿ��Ʋ, "TAP TO PLAY" �ؽ�Ʈ�� FadeIn ȿ�� ���
        for (int i = 0; i < fadeGameStart.Length; i++)
        {
            fadeGameStart[i].FadeIn();
        }

        while (true)
        {
            // ���콺 ���� ��ư ������
            if (Input.GetMouseButtonDown(0))
            {
                // GameStart() �޼ҵ带 ȣ���� ���ӽ���
                GameStart();

                // �ܺ� Ŭ�������� ���ӽ����� �� �� �ֵ��� IsGameStart = true
                IsGameStart = true;

                yield break;
            }
            yield return null;
        }
    }

    public void GameStart()
    {
        // GameStart UI���� ��ġ�Ǿ� �ִ� Panel ��Ȱ��ȭ
        panelGameStart.SetActive(false);

        // InGame ���� ��¿� Text UI Ȱ��ȭ
        textInGameScore.gameObject.SetActive(true);
    }

    public void IncreaseScore(int score = 1)
    {
        // score ��ŭ ���� ����(currentScore) ����
        currentScore += score;

        // ����� ���� (currentScore) ������ Text UI�� ����
        textInGameScore.text = currentScore.ToString();
    }
    public void GameOver()
    {
        // �ܺ� Ŭ�������� ���� ������ �� �� �ֵ��� IsGameOver = true
        IsGameOver = true;

        // ���ӿ��� �Ǿ��� �� ��µǴ� ���� �������� ȹ�� ����
        textGameOverScore.text = currentScore.ToString();

        // InGame ���� ��¿� Text UI ��Ȱ��ȭ
        textInGameScore.gameObject.SetActive(false);
        // GameOver UI���� ��ġ�Ǿ� �ִ� Panel Ȱ��ȭ
        panelGameOver.SetActive(true);

        // ����Ǿ� �ִ� �ְ����� �ҷ�����
        int bestScore = PlayerPrefs.GetInt("BestScore");
        // ���� ������������ ȹ���� ������ �ְ��������� ������ �ְ����� ����
        if (currentScore > bestScore)
        {
            // currentScore ������ �ְ������� ���
            PlayerPrefs.SetInt("BestScore", currentScore);
            // currentScore ������ �ְ����� Text UI ���
            textGameOverBestScore.text = currentScore.ToString();
        }
        else
        {
            // ������ bestScore �������ְ����� Text UI�� ���
            textGameOverBestScore.text = bestScore.ToString();
        }
        // �ð� ������ 0���� ������ ������Ʈ�� ���ߴ� �ڷ�ƾ �޼ҵ� ����
        StartCoroutine(nameof(SlowAndStopTime));
    }

    private IEnumerator SlowAndStopTime()
    {
        float current = 0;
        float percent = 0;
        // �ð� ������ 0.5��� ����
        Time.timeScale = 0.5f;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / timeStopTime;

            yield return null;
        }

        // �ð� ������ 0��� ������ ������Ʈ���� ����� (Player, Tile)
        Time.timeScale = 0;
    }
}
