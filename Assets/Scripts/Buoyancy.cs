using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float buoyancyForce = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WaterSurface"))
        {
            // Apply an upward force to counteract gravity
            GetComponent<Rigidbody>().AddForce(Vector3.up * buoyancyForce, ForceMode.Acceleration);
        }
    }
}
