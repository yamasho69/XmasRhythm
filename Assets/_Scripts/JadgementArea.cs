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

public class JadgementArea : SerializedMonoBehaviour {
    public float radius;
    [SerializeField] GameManager gameManager = default;

    //ノーツが落ちてきたときに、キーボードを押したら判定したい
    //キー入力
    //近くにノーツがあるのか
    //どのぐらいの近さなのか
    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("Aを入力");
            RaycastHit2D hit2D = Physics2D.CircleCast(transform.position, 5, Vector3.zero);
            if (hit2D) {
                Debug.Log("ノーツがぶつかった");
                //Mathf.Absは絶対値
                float distance = Mathf.Abs(hit2D.transform.position.y - transform.position.y);
                if (distance < 3) {
                    Debug.Log("Good!");
                    gameManager.AddScore(100);
                }
                else if(distance < 5) 
                {
                    Debug.Log("まあまあ");
                    gameManager.AddScore(10);

                } else 
                {
                    Debug.Log("nomal");
                    gameManager.AddScore(5);

                }

                //ぶつかったものを破壊する
                Destroy(hit2D.collider.gameObject);
            }
        }
    }

    //可視化ツール
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}