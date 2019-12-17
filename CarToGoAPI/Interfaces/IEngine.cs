namespace CarToGoAPI.Model
{
    public interface IEngine
    {
        float GetMaxDistance { get; set; }
        float GetCurrentDistance { get; set; }
        float GetDistanceLeft { get; set; }
        long TotalKMDriven { get; set; }
    }
}