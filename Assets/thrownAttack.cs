using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class thrownAttack : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject player;
    public GameObject bigBad;
    public GameObject swordPrefab;
    private float coolTime = 3f;


    public bool _canThrow = false;

    public bool canThrow
    {
        get { return _canThrow; }
        private set
        {
            _canThrow = value;
            bigBad.GetComponent<Blucifer>().animator.SetBool(AnimationStrings.canThrow, value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (coolTime > 0)
        {
            coolTime -= Time.deltaTime;
        }
        if ((coolTime <= 0) && (Mathf.Abs(player.transform.position.x - transform.position.x) > 8))
        {
            canThrow = true;
            coolTime = 3f;
            Instantiate(swordPrefab, throwPoint.position, throwPoint.rotation);
        }
        else
        {
            canThrow = false;
        }
    }
}
