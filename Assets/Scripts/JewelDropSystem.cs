using UnityEngine;

public class JewelDrop : MonoBehaviour
{
    public GameObject[] jewels;
    public void DropJewel()
    {
        if (jewels.Length == 0) return;

        foreach (var jewel in jewels)
        {
            // 광물 드롭 및 확률계산 로직
        }
    }
}

