using System.Collections.Generic;
using api.Models;

namespace api.Core.Repositories {
    public interface IRecordRepository {
        Record Get(long recordId);
        List<Record> GetAll(long userId);
        Record Add(Record record);
        bool? Delete(long recordId);
    }
}
