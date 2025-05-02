using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameController gameController; // ���ӽ���, ���� ���� �Ǵ��� ���� GameController
    private Movement movement; // �÷��̾� �̵� ��� ���� Movement
    private float limitDeathY; // �÷��̾ ����ϴ� �ּ� y��

    private void Awake()
    {
        movement = GetComponent<Movement>();

        // ���� �̵������� ���������� ����
        //movement.MoveTo(Vector3.right);

        // ���� �÷��̾��� y��ġ���� y/2 ũ�⸦ �� ��ŭ�� ����ϴ� y��ġ
        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (gameController.IsGameStart == true)
            {
                // ���� �̵������� ���������� ����
                movement.MoveTo(Vector3.right);
                yield break;
            }
            yield return null;
        }
    }
    private void Update()
    {
        // ���ӿ��� �����̸� �÷��̾��� ��� �ൿ ����
        if (gameController.IsGameOver == true) return;
        if (Input.GetMouseButtonDown(0))
        {
            gameController.IncreaseScore();
            // ���� �̵������� Vector3.forward(0, 0, 1)�̸� �̵������� Vector3.right(1, 0, 0)���� ����
            // ���� �̵������� Vector3.right(1, 0, 0)�̸� �̵������� Vector3.forward(0, 0, 1)���� ����
            Vector3 direction = movement.MoveDirection == Vector3.forward ? Vector3.right : Vector3.forward;
            movement.MoveTo(direction);
        }

        // �÷��̾��� y��ġ�� limitDeathY���� ������ ���ó��
        if (transform.position.y < limitDeathY)
        {
            gameController.GameOver();
        }
    }
}
