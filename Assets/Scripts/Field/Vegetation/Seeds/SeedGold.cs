namespace Field.Vegetation.Seeds
{
    public class SeedGold : Seed
    {
        private const int Level = 2;

        public override int GetLevel() => 
            Level;
        
        public override bool IsRipe() => 
            false;
    }
}