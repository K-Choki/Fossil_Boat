using UnityEngine;

public class JewelDropItem : MonoBehaviour
{
    public GameObject[] jewelPrefabs;
    [Range(0f, 1f)]
    public float JewelDropChance;
}
