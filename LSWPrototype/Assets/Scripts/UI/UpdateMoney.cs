using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMoney : MonoBehaviour
{
    private int goldAvailable;
    [SerializeField]
    private GameObject Player;
    void Update()
    {
        goldAvailable = Player.GetComponent<PlayerMovement>().Gold;
        gameObject.GetComponent<TextMeshProUGUI>().SetText(goldAvailable.ToString());
    }
}
