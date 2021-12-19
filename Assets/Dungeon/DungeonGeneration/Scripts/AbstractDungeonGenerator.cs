using System.Collections.Generic;
using Combat;
using Managers.Enemies;
using UnityEngine;
using Utils;
namespace Dungeon.DungeonGeneration
{
    public abstract class AbstractDungeonGenerator
    {
        //protected AbstractDungeonGeneratorParameterSo parameters;
        protected DungeonGenerator generator;

        public AbstractDungeonGenerator(AbstractDungeonGeneratorParameterSo parameter,
            DungeonGenerator generator)
        {
            //parameters = parameter;
            this.generator = generator;
        }

        public abstract void RunProceduralGeneration();
    }
}