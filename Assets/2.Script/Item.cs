using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject itemGetEffectPrefab; // ������ ȹ�� ȿ��
    private GameController gameController; // ������ ȹ��� ���� ������ ���� GameController
    private float rotateSpeed; // ������ ȸ���ӵ�

    public void SetUp(GameController gameController)
    {
        this.gameController = gameController;

        // ó�� �������� ������ �� ������ ȹ�� ȿ���� ����
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
        // �������� �÷��̾�� �ε�����
        if (other.tag.Equals("Player"))
        {
            // ������ ȹ�� ȿ�� ��ġ ���� �� Ȱ��ȭ
            itemGetEffectPrefab.transform.position = transform.position;
            itemGetEffectPrefab.SetActive(true);

            // �������� ȹ������ �� ���� ����(+5)
            gameController.IncreaseScore(5);
            // ������ ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}
