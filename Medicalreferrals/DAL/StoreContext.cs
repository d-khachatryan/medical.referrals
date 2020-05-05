using Medicalreferrals.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Medicalreferrals.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection")
        {
        }

        //CatalogTables
        public DbSet<BudgetLine> BudgetLines { get; set; }
        public DbSet<ChangeBase> ChangeBases { get; set; }
        public DbSet<SocialGroup> SocialGroups { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<SocialDisease> SocialDiseases { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<IdentificatorType> IdentificatorTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<OrganizationHead> OrganizationHeads { get; set; }
        public DbSet<OrganizationReferralStore> OrganizationReferralStores { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }
        public DbSet<InvocationPurpose> InvocationPurposes { get; set; }
        public DbSet<ReferralPurpose> ReferralPurposes { get; set; }
        public DbSet<InvocationStatus> InvocationStatuses { get; set; }
        public DbSet<ReferralStatus> ReferralStatuses { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<InitiationType> InitiationTypes { get; set; }
        //CatalogTables

        //Tables
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<ReferralDistribution> ReferralDistributions { get; set; }
        public DbSet<BudgetOrganization> BudgetOrganizations { get; set; }
        public DbSet<ReferralDistributionOrganization> ReferralDistributionOrganizations { get; set; }
        public DbSet<OrganizationBudgetLine> OrganizationBudgetLines { get; set; }

        public DbSet<BudgetOrganizationLog> BudgetOrganizationLogs { get; set; }
        public DbSet<ReferralDistributionOrganizationLog> ReferralDistributionOrganizationLogs { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<ReferralService> ReferralServices { get; set; }

        public DbSet<ReferralExamination> ReferralExaminations { get; set; }
        public DbSet<ReferralSurgery> ReferralSurgeries { get; set; }
        public DbSet<ReferralProcedure> ReferralProcedures { get; set; }
        public DbSet<ReferralConsultation> ReferralConsultations { get; set; }
        public DbSet<ReferralOrder> ReferralOrders { get; set; }

        public DbSet<ReferralSocialGroup> ReferralSocialGroups { get; set; }
        public DbSet<ReferralSocialDisease> ReferralSocialDiseases { get; set; }
        public DbSet<ReferralDocument> ReferralDocuments { get; set; }
        public DbSet<Invocation> Invocations { get; set; }
        public DbSet<InvocationDocument> InvocationDocuments { get; set; }


        //Tables

        //Views
        public DbSet<BudgetLineItem> BudgetLineItems { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<ReferralDistributionItem> ReferralDistributionItems { get; set; }
        public DbSet<BudgetOrganizationItem> BudgetOrganizationItems { get; set; }
        public DbSet<ReferralDistributionOrganizationItem> ReferralDistributionOrganizationItems { get; set; }
        public DbSet<BudgetOrganizationLogItem> BudgetOrganizationLogItems { get; set; }
        public DbSet<ReferralDistributionOrganizationLogItem> ReferralDistributionOrganizationLogItems { get; set; }
        //public DbSet<ReferralServiceItem> ReferralServiceItems { get; set; }
        //public DbSet<ReferralExaminationItem> ReferralExaminationItems { get; set; }
        //public DbSet<ReferralSurgeryItem> ReferralSurgeryItems { get; set; }
        //public DbSet<ReferralProcedureItem> ReferralProcedureItems { get; set; }
        //public DbSet<ReferralConsultationItem> ReferralConsultationItems { get; set; }
        public DbSet<ReferralOrderItem> ReferralOrderItems { get; set; }
        public DbSet<OrganizationBudgetLineItem> OrganizationBudgetLineItems { get; set; }

        public DbSet<ReferralItem> ReferralItems { get; set; }
        public DbSet<PhysicianItem> PhysicianItems { get; set; }
        public DbSet<ReferralSocialGroupItem> ReferralSocialGroupItems { get; set; }
        public DbSet<ReferralSocialDiseaseItem> ReferralSocialDiseaseItems { get; set; }
        public DbSet<ReferralDocumentItem> ReferralDocumentItems { get; set; }
        public DbSet<OrganizationItem> OrganizationItems { get; set; }
        public DbSet<OrganizationReferralStoreItem> OrganizationReferralStoreItems { get; set; }
        public DbSet<UserRoleItem> UserRoleItems { get; set; }
        public DbSet<UserOrganizationItem> UserOrganizationItems { get; set; }
        public DbSet<InvocationItem> InvocationItems { get; set; }
        public DbSet<InvocationDocumentItem> InvocationDocumentItems { get; set; }

        public DbSet<InvocationChart> InvocationCharts { get; set; }
        //Views

        //Stored Procedures

        //Stored Procedures

        //log
        public DbSet<InvocationLogItem> InvocationLogItems { get; set; }
        
        public DbSet<InvocationDocumentLogItem> InvocationDocumentLogItems { get; set; }

        public DbSet<ReferralLogItem> ReferralLogItems { get; set; }

        public DbSet<ReferralConsultationLogItem> ReferralConsultationLogItems { get; set; }
        
        public DbSet<ReferralDocumentLogItem> ReferralDocumentLogItems { get; set; }

        public DbSet<ReferralExaminationLogItem> ReferralExaminationLogItems { get; set; }

        public DbSet<ReferralOrderLogItem> ReferralOrderLogItems { get; set; }

        public DbSet<ReferralProcedureLogItem> ReferralProcedureLogItems { get; set; }

        public DbSet<ReferralServiceLogItem> ReferralServiceLogItems { get; set; }

        public DbSet<ReferralSocialDiseaseLogItem> ReferralSocialDiseaseLogItems { get; set; }

        public DbSet<ReferralSocialGroupLogItem> ReferralSocialGroupLogItems { get; set; }

        public DbSet<ReferralSurgeryLogItem> ReferralSurgeryLogItems { get; set; }
        //log

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}

