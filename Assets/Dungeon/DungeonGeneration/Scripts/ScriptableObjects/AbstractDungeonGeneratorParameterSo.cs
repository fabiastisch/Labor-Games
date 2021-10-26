﻿using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public abstract class AbstractDungeonGeneratorParameterSo : ScriptableObject
    {
        public DungeonGeneratorType generatorType;
        public Vector2Int startPosition = Vector2Int.zero;
        
    }
}