using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameController gameController; // Ÿ�ϰ� �԰� �����Ǵ� �����ۿ� �����ϱ� ���� GameController
    [SerializeField] private GameObject tilePrefab; // �ʿ� ��ġ�Ǵ� Ÿ�� ������
    [SerializeField] private Transform currentTile; // ���� Ÿ�� Transform ����
                                                    // (���ο� Ÿ���� ���� ��ġ ������ ���)
    [SerializeField] private int spawnTileCountAtStart = 100; // ������ ������ �� �����Ǵ� Ÿ�� ����

    private void Awake()
    {
        for (int i = 0; i < spawnTileCountAtStart; ++i)
        {
            CreateTile();
        }
    }

    private void CreateTile()
    {
        // tilePrefab ������Ʈ ����
        GameObject clone = Instantiate(tilePrefab);
        // ������ Ÿ���� �θ� ������Ʈ "TileSpawner"�μ���
        clone.transform.SetParent(transform);
        // Ÿ���� ����� �� TileSpawner�� �ʿ��ϱ� ������ Setup() �޼ҵ� �Ű������� �Ѱ��ش�
        clone.GetComponent<Tile>().Setup(this);
        // ������ Setup() �޼ҵ� �Ű������� GameController ����
        clone.transform.GetChild(1).GetComponent<Item>().SetUp(gameController);
        SpawnTile(clone.transform);
    }

    public void SpawnTile(Transform tile)
    {
        // �����Ϸ��� Ÿ���� ���̵��� ����
        tile.gameObject.SetActive(true);

        // 0, 1 �� ������ ���� ����
        // 0�� ������ currentTile�� �����ʿ� 
        // 1�� ������ currentTile�� ���ʿ� Ÿ�� ��ġ
        int index = Random.Range(0, 2);
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;
        tile.position = currentTile.position + addPosition;

        // �������� ������ tiledmf currentTile�� ���� (���� Ÿ���� ��ġ�� �� ��ġ ���� Ȱ��)
        currentTile = tile;

        // 20%�� Ȯ���� Ÿ���� �ڽ����� ��ġ�Ǿ� �ִ� ������ ������Ʈ Ȱ��ȭ
        int spawnItem = Random.Range(0, 100);
        if(spawnItem < 20)
        {
            tile.GetChild(1).gameObject.SetActive(true);
        }
    }
}
