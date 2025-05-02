using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName = "")
    {
        // �Ű������� ��������� ���� ���� �ٽ� �ε�
        if (sceneName == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // �Ű������� ������� ������ �Ű������� �Էµ� ���ڿ��� �� �ε�
        else
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
