namespace UdemyCourseApi.ExceptionHandler
{
    public class ProductException:Exception
    {
        private readonly int errorCode;

        public ProductException(string error ,int errorCode): base(error) {
            this.errorCode=errorCode;
        }
    }
}
