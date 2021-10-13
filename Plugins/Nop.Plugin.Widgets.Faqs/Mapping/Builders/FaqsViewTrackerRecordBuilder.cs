using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.Faqs.Models.Domain;

namespace Nop.Plugin.Widgets.Faqs.Models.Mapping.Builders
{
    public class FaqsViewTrackerRecordBuilder : NopEntityBuilder<FaqsViewTrackerRecord>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //map the primary key (not necessary if it is Id field)
            table.WithColumn(nameof(FaqsViewTrackerRecord.Id)).AsInt32().PrimaryKey()
            .WithColumn(nameof(FaqsViewTrackerRecord.Title)).AsString()
            .WithColumn(nameof(FaqsViewTrackerRecord.Description)).AsString();
        }
    }
}
