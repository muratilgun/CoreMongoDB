using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMongoBulkCRUD.IRepository
{
    public interface IEmployeeRepository
    {
        void BulkSave();
        void BulkUpdate();
        void BulkDeleteByPropertyValue();
        void BulkDelete();
    }
}
