namespace Field.Plants.Seeds
{
    public class SeedBronze : Vegetation
    {
        private const int Level = 1;

        public override int GetLevel() => 
            Level;

        public override bool IsRipe() => 
            false;
        
        public override float GetTimeCollect() => 
            throw new System.NotImplementedException();

        public override float GetFloweringPeriod() => 
            throw new System.NotImplementedException();
        
        public override void Collect() => 
            throw new System.NotImplementedException();

        public override int PriceCollect() => 
            throw new System.NotImplementedException();
    }
}