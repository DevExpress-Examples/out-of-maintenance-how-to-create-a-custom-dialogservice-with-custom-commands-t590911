using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;

namespace DXApplication5.MVVM.ViewModels {
    public class DocumentsViewModel {
        private readonly string viewNameSuffix = "View";
        public IDocumentManagerService DocumentManagerService {
            get { return this.GetRequiredService<IDocumentManagerService>(); }
        }
        public virtual DocumentType DocumentType { get; set; }
        protected void OnDocumentTypeChanged() {
            LoadDocument();
        }
        public void LoadDocument() {
            if (DocumentType != DocumentType.None && DocumentManagerService != null) {
                IDocument document = DocumentManagerService.FindDocumentByIdOrCreate(DocumentType, x => CreateDocument());
                document.Show();
            }
        }
        public void LoadDefaultDocument() {
            DocumentType = DocumentType.Customers;
        }
        IDocument CreateDocument() {
            var document = DocumentManagerService.CreateDocument(DocumentType.ToString() + viewNameSuffix, null, this);
            document.Title = DocumentType;
            document.DestroyOnClose = false;
            return document;
        }
    }
    public enum DocumentType {
        None,
        Customers
    }
}
