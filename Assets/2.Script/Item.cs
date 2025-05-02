using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject itemGetEffectPrefab; // 아이템 획득 효과
    private GameController gameController; // 아이템 획득시 점수 증가를 위한 GameController
    private float rotateSpeed; // 아이템 회전속도

    public void SetUp(GameController gameController)
    {
        this.gameController = gameController;

        // 처음 아이템이 생성될 때 아이템 획득 효과를 생성
        itemGetEffectPrefab = Instantiate(itemGetEffectPrefab, transform.position, Quaternion.identity);
        itemGetEffectPrefab.SetActive(false);
    }

    private void OnEnable()
    {
        rotateSpeed = Random.Range(10, 100);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 0) * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 아이템이 플레이어와 부딪히면
        if (other.tag.Equals("Player"))
        {
            // 아이템 획득 효과 위치 설정 및 활성화
            itemGetEffectPrefab.transform.position = transform.position;
            itemGetEffectPrefab.SetActive(true);

            // 아이템을 획득했을 때 점수 증가(+5)
            gameController.IncreaseScore(5);
            // 아이템 오브젝트 비활성화
            gameObject.SetActive(false);
        }
    }
}
