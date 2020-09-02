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
