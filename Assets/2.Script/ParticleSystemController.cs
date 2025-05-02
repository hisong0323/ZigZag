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
        // 파티클 오브젝트가 활성화되면 파티클 재생
        particle.Play();
    }

    private void Update()
    {
        // 파티클의 재생이 완료되면 파티클 오브젝트 비활성화
        if (particle.isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }
}
