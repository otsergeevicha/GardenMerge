namespace Field.Vegetation.Seeds
{
    public class SeedBronze : Seed
    {
        private const int Level = 1;
        
        public override int GetLevel() => 
            Level;

        public override bool IsRipe() => 
            false;
    }
}