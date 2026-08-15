using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // Yunuslama (Pitch) - Yukarı / Aşağı Ok Tuşları
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, pitch);

        // Sapma (Yaw) - Sağ / Sol Ok Tuşları
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw);

        // Yatış (Roll) - Q / E Tuşları
        float roll = 0f;
        if (Input.GetKey(KeyCode.Q)) roll += rollSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) roll -= rollSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, roll);
    }

    private void HandleThrust()
    {
        // İleri İtiş - Boşluk (Space) Tuşu
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}