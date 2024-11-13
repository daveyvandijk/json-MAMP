using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class w 
{
        public static void LookAt2D(this Transform t, Vector3 worldPosition) {
            t.rotation = Quaternion.identity;
            t.Rotate(Vector3.forward, (Mathf.Atan2(t.position.y - worldPosition.y, t.position.x - worldPosition.x) * 180 / Mathf.PI) - 180f);
        }
        public static void LookAt2D(Transform t, Transform target)
        {
            Vector3 direction = target.position - t.position;
        
            // Bereken de hoek in graden
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
            // Stel de rotatie in, alleen op de Z-as
            t.rotation = Quaternion.Euler(0, 0, angle);
        }
        public static void LookAwayFrom2D(this Transform t, Vector3 worldPosition) {
            t.rotation = Quaternion.identity;
            t.Rotate(Vector3.forward, (Mathf.Atan2(t.position.y - worldPosition.y, t.position.x - worldPosition.x) * 180 / Mathf.PI));
        }
        public static void LookAwayFrom2D(this Transform t, Transform target) {
            t.rotation = Quaternion.identity;
            t.Rotate(Vector3.forward, (Mathf.Atan2(t.position.y - target.position.y, t.position.x - target.position.x) * 180 / Mathf.PI));
        }
}
