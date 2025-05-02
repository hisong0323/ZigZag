using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        // ��ƼŬ ������Ʈ�� Ȱ��ȭ�Ǹ� ��ƼŬ ���
        particle.Play();
    }

    private void Update()
    {
        // ��ƼŬ�� ����� �Ϸ�Ǹ� ��ƼŬ ������Ʈ ��Ȱ��ȭ
        if (particle.isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }
}
