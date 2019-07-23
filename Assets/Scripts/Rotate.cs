using UnityEngine;
 
 public class Rotate : MonoBehaviour
 {
     private float angVelocity = 0.5f;
 
     void FixedUpdate()
     {
         //plane for position
         Plane playerPlane = new Plane(Vector3.up, transform.position);
 
         //ray starting at mouse pos
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
         //collision point for ray and plane
         float hitdist = 0.0f;
         //if the ray is parallel to the plane, Raycast will return false.
         if (playerPlane.Raycast(ray, out hitdist))
         {
             // Get the point along the ray that hits the calculated distance.
             Vector3 targetPoint = ray.GetPoint(hitdist);
 
             // Determine the target rotation.  This is the rotation if the transform looks at the target point.
             Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
 
             // Smoothly rotate towards the target point.
             transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angVelocity * Time.deltaTime);
         }
     }
 }