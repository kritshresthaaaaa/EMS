namespace Employee_Management_System.Application.Common.Model.Pagination
{
    public class PaginatedListResponse<T> : GenericResponse<IEnumerable<T>>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public PaginatedListResponse(IEnumerable<T> data, int currentPage, int totalPages, int totalItems)
            : base(data)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            TotalItems = totalItems;
        }
    }
}