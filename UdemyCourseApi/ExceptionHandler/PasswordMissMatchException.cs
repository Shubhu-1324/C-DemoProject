namespace UdemyCourseApi.ExceptionHandler
{
    public class PasswordMissMatchException: Exception
    {
        public PasswordMissMatchException( string message):base(message) { 
        
        }
    }

}
