using Xyz.Core.Models;

namespace Xyz.Core.Entities.Multitenancy
{
    public class TenantPlan
    {
        public Guid Id { get; set; } = default!;
        public SubscriptionRenewalRate RenewalRate { get; set; } = default!;
        public int MaxUserCount { get; set; }

        public decimal Price { get; set; }

        public Tenant Tenant { get; set; } = default!;

        public Guid PlanId { get; set; } = default!;
        public Plan Plan { get; set; } = default!;
    }
}