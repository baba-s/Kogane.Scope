# UniScope

開始と終了がある処理を using ステートメントで使用できるようにすることで終了処理の呼び出し漏れを防ぐ機能

## 使用例

### AssetEditingScope

```cs
// 通常
AssetDatabase.StartAssetEditing();
//...
AssetDatabase.StopAssetEditing();

// UniScope
using ( new AssetEditingScope() )
{
    //...
}
```

### HandlesColorScope

```cs
// 通常
var oldColor = Handles.color;
Handles.color = Color.white;
//...
Handles.color = oldColor;

// UniScope
using ( new HandlesColorScope( Color.white ) )
{
    //...
}
```

### LoadPrefabContentsScope

```cs
// 通常
var prefab = PrefabUtility.LoadPrefabContents( "Assets/Cube.prefab" );

prefab.AddComponent<BoxCollider>();

PrefabUtility.SaveAsPrefabAsset( prefab, "Assets/Cube.prefab" );
PrefabUtility.UnloadPrefabContents( prefab );

// UniScope
using ( var scope = new LoadPrefabContentsScope( "Assets/Cube.prefab" ) )
{
    scope.Prefab.AddComponent<BoxCollider>();
    scope.IsSave = true;
}
```

### LogScope

```cs
#if ENABLE_RELEASE

// リリースビルドの時はログ出力を無効化
LogScope.OnStart    = null;
LogScope.OnComplete = null;

#else

LogScope.OnStart    = message => Debug.Log( $"{message} 開始" );
LogScope.OnComplete = message => Debug.Log( $"{message} 終了" );

#endif

using ( new LogScope( "ピカチュウ" ) )
{
    Debug.Log( "カイリュー" );
    Debug.Log( "ヤドラン" );
    Debug.Log( "ピジョン" );
}
```

### LockReloadAssembliesScope

```cs
// 通常
EditorApplication.LockReloadAssemblies();
//...
EditorApplication.UnlockReloadAssemblies();

// UniScope
using ( new LockReloadAssembliesScope() )
{
    //...
}
```

### SceneSetupScope

```cs
// 通常
var oldSetup = EditorSceneManager.GetSceneManagerSetup();
//...
EditorSceneManager.RestoreSceneManagerSetup( oldSetup );

// UniScope
using ( new SceneSetupScope() )
{
    //...
}
```

### CustomSamplerScope

```cs
// 通常
var sampler = CustomSampler.Create( "タグ" );
sampler.Begin();
//...
sampler.End();

// UniScope
using ( new CustomSamplerScope( "タグ" ) )
{
    //...
}
```

### GUIColorScope

```cs
// 通常
var oldColor = GUI.color;
GUI.color = Color.white;
//...
GUI.color = oldColor;

// UniScope
using ( new GUIColorScope( Color.white ) )
{
    //...
}
```

### LabelWidthScope

```cs
// 通常
var oldLabelWidth = EditorGUIUtility.labelWidth;
EditorGUIUtility.labelWidth = 32;
EditorGUILayout.TextField( "Name", "ピカチュウ" );
EditorGUIUtility.labelWidth = oldLabelWidth;

// UniScope
using ( new LabelWidthScope( 32 ) )
{
    EditorGUILayout.TextField( "Name", "ピカチュウ" );
}
```

### ProgressScope

```cs
using Kogane;
using System.Collections;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

public sealed class Example : EditorWindow
{
    [MenuItem( "Tools/Open" )]
    private static void Open()
    {
        GetWindow<Example>();
    }

    private void OnGUI()
    {
        if ( GUILayout.Button( "開始" ) )
        {
            EditorCoroutineUtility.StartCoroutine( OnUpdate(), this );
        }
    }

    private static IEnumerator OnUpdate()
    {
        const int count = 2000;

        using ( var scope = new ProgressScope( "ここにタスク名" ) )
        {
            for ( var i = 0; i < count; i++ )
            {
                scope.Report
                (
                    currentStep: i,
                    totalSteps: count,
                    description: $"{i + 1} / {count}"
                );

                yield return null;
            }
        }
    }
}
```
