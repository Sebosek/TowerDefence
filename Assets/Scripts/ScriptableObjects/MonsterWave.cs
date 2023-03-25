using UnityEngine;

[CreateAssetMenu(menuName = "Game Mechanics/Monster Wave")]
public class MonsterWave : ScriptableObject
{
    public int MaxMonstersOnScreen;

    public GameObject[] Monsters;
}
