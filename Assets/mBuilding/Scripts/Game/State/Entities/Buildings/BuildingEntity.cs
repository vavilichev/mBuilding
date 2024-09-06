using System;
using mBuilding.Scripts.Game.State.Entities;
using UnityEngine;

namespace mBuilding.Scripts.Game.State.Buildings
{
    [Serializable]
    public class BuildingEntity : Entity
    {
        public string TypeId;
        public Vector3Int Position;
        public int Level;
    }
}