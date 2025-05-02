using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // 이동속도
    [SerializeField] private float increaseAmount; // 이동속도 증가량
    [SerializeField] private float increaseCycleTime; // 이동속도 증가 시간

    private Vector3 moveDirection; // 이동방향

    // 외부에서 이동방향을 확인할 수 있도록 Get 프로퍼티 선언

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
    /// 외부에서 이동방향을 설정할 때 호출
    /// </summary>
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
