namespace Field.Plants.Seeds
{
    public class SeedEpic : Vegetation
    {
        private const int Level = 3;

        public override int GetLevel() => 
            Level;
        
        public override bool IsRipe() => 
            false;
    }
}