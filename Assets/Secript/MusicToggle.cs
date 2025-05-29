using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public GameObject sliderPanel;         // السلايدر أو الحاوية التي تحتويه
    public AudioSource musicSource;        // الصوت الذي نتحكم فيه
    public Slider volumeSlider;            // السلايدر نفسه

    private bool isSliderVisible = false;

    void Start()
    {
        // sliderPanel.SetActive(false);  // إخفاء السلايدر في البداية
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeSlider.value = musicSource.volume;
    }

    // هذا يُربط بزر الأيقونة
    // public void ToggleSlider()
    // {
    //     isSliderVisible = !isSliderVisible;
    //     sliderPanel.SetActive(isSliderVisible);
    // }

    // التحكم في مستوى الصوت
    void ChangeVolume(float value)
    {
        musicSource.volume = value;
    }
}
