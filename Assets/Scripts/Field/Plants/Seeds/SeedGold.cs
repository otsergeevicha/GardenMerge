namespace Field.Plants.Seeds
{
    public class SeedGold : Vegetation
    {
        private const int Level = 2;

        public override int GetLevel() => 
            Level;
        
        public override bool IsRipe() => 
            false;
    }
}