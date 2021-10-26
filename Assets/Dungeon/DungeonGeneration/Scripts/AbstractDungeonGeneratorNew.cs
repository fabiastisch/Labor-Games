namespace Dungeon.DungeonGeneration
{
    public abstract class AbstractDungeonGeneratorNew
    {
        protected DungeonGeneratorParameterSo parameters;
        protected DungeonGenerator generator;

        public AbstractDungeonGeneratorNew(DungeonGeneratorParameterSo parameter,
            DungeonGenerator generator)
        {
            parameters = parameter;
            this.generator = generator;
        }

        protected abstract void RunProceduralGeneration();
    }
}