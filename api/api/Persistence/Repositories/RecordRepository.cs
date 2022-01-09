using System.Collections.Generic;
using System.Linq;
using api.Core.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence.Repositories {
    public class RecordRepository : IRecordRepository {
        private readonly ApplicationContext _context;

        public RecordRepository(ApplicationContext context) {
            _context = context;
        }

        public Record Get(long recordId) {
            return SetIncludes(_context.records).SingleOrDefault(record => record.id.Equals(recordId));
        }

        public List<Record> GetAll(long userId) {
            return SetIncludes(_context.records)
                .Where(record => record.template.user.id.Equals(userId))
                .OrderByDescending(record => record.id)
                .ToList();
        }

        public Record Add(Record record) {
            Record newRecord = new Record {
                date = record.date,
                amount = record.amount,
                templateId = record.templateId,
                wasteCompanyId = record.wasteCompanyId,
                wasteId = record.wasteId,
                loadingCodeId = record.loadingCodeId
            };
            _context.records.Add(newRecord);
            _context.SaveChanges();
            return Get(newRecord.id);
        }

        public bool? Delete(long recordId) {
            Record recordToRemove = SetIncludes(_context.records).SingleOrDefault(record => record.id.Equals(recordId));

            if (recordToRemove == null) {
                return null;
            }

            _context.records.Remove(recordToRemove);
            _context.SaveChanges();

            return !_context.records.Any(t => t.id.Equals(recordId));
        }

        private IQueryable<Record> SetIncludes(IQueryable<Record> record) {
            return record.Include(r => r.template).Include(r => r.waste).Include(r => r.loadingCode).Include(r => r.wasteCompany);
        }
    }
}
