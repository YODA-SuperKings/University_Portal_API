using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IDocumentService
    {
        List<Document> GetDocument();
        string CreateDocument(Document _Document);
        void Update(string id, string regCode, Document document);
    }
}
