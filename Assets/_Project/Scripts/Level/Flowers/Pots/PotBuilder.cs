using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Level.Flowers.Pots
{
    [Serializable]
    public class PotBuilder
    {
        [SerializeField] private Pot prefab;
        
        public Pot Spawn(Flower flower, Camera camera, Transform parent)
        {
            var bound = prefab.View.PotBounds;
            var position = PositionHelper.GetRandomWorldPosition(camera);
            var pot = Object.Instantiate(prefab, position, Quaternion.identity, parent);

            pot.Init(flower);
            return pot;
        }
    }
}