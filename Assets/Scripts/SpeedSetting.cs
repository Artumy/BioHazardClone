public struct SpeedSetting
{
    public int NumberLevel;
    public float SpeedEntity;
    public float SpeedProduction;

    public SpeedSetting(int numberLevel, float speedEntity, float speedProduction)
    {
        NumberLevel = numberLevel;
        SpeedEntity = speedEntity;
        SpeedProduction = speedProduction;
    }
}
