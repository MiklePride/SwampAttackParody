using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    private int _shotsCountPerClick = 3;
    private float _durationBetweenShots = 0.05f;
    private Coroutine _fireBurst;

    public override void Shoot(Transform shootPoint)
    {
        if (_fireBurst != null)
            StopCoroutine(_fireBurst);

        _fireBurst = StartCoroutine(FireBurst(shootPoint));
    }

    private IEnumerator FireBurst(Transform shootPoint) 
    {
        var waitForSeconds = new WaitForSeconds(_durationBetweenShots);

        for (int i = 0; i < _shotsCountPerClick; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            yield return waitForSeconds;
        }
    }
}
