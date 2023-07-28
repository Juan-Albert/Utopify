using System.Collections.Generic;
using Runtime.Domain;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Scriptable
{
    [CreateAssetMenu(fileName = "CardConfig", menuName = "ScriptableObjects/CardConfig", order = 2)]
    public class CardConfig : ScriptableObject
    {
        public List<Trait.TraitType> traitTypes;
    }
}