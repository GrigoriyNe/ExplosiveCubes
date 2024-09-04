using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] Cube _prefab;

    private Spawn _spawn;
    private int _explosionForce = 10;
    private int _explosionRadius = 10;
    private int _chanceDivision = 100;

    public int ChanceDivision => _chanceDivision;

    private void Awake()
    {
        _spawn = GetComponent<Spawn>();
    }

    public void Initialisation(Color color, int chanceDivide, Vector3 scale)
    {
        _meshRenderer.material.color = color;
        _chanceDivision = chanceDivide;
        transform.localScale = scale;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private void OnMouseDown()
    {
        if (CanDivide())
        {
            _spawn.Create(_prefab);
        }

        Destroy(gameObject);
    }

    private bool CanDivide()
    {
        System.Random random = new System.Random();
        int randomValue = random.Next(0, 100);

        return randomValue < _chanceDivision;
    }
}
