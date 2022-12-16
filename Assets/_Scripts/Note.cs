#region
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;//SerializedMonoBehaviourを使うのに必要
//using DG.Tweening;//DoTween使用時に必要
#endregion

#region
/* odinInspector用
Dictionaryもシリアライズ出来るように
[SerializeField]private Dictionary<string, int> _dict = new Dictionary<string, int>(){{"Key1", 1},{"Key2", 2}

編集できないように、プロパティまで表示
[ReadOnly,ShowInInspector]public Vector3 ShowInInspectorVector3{get;set;}

[LabelText("自由な名前に")]public string LabelTextTest = "LabelTextTest";

Indent (インデントの設定)[Indent(1)]public bool Indent1 = false; [Indent(2)]public bool Indent2 = false;

メソッドを実行するボタン[Button("押して！")]private void OnClick() {Debug.Log("押した！");}

BoxGroup(ボックスグループ化)[BoxGroup("グループ1")]public int A, B, C;
FoldoutGroup(フォルダーグループ化)[FoldoutGroup("グループ1")]public int A, B, C;
TabGroup(タブグループ化) [TabGroup("グループ1")]public int A, B, C;
*/
#endregion

public class Note : SerializedMonoBehaviour {
	public float speed;

	private void Update () {
		transform.Translate(0, -speed*Time.deltaTime, 0);
	}
}