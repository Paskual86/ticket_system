using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TicketSystem.Classes.Database;
using TicketSystem.Classes.MagazineProducts;

namespace TicketSystem.Classes.ViewModels
{
    public class ProductCrudModel
    {
        public ProductItem Product { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public event EventHandler<ProductItem> Closed;

        /// <summary>
        /// 
        /// </summary>
        public List<Vat> VatList => DbHelper.GetVats().ToList();

        public List<ProductCategory> ProductCategories => DbHelper.GetProductCategory().ToList();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazineItem"></param>
        public ProductCrudModel(ProductItem AProduct)
        {
            Product = AProduct;
            AcceptCommand = new SimpleCommand(o => !string.IsNullOrEmpty(AProduct.Name), o => OnClosed(AProduct));
            CancelCommand = new SimpleCommand(o => OnClosed(null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazineItem"></param>
        protected void OnClosed(ProductItem AProduct)
        {
            Closed?.Invoke(this, AProduct);
        }
    }
}
