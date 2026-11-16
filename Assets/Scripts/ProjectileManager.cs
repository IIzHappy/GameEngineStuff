using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance;

    public GameObject _projectile;
    [SerializeField] int _poolSize = 10;
    List<GameObject> _pool = new List<GameObject>();
    List<GameObject> _available = new List<GameObject>();


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) Destroy(this);
    }

    void Start()
    {
        InitPool();
    }

    void InitPool()
    {
        for (int i = 0; i < _poolSize; ++i)
        {
            GameObject proj = Instantiate(_projectile, transform.position, Quaternion.identity, transform);
            proj.SetActive(false);
            _pool.Add(proj);
            _available.Add(proj);
        }
    }

    public void SpawnProjectile()
    {
        GameObject proj;
        if (_available.Count > 0)
        {
            proj = _available[0];
            _available.Remove(proj);
        }
        else
        {
            proj = Instantiate(_projectile, transform.position, Quaternion.identity, transform);
            _pool.Add(proj);
        }
        proj.SetActive(true);
        proj.transform.position = PlayerController.instance.transform.position; 
    }

    public void DespawnProjectile(GameObject projectile)
    {
        _available.Add(projectile);
    }
}
