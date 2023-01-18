using Field.Vegetation;
using Field.Vegetation.Seeds;

namespace Services.Move
{
    public interface IServiceLanding
    {
        public void TryGetLanding(Seed seed);
    }
}