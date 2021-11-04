using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.Faqs.Models.Domain;

namespace Nop.Plugin.Widgets.Faqs.Models.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("2021/11/04 00:10:10", "Widgets.Faqs base schema")]
    public class SchemaMigration : AutoReversingMigration
    {
        protected IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        public override void Up()
        {
            _migrationManager.BuildTable<FaqsViewTrackerRecord>(Create);
        }
    }
}
