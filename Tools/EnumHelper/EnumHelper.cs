namespace Tools.EnumHelper;

public static class EnumHelper
{
    public static T GenEnum<T>(string value) where T : Enum
    {
        if (Enum.IsDefined(typeof(T), value))
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        throw new ArgumentException($"Значение {value} не является допустимым значением перечисления {typeof(T).FullName}");
    }
}
