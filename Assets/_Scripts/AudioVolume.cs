using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour {
    public AudioMixer audioMixer;//�I�[�f�B�I�~�L�T�[��o�^
    public Slider bGMSlider;//BGM�̃X���C�_�[��o�^
    public Slider sESlider;//SE�̃X���C�_�[��o�^

    private void Start() {
        //BGM��SE�̃X���C�_�[�̈ʒu�����[�h�B�f�[�^���Ȃ���΍ő�l������B
        float bgmSliderPosition = ES3.Load<float>("BGM_SLIDER", 5.0f);
        float seSliderPosition = ES3.Load<float>("SE_SLIDER", 5.0f);
        //BGM��SE�̃Z�b�g���\�b�h���Ăяo��
        SetBGM(bgmSliderPosition);
        SetSE(seSliderPosition);
    }

    public void SetBGM(float bgmSliderPosition) {
        //�X���C�_�[�̈ʒu���瑊�Ηʂ�dB�ɕϊ�����volume�ɓ����
        var volume = Mathf.Clamp(Mathf.Log10(bgmSliderPosition/5) * 20f, -80f, 0f);
        //�X���C�_�[�̈ʒu�̃f�[�^�ƃr�W���A�������킹��
        bGMSlider.value = bgmSliderPosition;
        //�I�[�f�B�I�~�L�T�[��volume�̒l���Z�b�g����B
        audioMixer.SetFloat("BGM", volume);
        //�X���C�_�[�̈ʒu���Z�[�u����B
        ES3.Save<float>("BGM_SLIDER", bGMSlider.value);
    }

    public void SetSE(float seSliderPosition) {
        var volume = Mathf.Clamp(Mathf.Log10(seSliderPosition/ 5) * 20f, -80f, 0f);
        sESlider.value = seSliderPosition;
        audioMixer.SetFloat("SE", volume);
        ES3.Save<float>("SE_SLIDER", sESlider.value);
    }
}