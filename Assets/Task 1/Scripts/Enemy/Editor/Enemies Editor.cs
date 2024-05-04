using UnityEditor;

[CustomEditor(typeof(EnemyManager))]
public class EnemiesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();

        SerializedProperty enemiesList = serializedObject.FindProperty("enemies");

        for (int i = 0; i < enemiesList.arraySize; i++)
        {
            SerializedProperty enemyProp = enemiesList.GetArrayElementAtIndex(i);

            SerializedProperty canShootProp = enemyProp.FindPropertyRelative("canShoot");
            canShootProp.boolValue = EditorGUILayout.Toggle($"Is Enemy Index {i} Can Shoot", canShootProp.boolValue);

            if (canShootProp.boolValue)
            {
                EditorGUILayout.PropertyField(enemyProp.FindPropertyRelative("bulletPrefab"));
                EditorGUILayout.PropertyField(enemyProp.FindPropertyRelative("bulletSpeed"));
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}