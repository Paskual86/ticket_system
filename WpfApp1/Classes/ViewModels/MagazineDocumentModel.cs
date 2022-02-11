using System;
using System.Windows.Input;
using TicketSystem.Classes.MagazineProducts;

namespace TicketSystem.Classes.ViewModels
{
    public class MagazineDocumentModel
    {
        public MagazineDocumentType DocumentType { get; set; }

        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public event EventHandler<MagazineDocumentType> Closed;


        public MagazineDocumentModel()
        {
            DocumentType = new MagazineDocumentType();
            AcceptCommand = new SimpleCommand(o => DocumentType.Id>0, o => OnClosed(DocumentType));
            CancelCommand = new SimpleCommand(o => OnClosed(null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazineItem"></param>
        protected void OnClosed(MagazineDocumentType AMagazineDocumentType)
        {
            Closed?.Invoke(this, AMagazineDocumentType);
        }
    }
}
