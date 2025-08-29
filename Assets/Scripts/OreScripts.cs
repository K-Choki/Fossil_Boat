using UnityEngine;

public class OreScripts : MonoBehaviour
{
    public int OreHealth;
    public void MineOre(int Damage)
    {
        OreHealth -= Damage;
        if (OreHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}