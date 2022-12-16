using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ConveniButton : MonoBehaviour {
    [Header("�\��������Web�y�[�W")] public String url;
    [Header("�ړ��������V�[��")] public String scene;
    [Header("�\���������E���������Q�[���I�u�W�F�N�g")] public GameObject gObject;
    [Header("Delay�Œx�点��������")] public float delayTime;
    [Header("�E�B���h�E�I�[�v�����܂��̓V�[���J�ڎ��ɂȂ�SE")]public AudioClip OpenSE;
    [Header("�E�B���h�E�N���[�Y���܂��̓Q�[���I�����ɂȂ�SE")]public AudioClip CloseSE;
    bool dontSeBarrage;//DelayGoT0Scene,DelayQuitScene��SE�̘A�˖h�~
    SoundManager soundManager;

    public void Start() {
        GameObject gameObject = GameObject.FindGameObjectWithTag("SoundManager");
        soundManager = gameObject.GetComponent<SoundManager>();
        dontSeBarrage = false;
    }

    /// <summary>
    /// �V�[���J��
    /// </summary>
    public void GoToScene() {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// delayTime���x��āA�V�[���J��
    /// </summary>
    public void DelayGoToScene() {
        if (OpenSE&&!dontSeBarrage) {
            soundManager.PlaySe(OpenSE);
            dontSeBarrage = true;
        }
        Invoke("GoToScene", delayTime);
    }

    /// <summary>
    /// �Q�[���I��
    /// </summary>
    public void QuitGame() {
        Application.Quit();
    }

    /// <summary>
    /// delayTime���x��āA�Q�[���I��
    /// </summary>
    public void DelayQuitGame() {
        if (CloseSE&&!dontSeBarrage) {
            soundManager.PlaySe(CloseSE);
            dontSeBarrage = true;
        }
        Invoke("QuitGame", delayTime);
    }

    /// <summary>
    /// Web�y�[�W���J��
    /// </summary>
    public void GoToWeb() {
        if (OpenSE) {
            soundManager.PlaySe(OpenSE);
        }
        Application.OpenURL(url);
    }

    /// <summary>
    /// ActiveSelf��؂�ւ���
    /// </summary>
    public void OpenOrClose() {
        if (gObject.activeSelf) {
            if (CloseSE) {
                soundManager.PlaySe(CloseSE);
            }
            gObject.SetActive(false);           
        } else {
            if (OpenSE) {
                soundManager.PlaySe(OpenSE);
            }
            gObject.SetActive(true);
        }
    }
}
