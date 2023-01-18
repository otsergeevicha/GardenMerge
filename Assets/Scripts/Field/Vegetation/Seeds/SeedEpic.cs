namespace Field.Vegetation.Seeds
{
    public class SeedEpic : Seed
    {
        private const int Level = 3;

        public override int GetLevel() => 
            Level;
        
        public override bool IsRipe() => 
            false;
    }
}