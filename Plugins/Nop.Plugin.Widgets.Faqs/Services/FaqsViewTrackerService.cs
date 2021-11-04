using Nop.Data;
using Nop.Plugin.Widgets.Faqs.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.Faqs.Services
{
    public interface IFaqsViewTrackerService
    {
        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        void InsertAsync(FaqsViewTrackerRecord record);
        IList<FaqsViewTrackerRecord> GetAll();
        void DeleteAsync(FaqsViewTrackerRecord data);
        Task<FaqsViewTrackerRecord> GetByIdAsync(int id);
    }
}

namespace Nop.Plugin.Widgets.Faqs.Services
{
    public class FaqsViewTrackerService : IFaqsViewTrackerService
    {
        private readonly IRepository<FaqsViewTrackerRecord> _faqsViewRecordRepository;
        public FaqsViewTrackerService(IRepository<FaqsViewTrackerRecord> faqsViewRecordRepository)
        {
            _faqsViewRecordRepository = faqsViewRecordRepository;
        }

        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        public async virtual void InsertAsync(FaqsViewTrackerRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            if (record.Id == 0) await _faqsViewRecordRepository.InsertAsync(record);
            if (record.Id > 0) await _faqsViewRecordRepository.UpdateAsync(record);
        }

        public virtual IList<FaqsViewTrackerRecord> GetAll()
        {
            return _faqsViewRecordRepository.GetAll();
        }

        public async virtual Task<FaqsViewTrackerRecord> GetByIdAsync(int id)
        {
            return await _faqsViewRecordRepository.GetByIdAsync(id);
        }

        public async virtual void DeleteAsync(FaqsViewTrackerRecord data)
        {
            await _faqsViewRecordRepository.DeleteAsync(data);
        }
    }
}