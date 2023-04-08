using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalanceInfo", menuName = "Balance/New BalanceInfo")]
public class BalanceInfo : ScriptableObject
{
    [SerializeField] private int _tree_HP;
    [SerializeField] private int _level2_Price;
    [SerializeField] private int _level3_Price;
    [SerializeField] private int _axe1_damage;
    [SerializeField] private int _axe2_damage;
    [SerializeField] private int _axe3_damage;

    public int tree_HP => _tree_HP;
    public int level2_Price => _level2_Price;
    public int level3_Price => _level3_Price;
    public int axe1_damage => _axe1_damage;
    public int axe2_damage => _axe2_damage;
    public int axe3_damage => _axe3_damage;
}
