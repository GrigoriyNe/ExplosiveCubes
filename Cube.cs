using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField, Min(1)] private float _explosionRadius;
    [SerializeField, Min(1)] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private LayerMask _explodible;
    [SerializeField] Cube _prefab;
    [SerializeField] MeshRenderer _meshRenderer;

    private int _chanceDivision = 100;
    private int _doubleCubesCount = 2;
    private int _decriseValue = 2;

    private void OnMouseDown()
    {
        if (CanDivide())
        {
            StartCoroutine(Create());
            Explode();
            Instantiate(_effect, transform.position, transform.rotation);
        }

        Destroy(_effect);
        Destroy(gameObject);
    }

    private Color GetColor()
    {
        List<Color> colors = new List<Color>();
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.yellow);
        colors.Add(Color.gray);
        colors.Add(Color.cyan);

        System.Random random = new System.Random();

        return colors[random.Next(0, colors.Count)];
    }

    private bool CanDivide()
    {
        System.Random random = new System.Random();
        int randomValue = random.Next(0, 100);

        if (randomValue < _chanceDivision)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _explodible, QueryTriggerInteraction.Ignore);

        foreach (Collider collider in colliders)

        {
            if (collider.TryGetComponent(out Rigidbody rigidbody) == false)
                continue;

            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1);

        }
    }

    private IEnumerator Create()
    {
        while (enabled)
        {
            for (int i = 0; i < _doubleCubesCount; i++)
            {
                Vector3 position = transform.position;

                Cube cube = Instantiate(_prefab, position, Quaternion.identity);
                Vector3 scale = cube.transform.localScale / _decriseValue;

                cube.transform.localScale = scale;
                cube._meshRenderer.material.color = GetColor();
                cube._chanceDivision /= _decriseValue;
            }

            yield return null;
        }
    }
}
