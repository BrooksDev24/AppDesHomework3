using System.Collections.Generic;
using GadgetHub.Domain.Entities;

namespace GadgetHub.WebUI.Models
{
    public class ProductsListViewModels
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}