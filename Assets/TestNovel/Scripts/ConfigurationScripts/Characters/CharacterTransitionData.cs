using System;
using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Characters/CharacterTransitionData", fileName = "CharacterTransitionData")]
    public class CharacterTransitionData : ScriptableObject
    {
        public ETransitionType MovementTransition;
        public TransitionCoordinate From;
        public TransitionCoordinate To;
        
        public ETransitionType TransparencyTransition;
        public float StartTransparency = float.NaN;
        public float EndTransparency;

        public float Duration = 0.15f;
    }

    [Serializable]
    public class TransitionCoordinate
    {
        public const float MostLeftPoint = -1f;
        public const float MostRightPoint = 2f;
        public const float MaxWidth = MostRightPoint - MostLeftPoint;
        
        public EScreenPosition presetPosition;
        [Range(MostLeftPoint, MostRightPoint)] public float xCoordinate = float.NaN;

        public static float CoordinateMapping(EScreenPosition position, float actualValue)
        {
            return position switch
            {
                EScreenPosition.Custom => actualValue,
                EScreenPosition.LeftOffTheScreen => MostLeftPoint,
                EScreenPosition.MaxLeft => 0f,
                EScreenPosition.LeftQuarter => 0.25f,
                EScreenPosition.MiddleOfLeftQuarter => 0.125f,
                EScreenPosition.RightQuarter => 0.75f,
                EScreenPosition.MiddleOfRightQuarter => 0.875f,
                EScreenPosition.MaxRight => 1f,
                EScreenPosition.RightOffTheScreen => MostRightPoint,
                _ => throw new ArgumentOutOfRangeException(nameof(position), position, null)
            };
        }
    }

    public enum EScreenPosition
    {
        Custom,
        LeftOffTheScreen,
        MaxLeft,
        LeftQuarter,
        MiddleOfLeftQuarter,
        RightQuarter,
        MiddleOfRightQuarter,
        MaxRight,
        RightOffTheScreen,
    }

    public enum ETransitionType
    {
        None,
        Smooth,
        Constant,
    }
}