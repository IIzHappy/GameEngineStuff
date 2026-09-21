using UnityEngine;

public class PowerBlock : Blocks
{
    public GameObject _powerUp;
    protected override void Hit()
    {
        Instantiate(_powerUp, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }
}
