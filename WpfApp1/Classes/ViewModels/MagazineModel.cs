using System;
using System.Windows.Input;
using TicketSystem.Classes.MagazineProducts;

namespace TicketSystem.Classes.ViewModels
{
    public class MagazineModel
    {
        public MagazineItem Magazine { get; set; }
        public ProductItem Product { get; set; }

        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public MagazineModel(ProductItem AProduct, MagazineItem AMagazineItem)
        {
            Product = AProduct;
            Magazine = AMagazineItem;
            if (Magazine == null)
            {
                Magazine = new MagazineItem();
            }
            AcceptCommand = new SimpleCommand(o => !string.IsNullOrEmpty(AProduct.Name), o => {
                Magazine.MagazineProducts.Add(new MagazineProduct() { ProductId = Product.Id });
                OnClosed(Magazine); });
            CancelCommand = new SimpleCommand(o => OnClosed(null));
        }


        public event EventHandler<MagazineItem> Closed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazineItem"></param>
        protected void OnClosed(MagazineItem AMagazineItem)
        {
            Closed?.Invoke(this, AMagazineItem);
        }
    }
}
