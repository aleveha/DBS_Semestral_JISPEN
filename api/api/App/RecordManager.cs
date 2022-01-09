using System.Collections.Generic;
using api.Core.Managers;
using api.Core.Repositories;
using api.Models;
using api.Persistence;
using api.Persistence.Repositories;

namespace api.App {
    public class RecordManager : IRecordManager {
        private readonly IRecordRepository _recordRepository;

        public RecordManager(ApplicationContext context) {
            _recordRepository = new RecordRepository(context);
        }

        public Record Get(long recordId) {
            return _recordRepository.Get(recordId);
        }

        public List<Record> GetAll(long userId) {
            return _recordRepository.GetAll(userId);
        }

        public Record Add(Record record) {
            return _recordRepository.Add(record);
        }

        public bool? Delete(long recordId) {
            return _recordRepository.Delete(recordId);
        }
    }
}
