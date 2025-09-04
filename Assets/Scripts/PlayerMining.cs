    using UnityEngine;

public class PlayerMining : MonoBehaviour
{
    private PlayerControls controls;
    private OreScripts ore;
    public int Damage = 2;
    public float MiningRange = 5f;
    private Vector2 MiningInput = new Vector2(0.5f,0.5f);
    public LayerMask OreLayer;
    

    void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Attack.performed += ctx => OnAttack();
    }
    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }

    void OnAttack()
    {
        Debug.Log("좌클릭 입력받음");
        Ray MiningRay = Camera.main.ViewportPointToRay(MiningInput); //화면 가운데로 Ray 쏨쏨쏨쏨쏨
        RaycastHit[] hits = Physics.RaycastAll(MiningRay, MiningRange, OreLayer); // Mining 방향으로 MiningRange만큼 쏴서 OreLayer만 찾는거임!

        if (hits.Length > 0) // 충돌한 옵젝 한개 이상일때! 실행합니당당당!
        {
            Debug.Log($"RaycastAll 충돌 감지됨: {hits.Length}개 오브젝트"); //몇개 옵젝이 맞았는지 콘솔에 출력하기!

            foreach (RaycastHit hit in hits) // 모든 옵젝을 검사하기!
            {
                Debug.Log("충돌한 오브젝트: " + hit.collider.gameObject.name); 
                ore = hit.collider.GetComponent<OreScripts>();
                if (hit.collider.CompareTag("Ore"))
                {
                    if (ore != null)
                    {
                        ore.MineOre(Damage);
                        Debug.Log("체력 감소, 현재 남은 체력:" + ore.OreHealth + "광물 이름 : " + hit.collider.gameObject.name);
                    }
                }
            }
        }
        else
        {
            Debug.Log("충돌한 오브젝트 없음");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 forward = transform.forward * MiningRange;
        Gizmos.DrawRay(transform.position, forward);
    }
}