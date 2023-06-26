using System.Collections.Generic;
using UnityEngine;

namespace Project.AppFrontendDomain.Modules
{
    public class LevelsModuleSettings : ScriptableObject
    {
        [SerializeField]
        private List<GameObject> _levelsPrefabs;

        public List<GameObject> LevelsPrefabs => _levelsPrefabs;
    }
}