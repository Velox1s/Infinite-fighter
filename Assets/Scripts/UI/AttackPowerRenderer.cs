using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class AttackPowerRenderer : MonoBehaviour {
    [SerializeField]
    private Player player;

    private Text text;

    private void Start () {
        text = GetComponent<Text>();
    }

    private void Update () {
        text.text = $"Attack Power: {player.GetAttackPower()}";
    }
}
