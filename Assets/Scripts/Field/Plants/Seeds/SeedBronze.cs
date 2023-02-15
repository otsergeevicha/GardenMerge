namespace Field.Plants.Seeds
{
    public class SeedBronze : Vegetation
    {
        private const int Level = 1;

        public override int GetLevel() => 
            Level;

        public override bool IsRipe() => 
            false;

        public override void Collect() => 
            throw new System.NotImplementedException();
    }
}