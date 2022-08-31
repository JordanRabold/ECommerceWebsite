namespace ECommerceWebsite.Models
{
    public class CameraGearCatalogViewModel
    {
        public CameraGearCatalogViewModel(List<CameraGear> cGears, int lastPage, int currentPage)
        {
            CGears = cGears;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<CameraGear> CGears { get; private set; } 

        /// <summary>
        /// The last page of the catalog. Calculated by
        /// having a total number of products divided by
        /// products per page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// Current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }

    }
}
