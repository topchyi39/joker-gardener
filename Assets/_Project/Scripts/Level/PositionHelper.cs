using UnityEngine;

namespace Level
{
    public class PositionHelper
    {
        public static Vector3 GetRandomWorldPosition(Camera camera, float minY = 0.15f, float maxY = 0.45f)
        {
            var x = Random.Range(0.1f, 0.9f);
            var y = Random.Range(minY, maxY);
           

            var worldPosition = camera.ViewportToWorldPoint(new Vector3(x, y));
            
            worldPosition.z = 0;
            return worldPosition;
        }
    }
}