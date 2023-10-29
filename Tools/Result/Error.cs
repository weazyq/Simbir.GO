namespace Tools.Result
{
    public class Error
    {
        public String? Key { get; }
        public String Message { get; }

        public Error(String message)
        {
            Key = null;
            Message = message;
        }

        public Error(String key, String message)
        {
            Key = key;
            Message = message;
        }

        public override String ToString()
        {
            return String.IsNullOrEmpty(Key) ? Message : $"({Key}) {Message}";
        }

        public Error[] ToErrors() => new[] { this };
    }

    public static class ErrorsExtension
    {
        public static Error ToError(this String message) => new(message);
        public static Error[] ToErrors(this String message) => new[] { new Error(message) };
        public static List<Error> ToErrorList(this Error error) => new[] { error }.ToList();
    }
}
