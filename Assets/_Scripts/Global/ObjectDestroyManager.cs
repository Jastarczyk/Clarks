using UnityEngine;
using System.Collections;
using System.Linq;

[RequireComponent(typeof(AudioSource))]

public class ObjectDestroyManager : MonoBehaviour
{
    public bool PlayRandomizedSound = true;
    [SerializeField] private AudioClip[] HitSoundCollection;
    [SerializeField] private AudioClip[] DestroySoundCollection;

    [SerializeField]
    private int maximumObjectEndurance;
    private int currentObjectEndurance;
    private AudioSource localAudioSource;

    private void Awake()
    {
        localAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {

        CheckClipCollectionValidation(HitSoundCollection);
        CheckClipCollectionValidation(DestroySoundCollection);

        localAudioSource.clip = HitSoundCollection.FirstOrDefault();
        currentObjectEndurance = maximumObjectEndurance;
    }

    private void LateUpdate()
    {
        if (currentObjectEndurance <= 0)
        {
            Destroy(gameObject, 0.2f);
        }
    }

    public void DealDamage(int damage)
    {
        currentObjectEndurance -= TakeDamage(damage);
    }

    private int TakeDamage(int damageValue)
    {
        localAudioSource.clip = PlayRandomizedSound? GetRandomizedHitSound(HitSoundCollection) : GetSelectedHitSound(HitSoundCollection.FirstOrDefault());
        localAudioSource.Play();

        return damageValue;
    }

    private void OnDestroy()
    {
        localAudioSource.clip = PlayRandomizedSound ? GetRandomizedHitSound(DestroySoundCollection) : GetSelectedHitSound(DestroySoundCollection.FirstOrDefault());
        localAudioSource.Play();
    }

    private AudioClip GetSelectedHitSound(AudioClip selectedClip)
    {
        return localAudioSource.clip = selectedClip;
    }

    private AudioClip GetRandomizedHitSound(AudioClip[] clipCollection)
    {
        int randomClip = UnityEngine.Random.Range(0, clipCollection.Length);
        return localAudioSource.clip = clipCollection[randomClip];
    }

    private bool CheckClipCollectionValidation(AudioClip[] clipCollection)
    {
        if (!clipCollection.Any())
        {
            Debug.LogError(string.Format("No audio clip attached to object destroy script " +
                "|| name: {0} || parent: {1} || position: {2}", gameObject.name, gameObject.transform.parent, gameObject.transform.position));

            return false;
        }
        return true;
    }
}
