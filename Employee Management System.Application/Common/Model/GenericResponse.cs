using Employee_Management_System.Application.Common.Model.Error;

namespace Employee_Management_System.Application.Common.Model
{
    public class GenericResponse<T> : Response
    {
        public T? Data { get; set; }

        public GenericResponse()
        {
        }

        public GenericResponse(T data)
        {
            Data = data;
        }

        public static implicit operator GenericResponse<T>(T data)
        {
            return new GenericResponse<T> { Data = data };
        }

        public static implicit operator GenericResponse<T>(ErrorModel error)
        {
            return new GenericResponse<T> { Error = error };
        }
    }
}
