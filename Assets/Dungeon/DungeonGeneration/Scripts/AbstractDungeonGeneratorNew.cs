namespace Dungeon.DungeonGeneration
{
    public abstract class AbstractDungeonGeneratorNew
    {
        //protected AbstractDungeonGeneratorParameterSo parameters;
        protected DungeonGenerator generator;

        public AbstractDungeonGeneratorNew(AbstractDungeonGeneratorParameterSo parameter,
            DungeonGenerator generator)
        {
            //parameters = parameter;
            this.generator = generator;
        }

        public abstract void RunProceduralGeneration();
    }
}