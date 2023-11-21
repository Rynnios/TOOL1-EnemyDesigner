using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Warrior Data", menuName = "Character Data/warrior")]
//WarriorData derives from CharacterData so it can use the variables defined in CharacterData
public class WarriorData : CharacterData
{
    public WarriorWpnType wpnType;
    public WarriorClassType classType;
    public dropType WarriorDropType;

}
