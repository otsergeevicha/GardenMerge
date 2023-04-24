namespace Field.Plants.Seeds
{
    public class SeedBronze : Vegetation
    {
        private const int Level = 1;

        public override int GetLevel() => 
            Level;

        public override void Wipe() {}

        public override bool IsRipe() => 
            false;
        
        public override float GetTimeCollect() => 0;

        public override float GetFloweringPeriod() => 0;

        public override void Collect() {}

        public override int PriceCollect() => 0;
    }
}