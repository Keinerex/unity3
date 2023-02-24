using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HingeJoint2D))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Collider2D))]
public class Grab : MonoBehaviour
{
    private HingeJoint2D _hinge;
    private Rigidbody2D _rb;
    private Transform _tf;
    [SerializeField] public float speed = 1f;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _hinge = GetComponent<HingeJoint2D>();
        _tf = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _hinge.enabled = false;
        }

        var angle = _tf.rotation.z;
        var vector = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));

        if (Input.GetKey((KeyCode.A)))
        {
            _rb.AddForce(vector * -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(vector);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_hinge.enabled)
        {
            _hinge.enabled = true;
            _hinge.connectedBody = col.attachedRigidbody;
        }
    }
}