using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUIController : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public void SetAttack(Attack attack)
    {
        iconImage.sprite = attack.GetSprite();
    }
}
