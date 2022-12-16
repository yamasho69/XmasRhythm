using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�p�l���̃C���[�W�𑀍삷��̂ɕK�v

//�Q�lURL�@https://tama-lab.net/2017/07/unity%E3%81%A7%E3%83%95%E3%82%A7%E3%83%BC%E3%83%89%E3%82%A4%E3%83%B3%EF%BC%8F%E3%83%95%E3%82%A7%E3%83%BC%E3%83%89%E3%82%A2%E3%82%A6%E3%83%88%E3%82%92%E5%AE%9F%E8%A3%85%E3%81%99%E3%82%8B%E6%96%B9/

public class FadeController : MonoBehaviour {

	float fadeSpeed = 0.02f;        //�����x���ς��X�s�[�h���Ǘ�
	float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�

	public bool isFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
	public bool isFadeIn = false;   //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O

	Image fadeImage;                //�����x��ύX����p�l���̃C���[�W

	void Start() {
		fadeImage = GetComponent<Image>();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
	}

	void Update() {
		if (isFadeIn) {
			StartFadeIn();
		}

		if (isFadeOut) {
			StartFadeOut();
		}
	}

	void StartFadeIn() {
		alfa -= fadeSpeed;                //a)�s�����x�����X�ɉ�����
		SetAlpha();                      //b)�ύX�����s�����x�p�l���ɔ��f����
		if (alfa <= 0) {                    //c)���S�ɓ����ɂȂ����珈���𔲂���
			isFadeIn = false;
			fadeImage.enabled = false;    //d)�p�l���̕\�����I�t�ɂ���
		}
	}

	void StartFadeOut() {
		fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
		alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
		SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
		if (alfa >= 1) {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
			isFadeOut = false;
		}
	}

	void SetAlpha() {
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}