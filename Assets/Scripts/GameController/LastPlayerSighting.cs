using UnityEngine;

public class LastPlayerSighting : MonoBehaviour
{
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);
    public float lightHighIntensity = 0.25f;
    public float lightLowIntensity = 0f;
    public float fadeSpeed = 7f;
    public float musicFadeSpeed = 1f;

    private AlarmLight alarm;
    private Light mainLight;
    private AudioSource panicAudio;
    private AudioSource[] sirens;
    
    void Awake()
    {

        GameObject temp = GameObject.FindGameObjectWithTag(Tags.alarm);
        alarm = temp.GetComponent<AlarmLight>();
        mainLight = GameObject.FindGameObjectWithTag(Tags.mainLight).light;
        panicAudio = transform.Find("SecondaryMusic").audio;
        GameObject[] sirensGameObjects = GameObject.FindGameObjectsWithTag(Tags.siren);
        sirens = new AudioSource[sirensGameObjects.Length];

        for (int i = 0; i < sirens.Length; i++)
        {
            sirens[i] = sirensGameObjects[i].audio;
        }

    }

    void Update()
    {
       SwitchAlarms(); 
       MusicFading();
    }

    void SwitchAlarms()
    {
        alarm.alarmOn = (position != resetPosition);
        float newIntensity;
        newIntensity = position != resetPosition ? lightLowIntensity : lightHighIntensity;
        mainLight.intensity = Mathf.Lerp(mainLight.intensity, newIntensity, fadeSpeed*Time.deltaTime);
        foreach (AudioSource t in sirens)
        {
            if (position != resetPosition && !t.isPlaying)
            {
                t.Play();
            }
            else if (position == resetPosition)
            {
                t.Stop();
            }
        }
    }

    void MusicFading()
    {
        if (position != resetPosition)
        {
            audio.volume = Mathf.Lerp(audio.volume, 0f, musicFadeSpeed*Time.deltaTime);
            panicAudio.volume = Mathf.Lerp(panicAudio.volume, 0.8f, musicFadeSpeed*Time.deltaTime);
        }
        else
        {
            audio.volume = Mathf.Lerp(audio.volume, 0.8f, musicFadeSpeed * Time.deltaTime);
            panicAudio.volume = Mathf.Lerp(panicAudio.volume, 0f, musicFadeSpeed * Time.deltaTime);
        }
        
    }




}
