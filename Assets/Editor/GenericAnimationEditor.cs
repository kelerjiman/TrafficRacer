using UnityEditor;
[CustomEditor(typeof(GenericAnimation))]
public class OnEditorUI : Editor
{
    GenericAnimation MyScript;
    private void OnEnable()
    {

    }
    public override void OnInspectorGUI()
    {
        MyScript = (GenericAnimation)target;
        MyScript.Types = (GenericAnimation.e_TObject)EditorGUILayout.EnumPopup("type", MyScript.Types);
        switch (MyScript.Types)
        {
            case GenericAnimation.e_TObject.image:
                ImageType();
                break;
            case GenericAnimation.e_TObject.text:
                TextType();
                break;
            case GenericAnimation.e_TObject.GameObject:
                GameObjecType();
                break;
            default:
                break;
        }
        
    }
    private void ImageType()
    {
        MyScript.during = EditorGUILayout.FloatField("During :", MyScript.during);
        MyScript.defColor = EditorGUILayout.ColorField(MyScript.defColor);
        MyScript.nextColor = EditorGUILayout.ColorField(MyScript.nextColor);
    }
    private void TextType()
    {
        MyScript.during = EditorGUILayout.FloatField("During :", MyScript.during);
        MyScript.defColor = EditorGUILayout.ColorField(MyScript.defColor);
        MyScript.nextColor = EditorGUILayout.ColorField(MyScript.nextColor);
    }
    private void GameObjecType()
    {
       MyScript.speed = EditorGUILayout.IntField("Speed : ", MyScript.speed);
    }
}
