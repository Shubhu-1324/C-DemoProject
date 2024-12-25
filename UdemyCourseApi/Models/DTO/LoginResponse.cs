namespace UdemyCourseApi.Models.DTO
{
    public class LoginResponse
    {
       public  string? JwtToken {  get; set; }
       public string? Email { get; set; }    

       public string? Id { get; set; }   

        public string? Phonenumber { get; set; } 
    }
}
