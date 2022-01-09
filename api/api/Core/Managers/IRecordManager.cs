using System.Collections.Generic;
using api.Models;

namespace api.Core.Managers {
    public interface IRecordManager {
        Record Get(long recordId);
        List<Record> GetAll(long userId);
        Record Add(Record record);
        bool? Delete(long recordId);
    }
}
