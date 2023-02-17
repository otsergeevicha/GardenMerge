namespace Field.Plants.Seeds
{
    public class SeedGold : Vegetation
    {
        private const int Level = 5;

        public override int GetLevel() => 
            Level;

        public override bool IsRipe() => 
            false;

        public override void Collect() => 
            throw new System.NotImplementedException();

        public override int PriceCollect() => 
            throw new System.NotImplementedException();
    }
}