using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName ="New Mage Data", menuName ="Character Data/mage")]
//MageData derives from CharacterData so it can use the variables defined in CharacterData
public class MageData : CharacterData
{
    public MageDmgType dmgType;
    public MageWpnType wpnType;
    public dropType MageDropType;

}
