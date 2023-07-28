using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Scriptable
{
    [CreateAssetMenu(fileName = "BoardConfig", menuName = "ScriptableObjects/BoardConfig", order = 1)]
    public class BoardConfig : ScriptableObject
    {
        public int columns;
        public int rows;
    }
}