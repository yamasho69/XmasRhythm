using UnityEngine;
using UnityEditor;
using System;

[InitializeOnLoad]
public class SetJavaHomeEditor {
    //����N���`�F�b�N�p�_�~�[�t�@�C���p�X
    static readonly string tempFilePath = "Temp/SetJavaHomeEditor_InitFlag";

    static SetJavaHomeEditor() {
        //����N���iFile�����邩�j�`�F�b�N
        if (System.IO.File.Exists(tempFilePath) == true) {
            //�_�~�[�t�@�C�������ɂ���̂ňȍ~�̏����X�L�b�v
            return;
        }

        Debug.Log("SetJavaHomeEditor ����N���`�F�b�N�p�_�~�[�t�@�C���쐬");
        System.IO.File.Create(tempFilePath);

        //����N������JAVA_HOME�p�X
        Debug.Log($"SetJavaHomeEditor JAVA_HOME in editor was: {Environment.GetEnvironmentVariable("JAVA_HOME")}");

        string newJDKPath = EditorApplication.applicationPath.Replace("Unity.app", "PlaybackEngines/AndroidPlayer/OpenJDK");

        if (Environment.GetEnvironmentVariable("JAVA_HOME") != newJDKPath) {
            //JAVA_HOME �p�X��������
            Environment.SetEnvironmentVariable("JAVA_HOME", newJDKPath);
        }
        //�����������JAVA_HOME�p�X
        Debug.Log($"SetJavaHomeEditor JAVA_HOME in editor set to: { Environment.GetEnvironmentVariable("JAVA_HOME")}");
    }
}