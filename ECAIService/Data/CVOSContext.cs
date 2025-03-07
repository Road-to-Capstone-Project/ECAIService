using System;
using System.Collections.Generic;

using ECAIService.MLModelTables;
using ECAIService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECAIService.Data;

public partial class CVOSContext : DbContext
{
    public CVOSContext()
    {

    }

    public CVOSContext(DbContextOptions<CVOSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VariantTextEmbedding> VariantTextEmbeddings { get; set; }

    public virtual DbSet<ApiKey> ApiKeys { get; set; }

    public virtual DbSet<AuthIdentity> AuthIdentities { get; set; }

    public virtual DbSet<Capture> Captures { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartAddress> CartAddresses { get; set; }

    public virtual DbSet<CartLineItem> CartLineItems { get; set; }

    public virtual DbSet<CartLineItemAdjustment> CartLineItemAdjustments { get; set; }

    public virtual DbSet<CartLineItemTaxLine> CartLineItemTaxLines { get; set; }

    public virtual DbSet<CartPaymentCollection> CartPaymentCollections { get; set; }

    public virtual DbSet<CartPromotion> CartPromotions { get; set; }

    public virtual DbSet<CartShippingMethod> CartShippingMethods { get; set; }

    public virtual DbSet<CartShippingMethodAdjustment> CartShippingMethodAdjustments { get; set; }

    public virtual DbSet<CartShippingMethodTaxLine> CartShippingMethodTaxLines { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }

    public virtual DbSet<CustomerGroupCustomer> CustomerGroupCustomers { get; set; }

    public virtual DbSet<Fulfillment> Fulfillments { get; set; }

    public virtual DbSet<FulfillmentAddress> FulfillmentAddresses { get; set; }

    public virtual DbSet<FulfillmentItem> FulfillmentItems { get; set; }

    public virtual DbSet<FulfillmentLabel> FulfillmentLabels { get; set; }

    public virtual DbSet<FulfillmentProvider> FulfillmentProviders { get; set; }

    public virtual DbSet<FulfillmentSet> FulfillmentSets { get; set; }

    public virtual DbSet<GeoZone> GeoZones { get; set; }

    public virtual DbSet<GoogleplayAppVector> GoogleplayAppVectors { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    public virtual DbSet<InventoryLevel> InventoryLevels { get; set; }

    public virtual DbSet<Invite> Invites { get; set; }

    public virtual DbSet<LinkModuleMigration> LinkModuleMigrations { get; set; }

    public virtual DbSet<LocationFulfillmentProvider> LocationFulfillmentProviders { get; set; }

    public virtual DbSet<LocationFulfillmentSet> LocationFulfillmentSets { get; set; }

    public virtual DbSet<MikroOrmMigration> MikroOrmMigrations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationProvider> NotificationProviders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderAddress> OrderAddresses { get; set; }

    public virtual DbSet<OrderCart> OrderCarts { get; set; }

    public virtual DbSet<OrderChange> OrderChanges { get; set; }

    public virtual DbSet<OrderChangeAction> OrderChangeActions { get; set; }

    public virtual DbSet<OrderClaim> OrderClaims { get; set; }

    public virtual DbSet<OrderClaimItem> OrderClaimItems { get; set; }

    public virtual DbSet<OrderClaimItemImage> OrderClaimItemImages { get; set; }

    public virtual DbSet<OrderCreditLine> OrderCreditLines { get; set; }

    public virtual DbSet<OrderExchange> OrderExchanges { get; set; }

    public virtual DbSet<OrderExchangeItem> OrderExchangeItems { get; set; }

    public virtual DbSet<OrderFulfillment> OrderFulfillments { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }

    public virtual DbSet<OrderLineItemAdjustment> OrderLineItemAdjustments { get; set; }

    public virtual DbSet<OrderLineItemTaxLine> OrderLineItemTaxLines { get; set; }

    public virtual DbSet<OrderPaymentCollection> OrderPaymentCollections { get; set; }

    public virtual DbSet<OrderPromotion> OrderPromotions { get; set; }

    public virtual DbSet<OrderShipping> OrderShippings { get; set; }

    public virtual DbSet<OrderShippingMethod> OrderShippingMethods { get; set; }

    public virtual DbSet<OrderShippingMethodAdjustment> OrderShippingMethodAdjustments { get; set; }

    public virtual DbSet<OrderShippingMethodTaxLine> OrderShippingMethodTaxLines { get; set; }

    public virtual DbSet<OrderSummary> OrderSummaries { get; set; }

    public virtual DbSet<OrderTransaction> OrderTransactions { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentCollection> PaymentCollections { get; set; }

    public virtual DbSet<PaymentMethodToken> PaymentMethodTokens { get; set; }

    public virtual DbSet<PaymentProvider> PaymentProviders { get; set; }

    public virtual DbSet<PaymentSession> PaymentSessions { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<PriceList> PriceLists { get; set; }

    public virtual DbSet<PriceListRule> PriceListRules { get; set; }

    public virtual DbSet<PricePreference> PricePreferences { get; set; }

    public virtual DbSet<PriceRule> PriceRules { get; set; }

    public virtual DbSet<PriceSet> PriceSets { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductCollection> ProductCollections { get; set; }

    public virtual DbSet<ProductOption> ProductOptions { get; set; }

    public virtual DbSet<ProductOptionValue> ProductOptionValues { get; set; }

    public virtual DbSet<ProductSalesChannel> ProductSalesChannels { get; set; }

    public virtual DbSet<ProductTag1> ProductTags1 { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<ProductVariantInventoryItem> ProductVariantInventoryItems { get; set; }

    public virtual DbSet<ProductVariantPriceSet> ProductVariantPriceSets { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromotionApplicationMethod> PromotionApplicationMethods { get; set; }

    public virtual DbSet<PromotionCampaign> PromotionCampaigns { get; set; }

    public virtual DbSet<PromotionCampaignBudget> PromotionCampaignBudgets { get; set; }

    public virtual DbSet<PromotionRule> PromotionRules { get; set; }

    public virtual DbSet<PromotionRuleValue> PromotionRuleValues { get; set; }

    public virtual DbSet<ProviderIdentity> ProviderIdentities { get; set; }

    public virtual DbSet<PublishableApiKeySalesChannel> PublishableApiKeySalesChannels { get; set; }

    public virtual DbSet<Refund> Refunds { get; set; }

    public virtual DbSet<RefundReason> RefundReasons { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegionCountry> RegionCountries { get; set; }

    public virtual DbSet<RegionPaymentProvider> RegionPaymentProviders { get; set; }

    public virtual DbSet<ReservationItem> ReservationItems { get; set; }

    public virtual DbSet<Return> Returns { get; set; }

    public virtual DbSet<ReturnFulfillment> ReturnFulfillments { get; set; }

    public virtual DbSet<ReturnItem> ReturnItems { get; set; }

    public virtual DbSet<ReturnReason> ReturnReasons { get; set; }

    public virtual DbSet<SalesChannel> SalesChannels { get; set; }

    public virtual DbSet<SalesChannelStockLocation> SalesChannelStockLocations { get; set; }

    public virtual DbSet<ServiceZone> ServiceZones { get; set; }

    public virtual DbSet<ShippingOption> ShippingOptions { get; set; }

    public virtual DbSet<ShippingOptionPriceSet> ShippingOptionPriceSets { get; set; }

    public virtual DbSet<ShippingOptionRule> ShippingOptionRules { get; set; }

    public virtual DbSet<ShippingOptionType> ShippingOptionTypes { get; set; }

    public virtual DbSet<ShippingProfile> ShippingProfiles { get; set; }

    public virtual DbSet<StockLocation> StockLocations { get; set; }

    public virtual DbSet<StockLocationAddress> StockLocationAddresses { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreCurrency> StoreCurrencies { get; set; }

    public virtual DbSet<TaxProvider> TaxProviders { get; set; }

    public virtual DbSet<TaxRate> TaxRates { get; set; }

    public virtual DbSet<TaxRateRule> TaxRateRules { get; set; }

    public virtual DbSet<TaxRegion> TaxRegions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkflowExecution> WorkflowExecutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("vector");

        modelBuilder
            .HasPostgresEnum("claim_reason_enum", new[] { "missing_item", "wrong_item", "production_failure", "other" })
            .HasPostgresEnum("order_claim_type_enum", new[] { "refund", "replace" })
            .HasPostgresEnum("order_status_enum", new[] { "pending", "completed", "draft", "archived", "canceled", "requires_action" })
            .HasPostgresEnum("return_status_enum", new[] { "open", "requested", "received", "partially_received", "canceled" })
            .HasPostgresExtension("vector");

        modelBuilder.Entity<ApiKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("api_key_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_api_key_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<AuthIdentity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_identity_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_auth_identity_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Capture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("capture_pkey");

            entity.HasIndex(e => e.PaymentId, "IDX_capture_payment_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Payment).WithMany(p => p.Captures).HasConstraintName("capture_payment_id_foreign");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_pkey");

            entity.HasIndex(e => e.BillingAddressId, "IDX_cart_billing_address_id").HasFilter("((deleted_at IS NULL) AND (billing_address_id IS NOT NULL))");

            entity.HasIndex(e => e.CustomerId, "IDX_cart_customer_id").HasFilter("((deleted_at IS NULL) AND (customer_id IS NOT NULL))");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.RegionId, "IDX_cart_region_id").HasFilter("((deleted_at IS NULL) AND (region_id IS NOT NULL))");

            entity.HasIndex(e => e.SalesChannelId, "IDX_cart_sales_channel_id").HasFilter("((deleted_at IS NULL) AND (sales_channel_id IS NOT NULL))");

            entity.HasIndex(e => e.ShippingAddressId, "IDX_cart_shipping_address_id").HasFilter("((deleted_at IS NULL) AND (shipping_address_id IS NOT NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.CartBillingAddresses)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cart_billing_address_id_foreign");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.CartShippingAddresses)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cart_shipping_address_id_foreign");
        });

        modelBuilder.Entity<CartAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_address_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_address_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<CartLineItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_line_item_pkey");

            entity.HasIndex(e => e.CartId, "IDX_cart_line_item_cart_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_line_item_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.CartId, "IDX_line_item_cart_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ProductId, "IDX_line_item_product_id").HasFilter("((deleted_at IS NULL) AND (product_id IS NOT NULL))");

            entity.HasIndex(e => e.ProductTypeId, "IDX_line_item_product_type_id").HasFilter("((deleted_at IS NULL) AND (product_type_id IS NOT NULL))");

            entity.HasIndex(e => e.VariantId, "IDX_line_item_variant_id").HasFilter("((deleted_at IS NULL) AND (variant_id IS NOT NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsCustomPrice).HasDefaultValue(false);
            entity.Property(e => e.IsDiscountable).HasDefaultValue(true);
            entity.Property(e => e.IsTaxInclusive).HasDefaultValue(false);
            entity.Property(e => e.RequiresShipping).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartLineItems).HasConstraintName("cart_line_item_cart_id_foreign");
        });

        modelBuilder.Entity<CartLineItemAdjustment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_line_item_adjustment_pkey");

            entity.HasIndex(e => e.ItemId, "IDX_adjustment_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_line_item_adjustment_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ItemId, "IDX_cart_line_item_adjustment_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.PromotionId, "IDX_line_item_adjustment_promotion_id").HasFilter("((deleted_at IS NULL) AND (promotion_id IS NOT NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Item).WithMany(p => p.CartLineItemAdjustments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cart_line_item_adjustment_item_id_foreign");
        });

        modelBuilder.Entity<CartLineItemTaxLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_line_item_tax_line_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_line_item_tax_line_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ItemId, "IDX_cart_line_item_tax_line_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.TaxRateId, "IDX_line_item_tax_line_tax_rate_id").HasFilter("((deleted_at IS NULL) AND (tax_rate_id IS NOT NULL))");

            entity.HasIndex(e => e.ItemId, "IDX_tax_line_item_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Item).WithMany(p => p.CartLineItemTaxLines)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cart_line_item_tax_line_item_id_foreign");
        });

        modelBuilder.Entity<CartPaymentCollection>(entity =>
        {
            entity.HasKey(e => new { e.CartId, e.PaymentCollectionId }).HasName("cart_payment_collection_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<CartPromotion>(entity =>
        {
            entity.HasKey(e => new { e.CartId, e.PromotionId }).HasName("cart_promotion_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<CartShippingMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_shipping_method_pkey");

            entity.HasIndex(e => e.CartId, "IDX_cart_shipping_method_cart_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_shipping_method_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.CartId, "IDX_shipping_method_cart_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ShippingOptionId, "IDX_shipping_method_option_id").HasFilter("((deleted_at IS NULL) AND (shipping_option_id IS NOT NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsTaxInclusive).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartShippingMethods).HasConstraintName("cart_shipping_method_cart_id_foreign");
        });

        modelBuilder.Entity<CartShippingMethodAdjustment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_shipping_method_adjustment_pkey");

            entity.HasIndex(e => e.ShippingMethodId, "IDX_adjustment_shipping_method_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_shipping_method_adjustment_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ShippingMethodId, "IDX_cart_shipping_method_adjustment_shipping_method_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.PromotionId, "IDX_shipping_method_adjustment_promotion_id").HasFilter("((deleted_at IS NULL) AND (promotion_id IS NOT NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.CartShippingMethodAdjustments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cart_shipping_method_adjustment_shipping_method_id_foreign");
        });

        modelBuilder.Entity<CartShippingMethodTaxLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cart_shipping_method_tax_line_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_cart_shipping_method_tax_line_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ShippingMethodId, "IDX_cart_shipping_method_tax_line_shipping_method_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.TaxRateId, "IDX_shipping_method_tax_line_tax_rate_id").HasFilter("((deleted_at IS NULL) AND (tax_rate_id IS NOT NULL))");

            entity.HasIndex(e => e.ShippingMethodId, "IDX_tax_line_shipping_method_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.CartShippingMethodTaxLines)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cart_shipping_method_tax_line_shipping_method_id_foreign");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("currency_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DecimalDigits).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_customer_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.Email, e.HasAccount }, "IDX_customer_email_has_account_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.HasAccount).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_address_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_customer_address_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.CustomerId, "IDX_customer_address_unique_customer_billing")
                .IsUnique()
                .HasFilter("(is_default_billing = true)");

            entity.HasIndex(e => e.CustomerId, "IDX_customer_address_unique_customer_shipping")
                .IsUnique()
                .HasFilter("(is_default_shipping = true)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDefaultBilling).HasDefaultValue(false);
            entity.Property(e => e.IsDefaultShipping).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Customer).WithOne(p => p.CustomerAddress).HasConstraintName("customer_address_customer_id_foreign");
        });

        modelBuilder.Entity<CustomerGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_group_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_customer_group_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Name, "IDX_customer_group_name")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Name, "IDX_customer_group_name_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<CustomerGroupCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_group_customer_pkey");

            entity.HasIndex(e => e.CustomerGroupId, "IDX_customer_group_customer_customer_group_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_customer_group_customer_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.CustomerGroup).WithMany(p => p.CustomerGroupCustomers).HasConstraintName("customer_group_customer_customer_group_id_foreign");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerGroupCustomers).HasConstraintName("customer_group_customer_customer_id_foreign");
        });

        modelBuilder.Entity<Fulfillment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fulfillment_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_fulfillment_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.LocationId, "IDX_fulfillment_location_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ShippingOptionId, "IDX_fulfillment_shipping_option_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.RequiresShipping).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ShippingOption).WithMany(p => p.Fulfillments)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fulfillment_shipping_option_id_foreign");
        });

        modelBuilder.Entity<FulfillmentAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fulfillment_address_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_fulfillment_address_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<FulfillmentItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fulfillment_item_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_fulfillment_item_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.FulfillmentId, "IDX_fulfillment_item_fulfillment_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.InventoryItemId, "IDX_fulfillment_item_inventory_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.LineItemId, "IDX_fulfillment_item_line_item_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Fulfillment).WithMany(p => p.FulfillmentItems).HasConstraintName("fulfillment_item_fulfillment_id_foreign");
        });

        modelBuilder.Entity<FulfillmentLabel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fulfillment_label_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_fulfillment_label_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.FulfillmentId, "IDX_fulfillment_label_fulfillment_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Fulfillment).WithMany(p => p.FulfillmentLabels).HasConstraintName("fulfillment_label_fulfillment_id_foreign");
        });

        modelBuilder.Entity<FulfillmentProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fulfillment_provider_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_fulfillment_provider_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<FulfillmentSet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fulfillment_set_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_fulfillment_set_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.Name, "IDX_fulfillment_set_name_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<GeoZone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("geo_zone_pkey");

            entity.HasIndex(e => e.City, "IDX_geo_zone_city").HasFilter("((deleted_at IS NULL) AND (city IS NOT NULL))");

            entity.HasIndex(e => e.CountryCode, "IDX_geo_zone_country_code").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_geo_zone_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ProvinceCode, "IDX_geo_zone_province_code").HasFilter("((deleted_at IS NULL) AND (province_code IS NOT NULL))");

            entity.HasIndex(e => e.ServiceZoneId, "IDX_geo_zone_service_zone_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Type).HasDefaultValueSql("'country'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ServiceZone).WithMany(p => p.GeoZones).HasConstraintName("geo_zone_service_zone_id_foreign");
        });

        modelBuilder.Entity<GoogleplayAppVector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("googleplay_app_vectors_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("image_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_image_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Url, "IDX_product_image_url").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Rank).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Product).WithMany(p => p.Images).HasConstraintName("image_product_id_foreign");
        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_item_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_inventory_item_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.Sku, "IDX_inventory_item_sku")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.RequiresShipping).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<InventoryLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_level_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_inventory_level_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.InventoryItemId, "IDX_inventory_level_inventory_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.InventoryItemId, e.LocationId }, "IDX_inventory_level_item_location")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.LocationId, "IDX_inventory_level_location_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.InventoryItemId, e.LocationId }, "IDX_inventory_level_location_id_inventory_item_id")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.InventoryItem).WithMany(p => p.InventoryLevels).HasConstraintName("inventory_level_inventory_item_id_foreign");
        });

        modelBuilder.Entity<Invite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invite_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_invite_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.Email, "IDX_invite_email_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Token, "IDX_invite_token").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.Accepted).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<LinkModuleMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("link_module_migrations_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.LinkDescriptor).HasDefaultValueSql("'{}'::jsonb");
        });

        modelBuilder.Entity<LocationFulfillmentProvider>(entity =>
        {
            entity.HasKey(e => new { e.StockLocationId, e.FulfillmentProviderId }).HasName("location_fulfillment_provider_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<LocationFulfillmentSet>(entity =>
        {
            entity.HasKey(e => new { e.StockLocationId, e.FulfillmentSetId }).HasName("location_fulfillment_set_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<MikroOrmMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mikro_orm_migrations_pkey");

            entity.Property(e => e.ExecutedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notification_pkey");

            entity.HasIndex(e => e.IdempotencyKey, "IDX_notification_idempotency_key_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Status).HasDefaultValueSql("'pending'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Provider).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("notification_provider_id_foreign");
        });

        modelBuilder.Entity<NotificationProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notification_provider_pkey");

            entity.Property(e => e.Channels).HasDefaultValueSql("'{}'::text[]");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_pkey");

            entity.HasIndex(e => e.BillingAddressId, "IDX_order_billing_address_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.CurrencyCode, "IDX_order_currency_code").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.CustomerId, "IDX_order_customer_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DisplayId, "IDX_order_display_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.IsDraftOrder, "IDX_order_is_draft_order").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.RegionId, "IDX_order_region_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ShippingAddressId, "IDX_order_shipping_address_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DisplayId).ValueGeneratedOnAdd();
            entity.Property(e => e.IsDraftOrder).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Version).HasDefaultValue(1);

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.OrderBillingAddresses)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("order_billing_address_id_foreign");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.OrderShippingAddresses)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("order_shipping_address_id_foreign");
        });

        modelBuilder.Entity<OrderAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_address_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<OrderCart>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.CartId }).HasName("order_cart_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<OrderChange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_change_pkey");

            entity.HasIndex(e => e.ClaimId, "IDX_order_change_claim_id").HasFilter("((claim_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.ExchangeId, "IDX_order_change_exchange_id").HasFilter("((exchange_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.ReturnId, "IDX_order_change_return_id").HasFilter("((return_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Status).HasDefaultValueSql("'pending'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderChanges).HasConstraintName("order_change_order_id_foreign");
        });

        modelBuilder.Entity<OrderChangeAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_change_action_pkey");

            entity.HasIndex(e => e.ClaimId, "IDX_order_change_action_claim_id").HasFilter("((claim_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.ExchangeId, "IDX_order_change_action_exchange_id").HasFilter("((exchange_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.ReturnId, "IDX_order_change_action_return_id").HasFilter("((return_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.Property(e => e.Applied).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Ordering).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.OrderChange).WithMany(p => p.OrderChangeActions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("order_change_action_order_change_id_foreign");
        });

        modelBuilder.Entity<OrderClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_claim_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_claim_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DisplayId, "IDX_order_claim_display_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.OrderId, "IDX_order_claim_order_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ReturnId, "IDX_order_claim_return_id").HasFilter("((return_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DisplayId).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<OrderClaimItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_claim_item_pkey");

            entity.HasIndex(e => e.ClaimId, "IDX_order_claim_item_claim_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_claim_item_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ItemId, "IDX_order_claim_item_item_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsAdditionalItem).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<OrderClaimItemImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_claim_item_image_pkey");

            entity.HasIndex(e => e.ClaimItemId, "IDX_order_claim_item_image_claim_item_id").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_claim_item_image_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<OrderCreditLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_credit_line_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_credit_line_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.OrderId, "IDX_order_credit_line_order_id").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderCreditLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_credit_line_order_id_foreign");
        });

        modelBuilder.Entity<OrderExchange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_exchange_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_exchange_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DisplayId, "IDX_order_exchange_display_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.OrderId, "IDX_order_exchange_order_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ReturnId, "IDX_order_exchange_return_id").HasFilter("((return_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.Property(e => e.AllowBackorder).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DisplayId).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<OrderExchangeItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_exchange_item_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_exchange_item_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ExchangeId, "IDX_order_exchange_item_exchange_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ItemId, "IDX_order_exchange_item_item_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<OrderFulfillment>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.FulfillmentId }).HasName("order_fulfillment_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_item_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_item_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ItemId, "IDX_order_item_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.OrderId, "IDX_order_item_order_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.OrderId, e.Version }, "IDX_order_item_order_id_version").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems).HasConstraintName("order_item_item_id_foreign");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("order_item_order_id_foreign");
        });

        modelBuilder.Entity<OrderLineItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_line_item_pkey");

            entity.HasIndex(e => e.ProductId, "IDX_order_line_item_product_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.VariantId, "IDX_order_line_item_variant_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsCustomPrice).HasDefaultValue(false);
            entity.Property(e => e.IsDiscountable).HasDefaultValue(true);
            entity.Property(e => e.IsTaxInclusive).HasDefaultValue(false);
            entity.Property(e => e.RequiresShipping).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Totals).WithMany(p => p.OrderLineItems)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("order_line_item_totals_id_foreign");
        });

        modelBuilder.Entity<OrderLineItemAdjustment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_line_item_adjustment_pkey");

            entity.HasIndex(e => e.ItemId, "IDX_order_line_item_adjustment_item_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderLineItemAdjustments).HasConstraintName("order_line_item_adjustment_item_id_foreign");
        });

        modelBuilder.Entity<OrderLineItemTaxLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_line_item_tax_line_pkey");

            entity.HasIndex(e => e.ItemId, "IDX_order_line_item_tax_line_item_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderLineItemTaxLines).HasConstraintName("order_line_item_tax_line_item_id_foreign");
        });

        modelBuilder.Entity<OrderPaymentCollection>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.PaymentCollectionId }).HasName("order_payment_collection_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<OrderPromotion>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.PromotionId }).HasName("order_promotion_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<OrderShipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_shipping_pkey");

            entity.HasIndex(e => e.ClaimId, "IDX_order_shipping_claim_id").HasFilter("((claim_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_shipping_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ExchangeId, "IDX_order_shipping_exchange_id").HasFilter("((exchange_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.ShippingMethodId, "IDX_order_shipping_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.OrderId, "IDX_order_shipping_order_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.OrderId, e.Version }, "IDX_order_shipping_order_id_version").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ReturnId, "IDX_order_shipping_return_id").HasFilter("((return_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderShippings).HasConstraintName("order_shipping_order_id_foreign");
        });

        modelBuilder.Entity<OrderShippingMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_shipping_method_pkey");

            entity.HasIndex(e => e.ShippingOptionId, "IDX_order_shipping_method_shipping_option_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsCustomAmount).HasDefaultValue(false);
            entity.Property(e => e.IsTaxInclusive).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<OrderShippingMethodAdjustment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_shipping_method_adjustment_pkey");

            entity.HasIndex(e => e.ShippingMethodId, "IDX_order_shipping_method_adjustment_shipping_method_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.OrderShippingMethodAdjustments).HasConstraintName("order_shipping_method_adjustment_shipping_method_id_foreign");
        });

        modelBuilder.Entity<OrderShippingMethodTaxLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_shipping_method_tax_line_pkey");

            entity.HasIndex(e => e.ShippingMethodId, "IDX_order_shipping_method_tax_line_shipping_method_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.OrderShippingMethodTaxLines).HasConstraintName("order_shipping_method_tax_line_shipping_method_id_foreign");
        });

        modelBuilder.Entity<OrderSummary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_summary_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_order_summary_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => new { e.OrderId, e.Version }, "IDX_order_summary_order_id_version").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Version).HasDefaultValue(1);
        });

        modelBuilder.Entity<OrderTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_transaction_pkey");

            entity.HasIndex(e => e.ClaimId, "IDX_order_transaction_claim_id").HasFilter("((claim_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.CurrencyCode, "IDX_order_transaction_currency_code").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ExchangeId, "IDX_order_transaction_exchange_id").HasFilter("((exchange_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => new { e.OrderId, e.Version }, "IDX_order_transaction_order_id_version").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ReferenceId, "IDX_order_transaction_reference_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ReturnId, "IDX_order_transaction_return_id").HasFilter("((return_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Version).HasDefaultValue(1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderTransactions).HasConstraintName("order_transaction_order_id_foreign");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_payment_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.PaymentCollectionId, "IDX_payment_payment_collection_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ProviderId, "IDX_payment_provider_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.PaymentCollection).WithMany(p => p.Payments).HasConstraintName("payment_payment_collection_id_foreign");
        });

        modelBuilder.Entity<PaymentCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_collection_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_payment_collection_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.RegionId, "IDX_payment_collection_region_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Status).HasDefaultValueSql("'not_paid'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasMany(d => d.PaymentProviders).WithMany(p => p.PaymentCollections)
                .UsingEntity<Dictionary<string, object>>(
                    "PaymentCollectionPaymentProvider",
                    r => r.HasOne<PaymentProvider>().WithMany()
                        .HasForeignKey("PaymentProviderId")
                        .HasConstraintName("payment_collection_payment_providers_payment_provider_id_foreig"),
                    l => l.HasOne<PaymentCollection>().WithMany()
                        .HasForeignKey("PaymentCollectionId")
                        .HasConstraintName("payment_collection_payment_providers_payment_coll_aa276_foreign"),
                    j =>
                    {
                        j.HasKey("PaymentCollectionId", "PaymentProviderId").HasName("payment_collection_payment_providers_pkey");
                        j.ToTable("payment_collection_payment_providers");
                        j.IndexerProperty<string>("PaymentCollectionId").HasColumnName("payment_collection_id");
                        j.IndexerProperty<string>("PaymentProviderId").HasColumnName("payment_provider_id");
                    });
        });

        modelBuilder.Entity<PaymentMethodToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_method_token_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_payment_method_token_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<PaymentProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_provider_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_payment_provider_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<PaymentSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_session_pkey");

            entity.HasIndex(e => e.PaymentCollectionId, "IDX_payment_session_payment_collection_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Data).HasDefaultValueSql("'{}'::jsonb");
            entity.Property(e => e.Status).HasDefaultValueSql("'pending'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.PaymentCollection).WithMany(p => p.PaymentSessions).HasConstraintName("payment_session_payment_collection_id_foreign");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("price_pkey");

            entity.HasIndex(e => e.CurrencyCode, "IDX_price_currency_code").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_price_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.PriceListId, "IDX_price_price_list_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.PriceSetId, "IDX_price_price_set_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.RulesCount).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.PriceList).WithMany(p => p.Prices)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("price_price_list_id_foreign");

            entity.HasOne(d => d.PriceSet).WithMany(p => p.Prices).HasConstraintName("price_price_set_id_foreign");
        });

        modelBuilder.Entity<PriceList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("price_list_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_price_list_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.RulesCount).HasDefaultValue(0);
            entity.Property(e => e.Status).HasDefaultValueSql("'draft'::text");
            entity.Property(e => e.Type).HasDefaultValueSql("'sale'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<PriceListRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("price_list_rule_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_price_list_rule_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.PriceListId, "IDX_price_list_rule_price_list_id").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.Attribute).HasDefaultValueSql("''::text");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.PriceList).WithMany(p => p.PriceListRules).HasConstraintName("price_list_rule_price_list_id_foreign");
        });

        modelBuilder.Entity<PricePreference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("price_preference_pkey");

            entity.HasIndex(e => new { e.Attribute, e.Value }, "IDX_price_preference_attribute_value")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_price_preference_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsTaxInclusive).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<PriceRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("price_rule_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_price_rule_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.PriceId, "IDX_price_rule_price_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.PriceId, e.Attribute, e.Operator }, "IDX_price_rule_price_id_attribute_operator_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.Attribute).HasDefaultValueSql("''::text");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Operator).HasDefaultValueSql("'eq'::text");
            entity.Property(e => e.Priority).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Price).WithMany(p => p.PriceRules).HasConstraintName("price_rule_price_id_foreign");
        });

        modelBuilder.Entity<PriceSet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("price_set_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_price_set_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.HasIndex(e => e.CollectionId, "IDX_product_collection_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Handle, "IDX_product_handle_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.TypeId, "IDX_product_type_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Discountable).HasDefaultValue(true);
            entity.Property(e => e.IsGiftcard).HasDefaultValue(false);
            entity.Property(e => e.Status).HasDefaultValueSql("'draft'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Collection).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_collection_id_foreign");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_type_id_foreign");

            entity.HasMany(d => d.ProductCategories).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategoryProduct",
                    r => r.HasOne<ProductCategory>().WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .HasConstraintName("product_category_product_product_category_id_foreign"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_category_product_product_id_foreign"),
                    j =>
                    {
                        j.HasKey("ProductId", "ProductCategoryId").HasName("product_category_product_pkey");
                        j.ToTable("product_category_product");
                        j.IndexerProperty<string>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<string>("ProductCategoryId").HasColumnName("product_category_id");
                    });

            entity.HasMany(d => d.ProductTags).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductTag",
                    r => r.HasOne<ProductTag1>().WithMany()
                        .HasForeignKey("ProductTagId")
                        .HasConstraintName("product_tags_product_tag_id_foreign"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_tags_product_id_foreign"),
                    j =>
                    {
                        j.HasKey("ProductId", "ProductTagId").HasName("product_tags_pkey");
                        j.ToTable("product_tags");
                        j.IndexerProperty<string>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<string>("ProductTagId").HasColumnName("product_tag_id");
                    });
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_category_pkey");

            entity.HasIndex(e => e.Handle, "IDX_category_handle_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ParentCategoryId, "IDX_product_category_parent_category_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Mpath, "IDX_product_category_path").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Description).HasDefaultValueSql("''::text");
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.IsInternal).HasDefaultValue(false);
            entity.Property(e => e.Rank).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_category_parent_category_id_foreign");
        });

        modelBuilder.Entity<ProductCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_collection_pkey");

            entity.HasIndex(e => e.Handle, "IDX_collection_handle_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<ProductOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_option_pkey");

            entity.HasIndex(e => new { e.ProductId, e.Title }, "IDX_option_product_id_title_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ProductId, "IDX_product_option_product_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductOptions).HasConstraintName("product_option_product_id_foreign");
        });

        modelBuilder.Entity<ProductOptionValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_option_value_pkey");

            entity.HasIndex(e => new { e.OptionId, e.Value }, "IDX_option_value_option_id_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.OptionId, "IDX_product_option_value_option_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Option).WithMany(p => p.ProductOptionValues)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_option_value_option_id_foreign");
        });

        modelBuilder.Entity<ProductSalesChannel>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.SalesChannelId }).HasName("product_sales_channel_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ProductTag1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_tag_pkey");

            entity.HasIndex(e => e.Value, "IDX_tag_value_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_type_pkey");

            entity.HasIndex(e => e.Value, "IDX_type_value_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_variant_pkey");

            entity.HasIndex(e => e.Barcode, "IDX_product_variant_barcode_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Ean, "IDX_product_variant_ean_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ProductId, "IDX_product_variant_product_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Sku, "IDX_product_variant_sku_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Upc, "IDX_product_variant_upc_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.AllowBackorder).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.ManageInventory).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.VariantRank).HasDefaultValue(0);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_variant_product_id_foreign");

            entity.HasMany(d => d.OptionValues).WithMany(p => p.Variants)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductVariantOption",
                    r => r.HasOne<ProductOptionValue>().WithMany()
                        .HasForeignKey("OptionValueId")
                        .HasConstraintName("product_variant_option_option_value_id_foreign"),
                    l => l.HasOne<ProductVariant>().WithMany()
                        .HasForeignKey("VariantId")
                        .HasConstraintName("product_variant_option_variant_id_foreign"),
                    j =>
                    {
                        j.HasKey("VariantId", "OptionValueId").HasName("product_variant_option_pkey");
                        j.ToTable("product_variant_option");
                        j.IndexerProperty<string>("VariantId").HasColumnName("variant_id");
                        j.IndexerProperty<string>("OptionValueId").HasColumnName("option_value_id");
                    });
        });

        modelBuilder.Entity<ProductVariantInventoryItem>(entity =>
        {
            entity.HasKey(e => new { e.VariantId, e.InventoryItemId }).HasName("product_variant_inventory_item_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.RequiredQuantity).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ProductVariantPriceSet>(entity =>
        {
            entity.HasKey(e => new { e.VariantId, e.PriceSetId }).HasName("product_variant_price_set_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promotion_pkey");

            entity.HasIndex(e => e.CampaignId, "IDX_promotion_campaign_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_promotion_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsAutomatic).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Campaign).WithMany(p => p.Promotions)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("promotion_campaign_id_foreign");

            entity.HasMany(d => d.PromotionRules).WithMany(p => p.Promotions)
                .UsingEntity<Dictionary<string, object>>(
                    "PromotionPromotionRule",
                    r => r.HasOne<PromotionRule>().WithMany()
                        .HasForeignKey("PromotionRuleId")
                        .HasConstraintName("promotion_promotion_rule_promotion_rule_id_foreign"),
                    l => l.HasOne<Promotion>().WithMany()
                        .HasForeignKey("PromotionId")
                        .HasConstraintName("promotion_promotion_rule_promotion_id_foreign"),
                    j =>
                    {
                        j.HasKey("PromotionId", "PromotionRuleId").HasName("promotion_promotion_rule_pkey");
                        j.ToTable("promotion_promotion_rule");
                        j.IndexerProperty<string>("PromotionId").HasColumnName("promotion_id");
                        j.IndexerProperty<string>("PromotionRuleId").HasColumnName("promotion_rule_id");
                    });
        });

        modelBuilder.Entity<PromotionApplicationMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promotion_application_method_pkey");

            entity.HasIndex(e => e.CurrencyCode, "IDX_promotion_application_method_currency_code").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_promotion_application_method_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.PromotionId, "IDX_promotion_application_method_promotion_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Promotion).WithOne(p => p.PromotionApplicationMethod).HasConstraintName("promotion_application_method_promotion_id_foreign");

            entity.HasMany(d => d.PromotionRules).WithMany(p => p.ApplicationMethods)
                .UsingEntity<Dictionary<string, object>>(
                    "ApplicationMethodBuyRule",
                    r => r.HasOne<PromotionRule>().WithMany()
                        .HasForeignKey("PromotionRuleId")
                        .HasConstraintName("application_method_buy_rules_promotion_rule_id_foreign"),
                    l => l.HasOne<PromotionApplicationMethod>().WithMany()
                        .HasForeignKey("ApplicationMethodId")
                        .HasConstraintName("application_method_buy_rules_application_method_id_foreign"),
                    j =>
                    {
                        j.HasKey("ApplicationMethodId", "PromotionRuleId").HasName("application_method_buy_rules_pkey");
                        j.ToTable("application_method_buy_rules");
                        j.IndexerProperty<string>("ApplicationMethodId").HasColumnName("application_method_id");
                        j.IndexerProperty<string>("PromotionRuleId").HasColumnName("promotion_rule_id");
                    });

            entity.HasMany(d => d.PromotionRulesNavigation).WithMany(p => p.ApplicationMethodsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "ApplicationMethodTargetRule",
                    r => r.HasOne<PromotionRule>().WithMany()
                        .HasForeignKey("PromotionRuleId")
                        .HasConstraintName("application_method_target_rules_promotion_rule_id_foreign"),
                    l => l.HasOne<PromotionApplicationMethod>().WithMany()
                        .HasForeignKey("ApplicationMethodId")
                        .HasConstraintName("application_method_target_rules_application_method_id_foreign"),
                    j =>
                    {
                        j.HasKey("ApplicationMethodId", "PromotionRuleId").HasName("application_method_target_rules_pkey");
                        j.ToTable("application_method_target_rules");
                        j.IndexerProperty<string>("ApplicationMethodId").HasColumnName("application_method_id");
                        j.IndexerProperty<string>("PromotionRuleId").HasColumnName("promotion_rule_id");
                    });
        });

        modelBuilder.Entity<PromotionCampaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promotion_campaign_pkey");

            entity.HasIndex(e => e.CampaignIdentifier, "IDX_promotion_campaign_campaign_identifier_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_promotion_campaign_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<PromotionCampaignBudget>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promotion_campaign_budget_pkey");

            entity.HasIndex(e => e.CampaignId, "IDX_promotion_campaign_budget_campaign_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_promotion_campaign_budget_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Campaign).WithOne(p => p.PromotionCampaignBudget).HasConstraintName("promotion_campaign_budget_campaign_id_foreign");
        });

        modelBuilder.Entity<PromotionRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promotion_rule_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_promotion_rule_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<PromotionRuleValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promotion_rule_value_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_promotion_rule_value_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.PromotionRuleId, "IDX_promotion_rule_value_promotion_rule_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.PromotionRule).WithMany(p => p.PromotionRuleValues).HasConstraintName("promotion_rule_value_promotion_rule_id_foreign");
        });

        modelBuilder.Entity<ProviderIdentity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("provider_identity_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_provider_identity_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.AuthIdentity).WithMany(p => p.ProviderIdentities).HasConstraintName("provider_identity_auth_identity_id_foreign");
        });

        modelBuilder.Entity<PublishableApiKeySalesChannel>(entity =>
        {
            entity.HasKey(e => new { e.PublishableKeyId, e.SalesChannelId }).HasName("publishable_api_key_sales_channel_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Refund>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refund_pkey");

            entity.HasIndex(e => e.PaymentId, "IDX_refund_payment_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.RefundReasonId, "IDX_refund_refund_reason_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Payment).WithMany(p => p.Refunds).HasConstraintName("refund_payment_id_foreign");
        });

        modelBuilder.Entity<RefundReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refund_reason_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_refund_reason_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("region_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_region_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.AutomaticTaxes).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<RegionCountry>(entity =>
        {
            entity.HasKey(e => e.Iso2).HasName("region_country_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Region).WithMany(p => p.RegionCountries)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("region_country_region_id_foreign");
        });

        modelBuilder.Entity<RegionPaymentProvider>(entity =>
        {
            entity.HasKey(e => new { e.RegionId, e.PaymentProviderId }).HasName("region_payment_provider_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ReservationItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservation_item_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_reservation_item_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.InventoryItemId, "IDX_reservation_item_inventory_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.LineItemId, "IDX_reservation_item_line_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.LocationId, "IDX_reservation_item_location_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.AllowBackorder).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.InventoryItem).WithMany(p => p.ReservationItems).HasConstraintName("reservation_item_inventory_item_id_foreign");
        });

        modelBuilder.Entity<Return>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("return_pkey");

            entity.HasIndex(e => e.ClaimId, "IDX_return_claim_id").HasFilter("((claim_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.DisplayId, "IDX_return_display_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ExchangeId, "IDX_return_exchange_id").HasFilter("((exchange_id IS NOT NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.OrderId, "IDX_return_order_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.DisplayId).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<ReturnFulfillment>(entity =>
        {
            entity.HasKey(e => new { e.ReturnId, e.FulfillmentId }).HasName("return_fulfillment_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ReturnItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("return_item_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_return_item_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ItemId, "IDX_return_item_item_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ReasonId, "IDX_return_item_reason_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ReturnId, "IDX_return_item_return_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<ReturnReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("return_reason_pkey");

            entity.HasIndex(e => e.Value, "IDX_return_reason_value")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ParentReturnReason).WithMany(p => p.InverseParentReturnReason).HasConstraintName("return_reason_parent_return_reason_id_foreign");
        });

        modelBuilder.Entity<SalesChannel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sales_channel_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDisabled).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<SalesChannelStockLocation>(entity =>
        {
            entity.HasKey(e => new { e.SalesChannelId, e.StockLocationId }).HasName("sales_channel_stock_location_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ServiceZone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_zone_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_service_zone_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.FulfillmentSetId, "IDX_service_zone_fulfillment_set_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Name, "IDX_service_zone_name_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.FulfillmentSet).WithMany(p => p.ServiceZones).HasConstraintName("service_zone_fulfillment_set_id_foreign");
        });

        modelBuilder.Entity<ShippingOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipping_option_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_shipping_option_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ServiceZoneId, "IDX_shipping_option_service_zone_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.ShippingProfileId, "IDX_shipping_option_shipping_profile_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.PriceType).HasDefaultValueSql("'flat'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ServiceZone).WithMany(p => p.ShippingOptions).HasConstraintName("shipping_option_service_zone_id_foreign");

            entity.HasOne(d => d.ShippingProfile).WithMany(p => p.ShippingOptions)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shipping_option_shipping_profile_id_foreign");
        });

        modelBuilder.Entity<ShippingOptionPriceSet>(entity =>
        {
            entity.HasKey(e => new { e.ShippingOptionId, e.PriceSetId }).HasName("shipping_option_price_set_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ShippingOptionRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipping_option_rule_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_shipping_option_rule_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ShippingOptionId, "IDX_shipping_option_rule_shipping_option_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.ShippingOption).WithMany(p => p.ShippingOptionRules).HasConstraintName("shipping_option_rule_shipping_option_id_foreign");
        });

        modelBuilder.Entity<ShippingOptionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipping_option_type_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_shipping_option_type_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<ShippingProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipping_profile_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_shipping_profile_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.Name, "IDX_shipping_profile_name_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<StockLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stock_location_pkey");

            entity.HasIndex(e => e.AddressId, "IDX_stock_location_address_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.DeletedAt, "IDX_stock_location_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Address).WithMany(p => p.StockLocations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("stock_location_address_id_foreign");
        });

        modelBuilder.Entity<StockLocationAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stock_location_address_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_stock_location_address_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_store_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Name).HasDefaultValueSql("'Medusa Store'::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<StoreCurrency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("store_currency_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_store_currency_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.StoreId, "IDX_store_currency_store_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsDefault).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Store).WithMany(p => p.StoreCurrencies)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("store_currency_store_id_foreign");
        });

        modelBuilder.Entity<TaxProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tax_provider_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_tax_provider_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tax_rate_pkey");

            entity.HasIndex(e => e.TaxRegionId, "IDX_single_default_region")
                .IsUnique()
                .HasFilter("((is_default = true) AND (deleted_at IS NULL))");

            entity.HasIndex(e => e.DeletedAt, "IDX_tax_rate_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.TaxRegionId, "IDX_tax_rate_tax_region_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsCombinable).HasDefaultValue(false);
            entity.Property(e => e.IsDefault).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.TaxRegion).WithOne(p => p.TaxRate).HasConstraintName("FK_tax_rate_tax_region_id");
        });

        modelBuilder.Entity<TaxRateRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tax_rate_rule_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_tax_rate_rule_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ReferenceId, "IDX_tax_rate_rule_reference_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.TaxRateId, "IDX_tax_rate_rule_tax_rate_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.TaxRateId, e.ReferenceId }, "IDX_tax_rate_rule_unique_rate_reference")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.TaxRate).WithMany(p => p.TaxRateRules).HasConstraintName("FK_tax_rate_rule_tax_rate_id");
        });

        modelBuilder.Entity<TaxRegion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tax_region_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_tax_region_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.ProviderId, "IDX_tax_region_provider_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.CountryCode, "IDX_tax_region_unique_country_nullable_province")
                .IsUnique()
                .HasFilter("((province_code IS NULL) AND (deleted_at IS NULL))");

            entity.HasIndex(e => new { e.CountryCode, e.ProvinceCode }, "IDX_tax_region_unique_country_province")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tax_region_parent_id");

            entity.HasOne(d => d.Provider).WithMany(p => p.TaxRegions)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_tax_region_provider_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.HasIndex(e => e.DeletedAt, "IDX_user_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.Email, "IDX_user_email_unique")
                .IsUnique()
                .HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<WorkflowExecution>(entity =>
        {
            entity.HasKey(e => new { e.WorkflowId, e.TransactionId }).HasName("PK_workflow_execution_workflow_id_transaction_id");

            entity.HasIndex(e => e.DeletedAt, "IDX_workflow_execution_deleted_at").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Id, "IDX_workflow_execution_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.State, "IDX_workflow_execution_state").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.TransactionId, "IDX_workflow_execution_transaction_id").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.WorkflowId, "IDX_workflow_execution_workflow_id").HasFilter("(deleted_at IS NULL)");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<VariantTextEmbedding>()
            .HasOne(v => v.Variant)
            .WithOne()

            .HasForeignKey<VariantTextEmbedding>(v => v.VariantId)
            .IsRequired();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
