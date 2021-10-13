using Nop.Data;
using Nop.Plugin.Widgets.Faqs.Models.Domain;
using System;
using System.Collections.Generic;

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
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            await _faqsViewRecordRepository.InsertAsync(record);
        }

        public  virtual IList<FaqsViewTrackerRecord> GetAll()
        {
            return _faqsViewRecordRepository.GetAll();
        }
    }
}