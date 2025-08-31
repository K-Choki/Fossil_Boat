using UnityEngine;

public class PlayerMining : MonoBehaviour
{
    private PlayerControls controls;
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
        Ray MiningRay = Camera.main.ViewportPointToRay(MiningInput); //viewport(0.5f,0.5f)
        RaycastHit[] hits = Physics.RaycastAll(MiningRay, MiningRange, OreLayer);

        if (hits.Length > 0)
        {
            Debug.Log($"RaycastAll 충돌 감지됨: {hits.Length}개 오브젝트");

            foreach (RaycastHit hit in hits)
            {
                Debug.Log("충돌한 오브젝트: " + hit.collider.gameObject.name);
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