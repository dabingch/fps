using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzlePosition;

    [SerializeField]
    private ParticleSystem _fireParticle;

    [SerializeField]
    private GameObject _fireSound;

    [SerializeField]
    private Animator _fireAnim;

    public void Fire()
    {
        _fireParticle.Emit(1000);

        var sound = Instantiate(_fireSound, _muzzlePosition.position, Quaternion.identity);
        sound.GetComponent<AudioSource>().Play();
        Destroy(sound, sound.GetComponent<AudioSource>().clip.length);

        _fireAnim.SetTrigger("shoot");
        
    }
}
