using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // �̵��ӵ�
    [SerializeField] private float increaseAmount; // �̵��ӵ� ������
    [SerializeField] private float increaseCycleTime; // �̵��ӵ� ���� �ð�

    private Vector3 moveDirection; // �̵�����

    // �ܺο��� �̵������� Ȯ���� �� �ֵ��� Get ������Ƽ ����

    public Vector3 MoveDirection => moveDirection;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseCycleTime);
            moveSpeed += increaseAmount;
        }
    }
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// �ܺο��� �̵������� ������ �� ȣ��
    /// </summary>
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
