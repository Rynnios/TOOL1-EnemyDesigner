using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Rogue Data", menuName = "Character Data/rogue")]
//RogueData derives from CharacterData so it can use the variables defined in CharacterData
public class RogueData : CharacterData
{
    public RogueWpnType wpnType;
    public RogueStrategyType stratType;
    public dropType RogueDropType;
     
}
