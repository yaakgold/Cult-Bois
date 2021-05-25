using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Card)), CanEditMultipleObjects]
public class CardEditor : Editor
{
    Card card;

    SerializedProperty cardActionTypes;
    SerializedProperty typeOfFollowerForMana;
    int size;

    private void OnEnable()
    {
        card = target as Card;

        cardActionTypes = serializedObject.FindProperty("cardActionTypes");
        typeOfFollowerForMana = serializedObject.FindProperty("typeOfFollowerForMana");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        switch (card.cardType)
        {
            case eCardType.FOLLOWER:
                EditorGUILayout.PropertyField(typeOfFollowerForMana, new GUILayoutOption[] { });
                break;
            case eCardType.MONSTER:
                LoadInMonsterActions();
                break;
            case eCardType.INSTANT:
                LoadInMonsterActions();
                break;
            default:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void LoadInMonsterActions()
    {
        EditorGUI.indentLevel = 0;
        size = EditorGUILayout.IntField("Size", cardActionTypes.arraySize, new GUILayoutOption[] { });

        if (size != cardActionTypes.arraySize)
        {
            while (size > cardActionTypes.arraySize)
            {
                cardActionTypes.InsertArrayElementAtIndex(cardActionTypes.arraySize);
            }

            while (size < cardActionTypes.arraySize)
            {
                cardActionTypes.DeleteArrayElementAtIndex(cardActionTypes.arraySize - 1);
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
        for (int i = 0; i < cardActionTypes.arraySize; i++)
        {
            EditorGUILayout.Space();
            EditorGUI.indentLevel = 1;
            
            SerializedProperty actionType = cardActionTypes.GetArrayElementAtIndex(i).FindPropertyRelative("actionType");
            SerializedProperty amount = cardActionTypes.GetArrayElementAtIndex(i).FindPropertyRelative("amount");

            EditorGUILayout.PropertyField(actionType, new GUILayoutOption[] { });
            EditorGUILayout.PropertyField(amount, new GUILayoutOption[] { });
        }

        serializedObject.ApplyModifiedProperties();
    }
}
