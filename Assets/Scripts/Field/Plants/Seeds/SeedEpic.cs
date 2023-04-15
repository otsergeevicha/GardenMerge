namespace Field.Plants.Seeds
{
    public class SeedEpic : Vegetation
    {
        private const int Level = 9;

        public override int GetLevel() => 
            Level;

        public override bool IsRipe() => 
            false;

        public override float GetTimeCollect() => 0;

        public override float GetFloweringPeriod() => 0;

        public override void Collect() {}

        public override int PriceCollect() => 0;
    }
}