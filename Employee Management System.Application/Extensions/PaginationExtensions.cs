using Employee_Management_System.Application.Common.Model.Pagination;

namespace Employee_Management_System.Application.Extensions
{
    public static class PaginationExtensions
    {
        public static PaginatedListResponse<T> ToPaginatedListResponse<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var totalItems = source.Count(); 
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize); 

            var data = source.Skip((pageNumber - 1) * pageSize).Take(pageSize); 

            var paginatedResponse = new PaginatedListResponse<T>(data, pageNumber, totalPages, totalItems);
            return paginatedResponse;
        }
    }
}
