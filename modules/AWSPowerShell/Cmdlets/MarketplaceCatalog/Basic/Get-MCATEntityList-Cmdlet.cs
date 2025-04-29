/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.MarketplaceCatalog;
using Amazon.MarketplaceCatalog.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MCAT
{
    /// <summary>
    /// Provides the list of entities of a given type.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "MCATEntityList")]
    [OutputType("Amazon.MarketplaceCatalog.Model.EntitySummary")]
    [AWSCmdlet("Calls the AWS Marketplace Catalog Service ListEntities API operation.", Operation = new[] {"ListEntities"}, SelectReturnType = typeof(Amazon.MarketplaceCatalog.Model.ListEntitiesResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceCatalog.Model.EntitySummary or Amazon.MarketplaceCatalog.Model.ListEntitiesResponse",
        "This cmdlet returns a collection of Amazon.MarketplaceCatalog.Model.EntitySummary objects.",
        "The service call response (type Amazon.MarketplaceCatalog.Model.ListEntitiesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMCATEntityListCmdlet : AmazonMarketplaceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Date after which the AMI product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Date after which the container product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Date after which the data product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>AvailabilityEndDate</c> of an offer after a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>LastModifiedDate</c> of an offer after a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ReleaseDate</c> of offers after a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on <c>AvailabilityEndDate</c> of a ResaleAuthorization after a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on <c>CreatedDate</c> of a ResaleAuthorization after a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>LastModifiedDate</c> of a ResaleAuthorization after a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue
        /// <summary>
        /// <para>
        /// <para>Date after which the SaaS product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Date before which the AMI product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Date before which the container product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Date before which the data product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>AvailabilityEndDate</c> of an offer before a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>LastModifiedDate</c> of an offer before a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ReleaseDate</c> of offers before a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on <c>AvailabilityEndDate</c> of a ResaleAuthorization before a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on <c>CreatedDate</c> of a ResaleAuthorization before a date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>LastModifiedDate</c> of a ResaleAuthorization before a
        /// date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue
        /// <summary>
        /// <para>
        /// <para>Date before which the SaaS product was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog related to the request. Fixed value: <c>AWSMarketplace</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter EntityType
        /// <summary>
        /// <para>
        /// <para>The type of entities to retrieve. Valid values are: <c>AmiProduct</c>, <c>ContainerProduct</c>,
        /// <c>DataProduct</c>, <c>SaaSProduct</c>, <c>ProcurementPolicy</c>, <c>Experience</c>,
        /// <c>Audience</c>, <c>BrandingSettings</c>, <c>Offer</c>, <c>Seller</c>, <c>ResaleAuthorization</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EntityType { get; set; }
        #endregion
        
        #region Parameter FilterList
        /// <summary>
        /// <para>
        /// <para>An array of filter objects. Each filter object contains two attributes, <c>filterName</c>
        /// and <c>filterValues</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MarketplaceCatalog.Model.Filter[] FilterList { get; set; }
        #endregion
        
        #region Parameter OwnershipType
        /// <summary>
        /// <para>
        /// <para>Filters the returned set of entities based on their owner. The default is <c>SELF</c>.
        /// To list entities shared with you through AWS Resource Access Manager (AWS RAM), set
        /// to <c>SHARED</c>. Entities shared through the AWS Marketplace Catalog API <c>PutResourcePolicy</c>
        /// operation can't be discovered through the <c>SHARED</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.OwnershipType")]
        public Amazon.MarketplaceCatalog.OwnershipType OwnershipType { get; set; }
        #endregion
        
        #region Parameter AmiProductSort_SortBy
        /// <summary>
        /// <para>
        /// <para>Field to sort the AMI products by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_AmiProductSort_SortBy")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.AmiProductSortBy")]
        public Amazon.MarketplaceCatalog.AmiProductSortBy AmiProductSort_SortBy { get; set; }
        #endregion
        
        #region Parameter ContainerProductSort_SortBy
        /// <summary>
        /// <para>
        /// <para>Field to sort the container products by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_ContainerProductSort_SortBy")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.ContainerProductSortBy")]
        public Amazon.MarketplaceCatalog.ContainerProductSortBy ContainerProductSort_SortBy { get; set; }
        #endregion
        
        #region Parameter DataProductSort_SortBy
        /// <summary>
        /// <para>
        /// <para>Field to sort the data products by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_DataProductSort_SortBy")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.DataProductSortBy")]
        public Amazon.MarketplaceCatalog.DataProductSortBy DataProductSort_SortBy { get; set; }
        #endregion
        
        #region Parameter OfferSort_SortBy
        /// <summary>
        /// <para>
        /// <para>Allows to sort offers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_OfferSort_SortBy")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.OfferSortBy")]
        public Amazon.MarketplaceCatalog.OfferSortBy OfferSort_SortBy { get; set; }
        #endregion
        
        #region Parameter ResaleAuthorizationSort_SortBy
        /// <summary>
        /// <para>
        /// <para>Allows to sort ResaleAuthorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_ResaleAuthorizationSort_SortBy")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.ResaleAuthorizationSortBy")]
        public Amazon.MarketplaceCatalog.ResaleAuthorizationSortBy ResaleAuthorizationSort_SortBy { get; set; }
        #endregion
        
        #region Parameter SaaSProductSort_SortBy
        /// <summary>
        /// <para>
        /// <para>Field to sort the SaaS products by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_SaaSProductSort_SortBy")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SaaSProductSortBy")]
        public Amazon.MarketplaceCatalog.SaaSProductSortBy SaaSProductSort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>For <c>ListEntities</c>, supported attributes include <c>LastModifiedDate</c> (default)
        /// and <c>EntityId</c>. In addition to <c>LastModifiedDate</c> and <c>EntityId</c>, each
        /// <c>EntityType</c> might support additional fields.</para><para>For <c>ListChangeSets</c>, supported attributes include <c>StartTime</c> and <c>EndTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter AmiProductSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order. Can be <c>ASCENDING</c> or <c>DESCENDING</c>. The default value
        /// is <c>DESCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_AmiProductSort_SortOrder")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SortOrder")]
        public Amazon.MarketplaceCatalog.SortOrder AmiProductSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter ContainerProductSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order. Can be <c>ASCENDING</c> or <c>DESCENDING</c>. The default value
        /// is <c>DESCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_ContainerProductSort_SortOrder")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SortOrder")]
        public Amazon.MarketplaceCatalog.SortOrder ContainerProductSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter DataProductSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order. Can be <c>ASCENDING</c> or <c>DESCENDING</c>. The default value
        /// is <c>DESCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_DataProductSort_SortOrder")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SortOrder")]
        public Amazon.MarketplaceCatalog.SortOrder DataProductSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter OfferSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>Allows to sort offers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_OfferSort_SortOrder")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SortOrder")]
        public Amazon.MarketplaceCatalog.SortOrder OfferSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter ResaleAuthorizationSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>Allows to sort ResaleAuthorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_ResaleAuthorizationSort_SortOrder")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SortOrder")]
        public Amazon.MarketplaceCatalog.SortOrder ResaleAuthorizationSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter SaaSProductSort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order. Can be <c>ASCENDING</c> or <c>DESCENDING</c>. The default value
        /// is <c>DESCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeSort_SaaSProductSort_SortOrder")]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SortOrder")]
        public Amazon.MarketplaceCatalog.SortOrder SaaSProductSort_SortOrder { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order. Can be <c>ASCENDING</c> or <c>DESCENDING</c>. The default value
        /// is <c>DESCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MarketplaceCatalog.SortOrder")]
        public Amazon.MarketplaceCatalog.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_AmiProductFilters_EntityId_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique entity id values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_AmiProductFilters_EntityId_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique product title values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_AmiProductFilters_Visibility_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique visibility values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_AmiProductFilters_Visibility_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ContainerProductFilters_EntityId_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique entity id values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_ContainerProductFilters_EntityId_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique product title values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ContainerProductFilters_Visibility_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique visibility values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_ContainerProductFilters_Visibility_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_DataProductFilters_EntityId_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique entity id values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_DataProductFilters_EntityId_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_DataProductFilters_ProductTitle_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique product title values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_DataProductFilters_ProductTitle_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_DataProductFilters_Visibility_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique visibility values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_DataProductFilters_Visibility_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_EntityId_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on entity id of an offer with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_OfferFilters_EntityId_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_Name_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>Name</c> of an offer with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_OfferFilters_Name_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_ProductId_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ProductId</c> of an offer with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_OfferFilters_ProductId_ValueList { get; set; }
        #endregion
        
        #region Parameter ResaleAuthorizationId_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ResaleAuthorizationId</c> of an offer with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_OfferFilters_ResaleAuthorizationId_ValueList")]
        public System.String[] ResaleAuthorizationId_ValueList { get; set; }
        #endregion
        
        #region Parameter State_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>State</c> of an offer with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_OfferFilters_State_ValueList")]
        public System.String[] State_ValueList { get; set; }
        #endregion
        
        #region Parameter Targeting_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>Targeting</c> of an offer with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_OfferFilters_Targeting_ValueList")]
        public System.String[] Targeting_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on <c>AvailabilityEndDate</c> of a ResaleAuthorization with date
        /// value as input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList { get; set; }
        #endregion
        
        #region Parameter CreatedDate_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on <c>CreatedDate</c> of a ResaleAuthorization with date value as
        /// input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_ValueList")]
        public System.String[] CreatedDate_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on <c>EntityId</c> of a ResaleAuthorization with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList { get; set; }
        #endregion
        
        #region Parameter ManufacturerAccountId_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ManufacturerAccountId</c> of a ResaleAuthorization with
        /// list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_ValueList")]
        public System.String[] ManufacturerAccountId_ValueList { get; set; }
        #endregion
        
        #region Parameter ManufacturerLegalName_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ManufacturerLegalName</c> of a ResaleAuthorization with
        /// list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_ValueList")]
        public System.String[] ManufacturerLegalName_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>Name</c> of a ResaleAuthorization with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList { get; set; }
        #endregion
        
        #region Parameter OfferExtendedStatus_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>OfferExtendedStatus</c> of a ResaleAuthorization with list
        /// input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus_ValueList")]
        public System.String[] OfferExtendedStatus_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ProductId</c> of a ResaleAuthorization with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList { get; set; }
        #endregion
        
        #region Parameter ProductName_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ProductName</c> of a ResaleAuthorization with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ProductName_ValueList")]
        public System.String[] ProductName_ValueList { get; set; }
        #endregion
        
        #region Parameter ResellerAccountID_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ResellerAccountID</c> of a ResaleAuthorization with list
        /// input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_ValueList")]
        public System.String[] ResellerAccountID_ValueList { get; set; }
        #endregion
        
        #region Parameter ResellerLegalName_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the ResellerLegalNameProductName of a ResaleAuthorization with
        /// list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_ValueList")]
        public System.String[] ResellerLegalName_ValueList { get; set; }
        #endregion
        
        #region Parameter Status_ValueList
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>Status</c> of a ResaleAuthorization with list input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_Status_ValueList")]
        public System.String[] Status_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_SaaSProductFilters_EntityId_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique entity id values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_SaaSProductFilters_EntityId_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique product title values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_SaaSProductFilters_Visibility_ValueList
        /// <summary>
        /// <para>
        /// <para>A string array of unique visibility values to be filtered on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EntityTypeFilters_SaaSProductFilters_Visibility_ValueList { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue
        /// <summary>
        /// <para>
        /// <para>A string that will be the <c>wildCard</c> input for product tile filter. It matches
        /// the provided value as a substring in the actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue
        /// <summary>
        /// <para>
        /// <para>A string that will be the <c>wildCard</c> input for product tile filter. It matches
        /// the provided value as a substring in the actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_DataProductFilters_ProductTitle_WildCardValue
        /// <summary>
        /// <para>
        /// <para>A string that will be the <c>wildCard</c> input for product tile filter. It matches
        /// the provided value as a substring in the actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_DataProductFilters_ProductTitle_WildCardValue { get; set; }
        #endregion
        
        #region Parameter BuyerAccounts_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>BuyerAccounts</c> of an offer with wild card input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_OfferFilters_BuyerAccounts_WildCardValue")]
        public System.String BuyerAccounts_WildCardValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_OfferFilters_Name_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>Name</c> of an offer with wild card input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_OfferFilters_Name_WildCardValue { get; set; }
        #endregion
        
        #region Parameter ManufacturerAccountId_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ManufacturerAccountId</c> of a ResaleAuthorization with
        /// wild card input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_WildCardValue")]
        public System.String ManufacturerAccountId_WildCardValue { get; set; }
        #endregion
        
        #region Parameter ManufacturerLegalName_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ManufacturerLegalName</c> of a ResaleAuthorization with
        /// wild card input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_WildCardValue")]
        public System.String ManufacturerLegalName_WildCardValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>Name</c> of a ResaleAuthorization with wild card input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue { get; set; }
        #endregion
        
        #region Parameter ProductId_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ProductId</c> of a ResaleAuthorization with wild card input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ProductId_WildCardValue")]
        public System.String ProductId_WildCardValue { get; set; }
        #endregion
        
        #region Parameter ProductName_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ProductName</c> of a ResaleAuthorization with wild card
        /// input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ProductName_WildCardValue")]
        public System.String ProductName_WildCardValue { get; set; }
        #endregion
        
        #region Parameter ResellerAccountID_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the <c>ResellerAccountID</c> of a ResaleAuthorization with wild
        /// card input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_WildCardValue")]
        public System.String ResellerAccountID_WildCardValue { get; set; }
        #endregion
        
        #region Parameter ResellerLegalName_WildCardValue
        /// <summary>
        /// <para>
        /// <para>Allows filtering on the ResellerLegalName of a ResaleAuthorization with wild card
        /// input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EntityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_WildCardValue")]
        public System.String ResellerLegalName_WildCardValue { get; set; }
        #endregion
        
        #region Parameter EntityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue
        /// <summary>
        /// <para>
        /// <para>A string that will be the <c>wildCard</c> input for product tile filter. It matches
        /// the provided value as a substring in the actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the upper limit of the elements on a single page. If a value isn't provided,
        /// the default value is 20.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The value of the next token, if it exists. Null if there are no more results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EntitySummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceCatalog.Model.ListEntitiesResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceCatalog.Model.ListEntitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EntitySummaryList";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceCatalog.Model.ListEntitiesResponse, GetMCATEntityListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityType = this.EntityType;
            #if MODULAR
            if (this.EntityType == null && ParameterWasBound(nameof(this.EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EntityTypeFilters_AmiProductFilters_EntityId_ValueList != null)
            {
                context.EntityTypeFilters_AmiProductFilters_EntityId_ValueList = new List<System.String>(this.EntityTypeFilters_AmiProductFilters_EntityId_ValueList);
            }
            context.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue = this.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue;
            context.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue = this.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue;
            if (this.EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList != null)
            {
                context.EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList = new List<System.String>(this.EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList);
            }
            context.EntityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue = this.EntityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue;
            if (this.EntityTypeFilters_AmiProductFilters_Visibility_ValueList != null)
            {
                context.EntityTypeFilters_AmiProductFilters_Visibility_ValueList = new List<System.String>(this.EntityTypeFilters_AmiProductFilters_Visibility_ValueList);
            }
            if (this.EntityTypeFilters_ContainerProductFilters_EntityId_ValueList != null)
            {
                context.EntityTypeFilters_ContainerProductFilters_EntityId_ValueList = new List<System.String>(this.EntityTypeFilters_ContainerProductFilters_EntityId_ValueList);
            }
            context.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue = this.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue;
            context.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue = this.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue;
            if (this.EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList != null)
            {
                context.EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList = new List<System.String>(this.EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList);
            }
            context.EntityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue = this.EntityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue;
            if (this.EntityTypeFilters_ContainerProductFilters_Visibility_ValueList != null)
            {
                context.EntityTypeFilters_ContainerProductFilters_Visibility_ValueList = new List<System.String>(this.EntityTypeFilters_ContainerProductFilters_Visibility_ValueList);
            }
            if (this.EntityTypeFilters_DataProductFilters_EntityId_ValueList != null)
            {
                context.EntityTypeFilters_DataProductFilters_EntityId_ValueList = new List<System.String>(this.EntityTypeFilters_DataProductFilters_EntityId_ValueList);
            }
            context.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue = this.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue;
            context.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue = this.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue;
            if (this.EntityTypeFilters_DataProductFilters_ProductTitle_ValueList != null)
            {
                context.EntityTypeFilters_DataProductFilters_ProductTitle_ValueList = new List<System.String>(this.EntityTypeFilters_DataProductFilters_ProductTitle_ValueList);
            }
            context.EntityTypeFilters_DataProductFilters_ProductTitle_WildCardValue = this.EntityTypeFilters_DataProductFilters_ProductTitle_WildCardValue;
            if (this.EntityTypeFilters_DataProductFilters_Visibility_ValueList != null)
            {
                context.EntityTypeFilters_DataProductFilters_Visibility_ValueList = new List<System.String>(this.EntityTypeFilters_DataProductFilters_Visibility_ValueList);
            }
            context.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue = this.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue;
            context.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue = this.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue;
            context.BuyerAccounts_WildCardValue = this.BuyerAccounts_WildCardValue;
            if (this.EntityTypeFilters_OfferFilters_EntityId_ValueList != null)
            {
                context.EntityTypeFilters_OfferFilters_EntityId_ValueList = new List<System.String>(this.EntityTypeFilters_OfferFilters_EntityId_ValueList);
            }
            context.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue = this.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue;
            context.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue = this.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue;
            if (this.EntityTypeFilters_OfferFilters_Name_ValueList != null)
            {
                context.EntityTypeFilters_OfferFilters_Name_ValueList = new List<System.String>(this.EntityTypeFilters_OfferFilters_Name_ValueList);
            }
            context.EntityTypeFilters_OfferFilters_Name_WildCardValue = this.EntityTypeFilters_OfferFilters_Name_WildCardValue;
            if (this.EntityTypeFilters_OfferFilters_ProductId_ValueList != null)
            {
                context.EntityTypeFilters_OfferFilters_ProductId_ValueList = new List<System.String>(this.EntityTypeFilters_OfferFilters_ProductId_ValueList);
            }
            context.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue = this.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue;
            context.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue = this.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue;
            if (this.ResaleAuthorizationId_ValueList != null)
            {
                context.ResaleAuthorizationId_ValueList = new List<System.String>(this.ResaleAuthorizationId_ValueList);
            }
            if (this.State_ValueList != null)
            {
                context.State_ValueList = new List<System.String>(this.State_ValueList);
            }
            if (this.Targeting_ValueList != null)
            {
                context.Targeting_ValueList = new List<System.String>(this.Targeting_ValueList);
            }
            context.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue = this.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue;
            context.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue = this.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue;
            if (this.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList != null)
            {
                context.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList = new List<System.String>(this.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList);
            }
            context.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue = this.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue;
            context.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue = this.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue;
            if (this.CreatedDate_ValueList != null)
            {
                context.CreatedDate_ValueList = new List<System.String>(this.CreatedDate_ValueList);
            }
            if (this.EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList != null)
            {
                context.EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList = new List<System.String>(this.EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList);
            }
            context.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue = this.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue;
            context.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue = this.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue;
            if (this.ManufacturerAccountId_ValueList != null)
            {
                context.ManufacturerAccountId_ValueList = new List<System.String>(this.ManufacturerAccountId_ValueList);
            }
            context.ManufacturerAccountId_WildCardValue = this.ManufacturerAccountId_WildCardValue;
            if (this.ManufacturerLegalName_ValueList != null)
            {
                context.ManufacturerLegalName_ValueList = new List<System.String>(this.ManufacturerLegalName_ValueList);
            }
            context.ManufacturerLegalName_WildCardValue = this.ManufacturerLegalName_WildCardValue;
            if (this.EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList != null)
            {
                context.EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList = new List<System.String>(this.EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList);
            }
            context.EntityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue = this.EntityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue;
            if (this.OfferExtendedStatus_ValueList != null)
            {
                context.OfferExtendedStatus_ValueList = new List<System.String>(this.OfferExtendedStatus_ValueList);
            }
            if (this.EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList != null)
            {
                context.EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList = new List<System.String>(this.EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList);
            }
            context.ProductId_WildCardValue = this.ProductId_WildCardValue;
            if (this.ProductName_ValueList != null)
            {
                context.ProductName_ValueList = new List<System.String>(this.ProductName_ValueList);
            }
            context.ProductName_WildCardValue = this.ProductName_WildCardValue;
            if (this.ResellerAccountID_ValueList != null)
            {
                context.ResellerAccountID_ValueList = new List<System.String>(this.ResellerAccountID_ValueList);
            }
            context.ResellerAccountID_WildCardValue = this.ResellerAccountID_WildCardValue;
            if (this.ResellerLegalName_ValueList != null)
            {
                context.ResellerLegalName_ValueList = new List<System.String>(this.ResellerLegalName_ValueList);
            }
            context.ResellerLegalName_WildCardValue = this.ResellerLegalName_WildCardValue;
            if (this.Status_ValueList != null)
            {
                context.Status_ValueList = new List<System.String>(this.Status_ValueList);
            }
            if (this.EntityTypeFilters_SaaSProductFilters_EntityId_ValueList != null)
            {
                context.EntityTypeFilters_SaaSProductFilters_EntityId_ValueList = new List<System.String>(this.EntityTypeFilters_SaaSProductFilters_EntityId_ValueList);
            }
            context.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue = this.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue;
            context.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue = this.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue;
            if (this.EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList != null)
            {
                context.EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList = new List<System.String>(this.EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList);
            }
            context.EntityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue = this.EntityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue;
            if (this.EntityTypeFilters_SaaSProductFilters_Visibility_ValueList != null)
            {
                context.EntityTypeFilters_SaaSProductFilters_Visibility_ValueList = new List<System.String>(this.EntityTypeFilters_SaaSProductFilters_Visibility_ValueList);
            }
            context.AmiProductSort_SortBy = this.AmiProductSort_SortBy;
            context.AmiProductSort_SortOrder = this.AmiProductSort_SortOrder;
            context.ContainerProductSort_SortBy = this.ContainerProductSort_SortBy;
            context.ContainerProductSort_SortOrder = this.ContainerProductSort_SortOrder;
            context.DataProductSort_SortBy = this.DataProductSort_SortBy;
            context.DataProductSort_SortOrder = this.DataProductSort_SortOrder;
            context.OfferSort_SortBy = this.OfferSort_SortBy;
            context.OfferSort_SortOrder = this.OfferSort_SortOrder;
            context.ResaleAuthorizationSort_SortBy = this.ResaleAuthorizationSort_SortBy;
            context.ResaleAuthorizationSort_SortOrder = this.ResaleAuthorizationSort_SortOrder;
            context.SaaSProductSort_SortBy = this.SaaSProductSort_SortBy;
            context.SaaSProductSort_SortOrder = this.SaaSProductSort_SortOrder;
            if (this.FilterList != null)
            {
                context.FilterList = new List<Amazon.MarketplaceCatalog.Model.Filter>(this.FilterList);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OwnershipType = this.OwnershipType;
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.MarketplaceCatalog.Model.ListEntitiesRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.EntityType != null)
            {
                request.EntityType = cmdletContext.EntityType;
            }
            
             // populate EntityTypeFilters
            var requestEntityTypeFiltersIsNull = true;
            request.EntityTypeFilters = new Amazon.MarketplaceCatalog.Model.EntityTypeFilters();
            Amazon.MarketplaceCatalog.Model.AmiProductFilters requestEntityTypeFilters_entityTypeFilters_AmiProductFilters = null;
            
             // populate AmiProductFilters
            var requestEntityTypeFilters_entityTypeFilters_AmiProductFiltersIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_AmiProductFilters = new Amazon.MarketplaceCatalog.Model.AmiProductFilters();
            Amazon.MarketplaceCatalog.Model.AmiProductEntityIdFilter requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId = null;
            
             // populate EntityId
            var requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId = new Amazon.MarketplaceCatalog.Model.AmiProductEntityIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId_entityTypeFilters_AmiProductFilters_EntityId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_AmiProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId_entityTypeFilters_AmiProductFilters_EntityId_ValueList = cmdletContext.EntityTypeFilters_AmiProductFilters_EntityId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId_entityTypeFilters_AmiProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId.ValueList = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId_entityTypeFilters_AmiProductFilters_EntityId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters.EntityId = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_EntityId;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.AmiProductLastModifiedDateFilter requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate = null;
            
             // populate LastModifiedDate
            var requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate = new Amazon.MarketplaceCatalog.Model.AmiProductLastModifiedDateFilter();
            Amazon.MarketplaceCatalog.Model.AmiProductLastModifiedDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange = new Amazon.MarketplaceCatalog.Model.AmiProductLastModifiedDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate.DateRange = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate_entityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters.LastModifiedDate = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_LastModifiedDate;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.AmiProductVisibilityFilter requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility = null;
            
             // populate Visibility
            var requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_VisibilityIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility = new Amazon.MarketplaceCatalog.Model.AmiProductVisibilityFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility_entityTypeFilters_AmiProductFilters_Visibility_ValueList = null;
            if (cmdletContext.EntityTypeFilters_AmiProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility_entityTypeFilters_AmiProductFilters_Visibility_ValueList = cmdletContext.EntityTypeFilters_AmiProductFilters_Visibility_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility_entityTypeFilters_AmiProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility.ValueList = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility_entityTypeFilters_AmiProductFilters_Visibility_ValueList;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_VisibilityIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_VisibilityIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters.Visibility = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_Visibility;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.AmiProductTitleFilter requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle = null;
            
             // populate ProductTitle
            var requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitleIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle = new Amazon.MarketplaceCatalog.Model.AmiProductTitleFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_ValueList = null;
            if (cmdletContext.EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_ValueList = cmdletContext.EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle.ValueList = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_ValueList;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitleIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue = null;
            if (cmdletContext.EntityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue = cmdletContext.EntityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle.WildCardValue = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle_entityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitleIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitleIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle != null)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters.ProductTitle = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters_entityTypeFilters_AmiProductFilters_ProductTitle;
                requestEntityTypeFilters_entityTypeFilters_AmiProductFiltersIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_AmiProductFilters should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFiltersIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_AmiProductFilters = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_AmiProductFilters != null)
            {
                request.EntityTypeFilters.AmiProductFilters = requestEntityTypeFilters_entityTypeFilters_AmiProductFilters;
                requestEntityTypeFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ContainerProductFilters requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters = null;
            
             // populate ContainerProductFilters
            var requestEntityTypeFilters_entityTypeFilters_ContainerProductFiltersIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters = new Amazon.MarketplaceCatalog.Model.ContainerProductFilters();
            Amazon.MarketplaceCatalog.Model.ContainerProductEntityIdFilter requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId = null;
            
             // populate EntityId
            var requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId = new Amazon.MarketplaceCatalog.Model.ContainerProductEntityIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId_entityTypeFilters_ContainerProductFilters_EntityId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_ContainerProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId_entityTypeFilters_ContainerProductFilters_EntityId_ValueList = cmdletContext.EntityTypeFilters_ContainerProductFilters_EntityId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId_entityTypeFilters_ContainerProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId.ValueList = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId_entityTypeFilters_ContainerProductFilters_EntityId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters.EntityId = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_EntityId;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ContainerProductLastModifiedDateFilter requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate = null;
            
             // populate LastModifiedDate
            var requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate = new Amazon.MarketplaceCatalog.Model.ContainerProductLastModifiedDateFilter();
            Amazon.MarketplaceCatalog.Model.ContainerProductLastModifiedDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange = new Amazon.MarketplaceCatalog.Model.ContainerProductLastModifiedDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate.DateRange = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate_entityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters.LastModifiedDate = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_LastModifiedDate;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ContainerProductVisibilityFilter requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility = null;
            
             // populate Visibility
            var requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_VisibilityIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility = new Amazon.MarketplaceCatalog.Model.ContainerProductVisibilityFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility_entityTypeFilters_ContainerProductFilters_Visibility_ValueList = null;
            if (cmdletContext.EntityTypeFilters_ContainerProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility_entityTypeFilters_ContainerProductFilters_Visibility_ValueList = cmdletContext.EntityTypeFilters_ContainerProductFilters_Visibility_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility_entityTypeFilters_ContainerProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility.ValueList = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility_entityTypeFilters_ContainerProductFilters_Visibility_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_VisibilityIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_VisibilityIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters.Visibility = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_Visibility;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ContainerProductTitleFilter requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle = null;
            
             // populate ProductTitle
            var requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitleIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle = new Amazon.MarketplaceCatalog.Model.ContainerProductTitleFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_ValueList = null;
            if (cmdletContext.EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_ValueList = cmdletContext.EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle.ValueList = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitleIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue = null;
            if (cmdletContext.EntityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue = cmdletContext.EntityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle_entityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitleIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitleIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters.ProductTitle = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters_entityTypeFilters_ContainerProductFilters_ProductTitle;
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFiltersIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFiltersIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters != null)
            {
                request.EntityTypeFilters.ContainerProductFilters = requestEntityTypeFilters_entityTypeFilters_ContainerProductFilters;
                requestEntityTypeFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.DataProductFilters requestEntityTypeFilters_entityTypeFilters_DataProductFilters = null;
            
             // populate DataProductFilters
            var requestEntityTypeFilters_entityTypeFilters_DataProductFiltersIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_DataProductFilters = new Amazon.MarketplaceCatalog.Model.DataProductFilters();
            Amazon.MarketplaceCatalog.Model.DataProductEntityIdFilter requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId = null;
            
             // populate EntityId
            var requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId = new Amazon.MarketplaceCatalog.Model.DataProductEntityIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId_entityTypeFilters_DataProductFilters_EntityId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_DataProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId_entityTypeFilters_DataProductFilters_EntityId_ValueList = cmdletContext.EntityTypeFilters_DataProductFilters_EntityId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId_entityTypeFilters_DataProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId.ValueList = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId_entityTypeFilters_DataProductFilters_EntityId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters.EntityId = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_EntityId;
                requestEntityTypeFilters_entityTypeFilters_DataProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.DataProductLastModifiedDateFilter requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate = null;
            
             // populate LastModifiedDate
            var requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate = new Amazon.MarketplaceCatalog.Model.DataProductLastModifiedDateFilter();
            Amazon.MarketplaceCatalog.Model.DataProductLastModifiedDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange = new Amazon.MarketplaceCatalog.Model.DataProductLastModifiedDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate.DateRange = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate_entityTypeFilters_DataProductFilters_LastModifiedDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters.LastModifiedDate = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_LastModifiedDate;
                requestEntityTypeFilters_entityTypeFilters_DataProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.DataProductVisibilityFilter requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility = null;
            
             // populate Visibility
            var requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_VisibilityIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility = new Amazon.MarketplaceCatalog.Model.DataProductVisibilityFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility_entityTypeFilters_DataProductFilters_Visibility_ValueList = null;
            if (cmdletContext.EntityTypeFilters_DataProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility_entityTypeFilters_DataProductFilters_Visibility_ValueList = cmdletContext.EntityTypeFilters_DataProductFilters_Visibility_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility_entityTypeFilters_DataProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility.ValueList = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility_entityTypeFilters_DataProductFilters_Visibility_ValueList;
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_VisibilityIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_VisibilityIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters.Visibility = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_Visibility;
                requestEntityTypeFilters_entityTypeFilters_DataProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.DataProductTitleFilter requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle = null;
            
             // populate ProductTitle
            var requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitleIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle = new Amazon.MarketplaceCatalog.Model.DataProductTitleFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_ValueList = null;
            if (cmdletContext.EntityTypeFilters_DataProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_ValueList = cmdletContext.EntityTypeFilters_DataProductFilters_ProductTitle_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle.ValueList = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_ValueList;
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitleIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_WildCardValue = null;
            if (cmdletContext.EntityTypeFilters_DataProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_WildCardValue = cmdletContext.EntityTypeFilters_DataProductFilters_ProductTitle_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle.WildCardValue = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle_entityTypeFilters_DataProductFilters_ProductTitle_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitleIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitleIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle != null)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters.ProductTitle = requestEntityTypeFilters_entityTypeFilters_DataProductFilters_entityTypeFilters_DataProductFilters_ProductTitle;
                requestEntityTypeFilters_entityTypeFilters_DataProductFiltersIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_DataProductFilters should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFiltersIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_DataProductFilters = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_DataProductFilters != null)
            {
                request.EntityTypeFilters.DataProductFilters = requestEntityTypeFilters_entityTypeFilters_DataProductFilters;
                requestEntityTypeFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.SaaSProductFilters requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters = null;
            
             // populate SaaSProductFilters
            var requestEntityTypeFilters_entityTypeFilters_SaaSProductFiltersIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters = new Amazon.MarketplaceCatalog.Model.SaaSProductFilters();
            Amazon.MarketplaceCatalog.Model.SaaSProductEntityIdFilter requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId = null;
            
             // populate EntityId
            var requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId = new Amazon.MarketplaceCatalog.Model.SaaSProductEntityIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId_entityTypeFilters_SaaSProductFilters_EntityId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_SaaSProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId_entityTypeFilters_SaaSProductFilters_EntityId_ValueList = cmdletContext.EntityTypeFilters_SaaSProductFilters_EntityId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId_entityTypeFilters_SaaSProductFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId.ValueList = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId_entityTypeFilters_SaaSProductFilters_EntityId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters.EntityId = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_EntityId;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.SaaSProductLastModifiedDateFilter requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate = null;
            
             // populate LastModifiedDate
            var requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate = new Amazon.MarketplaceCatalog.Model.SaaSProductLastModifiedDateFilter();
            Amazon.MarketplaceCatalog.Model.SaaSProductLastModifiedDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange = new Amazon.MarketplaceCatalog.Model.SaaSProductLastModifiedDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate.DateRange = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate_entityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters.LastModifiedDate = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_LastModifiedDate;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.SaaSProductVisibilityFilter requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility = null;
            
             // populate Visibility
            var requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_VisibilityIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility = new Amazon.MarketplaceCatalog.Model.SaaSProductVisibilityFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility_entityTypeFilters_SaaSProductFilters_Visibility_ValueList = null;
            if (cmdletContext.EntityTypeFilters_SaaSProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility_entityTypeFilters_SaaSProductFilters_Visibility_ValueList = cmdletContext.EntityTypeFilters_SaaSProductFilters_Visibility_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility_entityTypeFilters_SaaSProductFilters_Visibility_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility.ValueList = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility_entityTypeFilters_SaaSProductFilters_Visibility_ValueList;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_VisibilityIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_VisibilityIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters.Visibility = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_Visibility;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.SaaSProductTitleFilter requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle = null;
            
             // populate ProductTitle
            var requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitleIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle = new Amazon.MarketplaceCatalog.Model.SaaSProductTitleFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_ValueList = null;
            if (cmdletContext.EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_ValueList = cmdletContext.EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle.ValueList = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_ValueList;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitleIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue = null;
            if (cmdletContext.EntityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue = cmdletContext.EntityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle.WildCardValue = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle_entityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitleIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitleIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle != null)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters.ProductTitle = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters_entityTypeFilters_SaaSProductFilters_ProductTitle;
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFiltersIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFiltersIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters != null)
            {
                request.EntityTypeFilters.SaaSProductFilters = requestEntityTypeFilters_entityTypeFilters_SaaSProductFilters;
                requestEntityTypeFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferFilters requestEntityTypeFilters_entityTypeFilters_OfferFilters = null;
            
             // populate OfferFilters
            var requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters = new Amazon.MarketplaceCatalog.Model.OfferFilters();
            Amazon.MarketplaceCatalog.Model.OfferAvailabilityEndDateFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate = null;
            
             // populate AvailabilityEndDate
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate = new Amazon.MarketplaceCatalog.Model.OfferAvailabilityEndDateFilter();
            Amazon.MarketplaceCatalog.Model.OfferAvailabilityEndDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange = new Amazon.MarketplaceCatalog.Model.OfferAvailabilityEndDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate.DateRange = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate_entityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.AvailabilityEndDate = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_AvailabilityEndDate;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferBuyerAccountsFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts = null;
            
             // populate BuyerAccounts
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccountsIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts = new Amazon.MarketplaceCatalog.Model.OfferBuyerAccountsFilter();
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts_buyerAccounts_WildCardValue = null;
            if (cmdletContext.BuyerAccounts_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts_buyerAccounts_WildCardValue = cmdletContext.BuyerAccounts_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts_buyerAccounts_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts.WildCardValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts_buyerAccounts_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccountsIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccountsIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.BuyerAccounts = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_BuyerAccounts;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferEntityIdFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId = null;
            
             // populate EntityId
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId = new Amazon.MarketplaceCatalog.Model.OfferEntityIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId_entityTypeFilters_OfferFilters_EntityId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId_entityTypeFilters_OfferFilters_EntityId_ValueList = cmdletContext.EntityTypeFilters_OfferFilters_EntityId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId_entityTypeFilters_OfferFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId.ValueList = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId_entityTypeFilters_OfferFilters_EntityId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.EntityId = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_EntityId;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferLastModifiedDateFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate = null;
            
             // populate LastModifiedDate
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate = new Amazon.MarketplaceCatalog.Model.OfferLastModifiedDateFilter();
            Amazon.MarketplaceCatalog.Model.OfferLastModifiedDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange = new Amazon.MarketplaceCatalog.Model.OfferLastModifiedDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate.DateRange = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate_entityTypeFilters_OfferFilters_LastModifiedDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.LastModifiedDate = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_LastModifiedDate;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferProductIdFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId = null;
            
             // populate ProductId
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId = new Amazon.MarketplaceCatalog.Model.OfferProductIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId_entityTypeFilters_OfferFilters_ProductId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_ProductId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId_entityTypeFilters_OfferFilters_ProductId_ValueList = cmdletContext.EntityTypeFilters_OfferFilters_ProductId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId_entityTypeFilters_OfferFilters_ProductId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId.ValueList = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId_entityTypeFilters_OfferFilters_ProductId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.ProductId = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ProductId;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferReleaseDateFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate = null;
            
             // populate ReleaseDate
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate = new Amazon.MarketplaceCatalog.Model.OfferReleaseDateFilter();
            Amazon.MarketplaceCatalog.Model.OfferReleaseDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange = new Amazon.MarketplaceCatalog.Model.OfferReleaseDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_entityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate.DateRange = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate_entityTypeFilters_OfferFilters_ReleaseDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.ReleaseDate = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ReleaseDate;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferResaleAuthorizationIdFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId = null;
            
             // populate ResaleAuthorizationId
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId = new Amazon.MarketplaceCatalog.Model.OfferResaleAuthorizationIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId_resaleAuthorizationId_ValueList = null;
            if (cmdletContext.ResaleAuthorizationId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId_resaleAuthorizationId_ValueList = cmdletContext.ResaleAuthorizationId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId_resaleAuthorizationId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId.ValueList = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId_resaleAuthorizationId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.ResaleAuthorizationId = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_ResaleAuthorizationId;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferStateFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State = null;
            
             // populate State
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_StateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State = new Amazon.MarketplaceCatalog.Model.OfferStateFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State_state_ValueList = null;
            if (cmdletContext.State_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State_state_ValueList = cmdletContext.State_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State_state_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State.ValueList = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State_state_ValueList;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_StateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_StateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.State = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_State;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferTargetingFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting = null;
            
             // populate Targeting
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_TargetingIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting = new Amazon.MarketplaceCatalog.Model.OfferTargetingFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting_targeting_ValueList = null;
            if (cmdletContext.Targeting_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting_targeting_ValueList = cmdletContext.Targeting_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting_targeting_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting.ValueList = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting_targeting_ValueList;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_TargetingIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_TargetingIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.Targeting = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Targeting;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferNameFilter requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name = null;
            
             // populate Name
            var requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_NameIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name = new Amazon.MarketplaceCatalog.Model.OfferNameFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_ValueList = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_Name_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_ValueList = cmdletContext.EntityTypeFilters_OfferFilters_Name_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name.ValueList = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_ValueList;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_NameIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_WildCardValue = null;
            if (cmdletContext.EntityTypeFilters_OfferFilters_Name_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_WildCardValue = cmdletContext.EntityTypeFilters_OfferFilters_Name_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name.WildCardValue = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name_entityTypeFilters_OfferFilters_Name_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_NameIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_NameIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name != null)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters.Name = requestEntityTypeFilters_entityTypeFilters_OfferFilters_entityTypeFilters_OfferFilters_Name;
                requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_OfferFilters should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_OfferFiltersIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_OfferFilters = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_OfferFilters != null)
            {
                request.EntityTypeFilters.OfferFilters = requestEntityTypeFilters_entityTypeFilters_OfferFilters;
                requestEntityTypeFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationFilters requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters = null;
            
             // populate ResaleAuthorizationFilters
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationFilters();
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationEntityIdFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId = null;
            
             // populate EntityId
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationEntityIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId_entityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId_entityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId_entityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId_entityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.EntityId = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_EntityId;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationLastModifiedDateFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate = null;
            
             // populate LastModifiedDate
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationLastModifiedDateFilter();
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationLastModifiedDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationLastModifiedDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate.DateRange = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.LastModifiedDate = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationOfferExtendedStatusFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus = null;
            
             // populate OfferExtendedStatus
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatusIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationOfferExtendedStatusFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus_offerExtendedStatus_ValueList = null;
            if (cmdletContext.OfferExtendedStatus_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus_offerExtendedStatus_ValueList = cmdletContext.OfferExtendedStatus_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus_offerExtendedStatus_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus_offerExtendedStatus_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatusIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatusIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.OfferExtendedStatus = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_OfferExtendedStatus;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationStatusFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status = null;
            
             // populate Status
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_StatusIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationStatusFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status_status_ValueList = null;
            if (cmdletContext.Status_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status_status_ValueList = cmdletContext.Status_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status_status_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status_status_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_StatusIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_StatusIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.Status = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Status;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationAvailabilityEndDateFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate = null;
            
             // populate AvailabilityEndDate
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationAvailabilityEndDateFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDateIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationAvailabilityEndDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationAvailabilityEndDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate.DateRange = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.AvailabilityEndDate = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationCreatedDateFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate = null;
            
             // populate CreatedDate
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDateIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationCreatedDateFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_createdDate_ValueList = null;
            if (cmdletContext.CreatedDate_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_createdDate_ValueList = cmdletContext.CreatedDate_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_createdDate_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_createdDate_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDateIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationCreatedDateFilterDateRange requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange = null;
            
             // populate DateRange
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRangeIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationCreatedDateFilterDateRange();
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange.AfterValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRangeIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange.BeforeValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRangeIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRangeIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate.DateRange = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDateIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDateIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.CreatedDate = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_CreatedDate;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationManufacturerAccountIdFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId = null;
            
             // populate ManufacturerAccountId
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationManufacturerAccountIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_ValueList = null;
            if (cmdletContext.ManufacturerAccountId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_ValueList = cmdletContext.ManufacturerAccountId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountIdIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_WildCardValue = null;
            if (cmdletContext.ManufacturerAccountId_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_WildCardValue = cmdletContext.ManufacturerAccountId_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId_manufacturerAccountId_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.ManufacturerAccountId = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerAccountId;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationManufacturerLegalNameFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName = null;
            
             // populate ManufacturerLegalName
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalNameIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationManufacturerLegalNameFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_ValueList = null;
            if (cmdletContext.ManufacturerLegalName_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_ValueList = cmdletContext.ManufacturerLegalName_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalNameIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_WildCardValue = null;
            if (cmdletContext.ManufacturerLegalName_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_WildCardValue = cmdletContext.ManufacturerLegalName_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName_manufacturerLegalName_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalNameIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalNameIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.ManufacturerLegalName = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ManufacturerLegalName;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationNameFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name = null;
            
             // populate Name
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_NameIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationNameFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_ValueList = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_ValueList = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_NameIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name_entityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_NameIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_NameIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.Name = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_Name;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationProductIdFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId = null;
            
             // populate ProductId
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductIdIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationProductIdFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_entityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList = null;
            if (cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_entityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList = cmdletContext.EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_entityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_entityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductIdIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_productId_WildCardValue = null;
            if (cmdletContext.ProductId_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_productId_WildCardValue = cmdletContext.ProductId_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_productId_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId_productId_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductIdIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductIdIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.ProductId = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductId;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationProductNameFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName = null;
            
             // populate ProductName
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductNameIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationProductNameFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_ValueList = null;
            if (cmdletContext.ProductName_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_ValueList = cmdletContext.ProductName_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductNameIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_WildCardValue = null;
            if (cmdletContext.ProductName_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_WildCardValue = cmdletContext.ProductName_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName_productName_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductNameIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductNameIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.ProductName = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ProductName;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationResellerAccountIDFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID = null;
            
             // populate ResellerAccountID
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountIDIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationResellerAccountIDFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_ValueList = null;
            if (cmdletContext.ResellerAccountID_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_ValueList = cmdletContext.ResellerAccountID_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountIDIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_WildCardValue = null;
            if (cmdletContext.ResellerAccountID_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_WildCardValue = cmdletContext.ResellerAccountID_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID_resellerAccountID_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountIDIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountIDIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.ResellerAccountID = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerAccountID;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationResellerLegalNameFilter requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName = null;
            
             // populate ResellerLegalName
            var requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalNameIsNull = true;
            requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationResellerLegalNameFilter();
            List<System.String> requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_ValueList = null;
            if (cmdletContext.ResellerLegalName_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_ValueList = cmdletContext.ResellerLegalName_ValueList;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_ValueList != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName.ValueList = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_ValueList;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalNameIsNull = false;
            }
            System.String requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_WildCardValue = null;
            if (cmdletContext.ResellerLegalName_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_WildCardValue = cmdletContext.ResellerLegalName_WildCardValue;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_WildCardValue != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName.WildCardValue = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName_resellerLegalName_WildCardValue;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalNameIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalNameIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName != null)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters.ResellerLegalName = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters_entityTypeFilters_ResaleAuthorizationFilters_ResellerLegalName;
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull = false;
            }
             // determine if requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters should be set to null
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFiltersIsNull)
            {
                requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters = null;
            }
            if (requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters != null)
            {
                request.EntityTypeFilters.ResaleAuthorizationFilters = requestEntityTypeFilters_entityTypeFilters_ResaleAuthorizationFilters;
                requestEntityTypeFiltersIsNull = false;
            }
             // determine if request.EntityTypeFilters should be set to null
            if (requestEntityTypeFiltersIsNull)
            {
                request.EntityTypeFilters = null;
            }
            
             // populate EntityTypeSort
            var requestEntityTypeSortIsNull = true;
            request.EntityTypeSort = new Amazon.MarketplaceCatalog.Model.EntityTypeSort();
            Amazon.MarketplaceCatalog.Model.AmiProductSort requestEntityTypeSort_entityTypeSort_AmiProductSort = null;
            
             // populate AmiProductSort
            var requestEntityTypeSort_entityTypeSort_AmiProductSortIsNull = true;
            requestEntityTypeSort_entityTypeSort_AmiProductSort = new Amazon.MarketplaceCatalog.Model.AmiProductSort();
            Amazon.MarketplaceCatalog.AmiProductSortBy requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortBy = null;
            if (cmdletContext.AmiProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortBy = cmdletContext.AmiProductSort_SortBy;
            }
            if (requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_AmiProductSort.SortBy = requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortBy;
                requestEntityTypeSort_entityTypeSort_AmiProductSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.SortOrder requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortOrder = null;
            if (cmdletContext.AmiProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortOrder = cmdletContext.AmiProductSort_SortOrder;
            }
            if (requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_AmiProductSort.SortOrder = requestEntityTypeSort_entityTypeSort_AmiProductSort_amiProductSort_SortOrder;
                requestEntityTypeSort_entityTypeSort_AmiProductSortIsNull = false;
            }
             // determine if requestEntityTypeSort_entityTypeSort_AmiProductSort should be set to null
            if (requestEntityTypeSort_entityTypeSort_AmiProductSortIsNull)
            {
                requestEntityTypeSort_entityTypeSort_AmiProductSort = null;
            }
            if (requestEntityTypeSort_entityTypeSort_AmiProductSort != null)
            {
                request.EntityTypeSort.AmiProductSort = requestEntityTypeSort_entityTypeSort_AmiProductSort;
                requestEntityTypeSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ContainerProductSort requestEntityTypeSort_entityTypeSort_ContainerProductSort = null;
            
             // populate ContainerProductSort
            var requestEntityTypeSort_entityTypeSort_ContainerProductSortIsNull = true;
            requestEntityTypeSort_entityTypeSort_ContainerProductSort = new Amazon.MarketplaceCatalog.Model.ContainerProductSort();
            Amazon.MarketplaceCatalog.ContainerProductSortBy requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortBy = null;
            if (cmdletContext.ContainerProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortBy = cmdletContext.ContainerProductSort_SortBy;
            }
            if (requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_ContainerProductSort.SortBy = requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortBy;
                requestEntityTypeSort_entityTypeSort_ContainerProductSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.SortOrder requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortOrder = null;
            if (cmdletContext.ContainerProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortOrder = cmdletContext.ContainerProductSort_SortOrder;
            }
            if (requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_ContainerProductSort.SortOrder = requestEntityTypeSort_entityTypeSort_ContainerProductSort_containerProductSort_SortOrder;
                requestEntityTypeSort_entityTypeSort_ContainerProductSortIsNull = false;
            }
             // determine if requestEntityTypeSort_entityTypeSort_ContainerProductSort should be set to null
            if (requestEntityTypeSort_entityTypeSort_ContainerProductSortIsNull)
            {
                requestEntityTypeSort_entityTypeSort_ContainerProductSort = null;
            }
            if (requestEntityTypeSort_entityTypeSort_ContainerProductSort != null)
            {
                request.EntityTypeSort.ContainerProductSort = requestEntityTypeSort_entityTypeSort_ContainerProductSort;
                requestEntityTypeSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.DataProductSort requestEntityTypeSort_entityTypeSort_DataProductSort = null;
            
             // populate DataProductSort
            var requestEntityTypeSort_entityTypeSort_DataProductSortIsNull = true;
            requestEntityTypeSort_entityTypeSort_DataProductSort = new Amazon.MarketplaceCatalog.Model.DataProductSort();
            Amazon.MarketplaceCatalog.DataProductSortBy requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortBy = null;
            if (cmdletContext.DataProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortBy = cmdletContext.DataProductSort_SortBy;
            }
            if (requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_DataProductSort.SortBy = requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortBy;
                requestEntityTypeSort_entityTypeSort_DataProductSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.SortOrder requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortOrder = null;
            if (cmdletContext.DataProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortOrder = cmdletContext.DataProductSort_SortOrder;
            }
            if (requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_DataProductSort.SortOrder = requestEntityTypeSort_entityTypeSort_DataProductSort_dataProductSort_SortOrder;
                requestEntityTypeSort_entityTypeSort_DataProductSortIsNull = false;
            }
             // determine if requestEntityTypeSort_entityTypeSort_DataProductSort should be set to null
            if (requestEntityTypeSort_entityTypeSort_DataProductSortIsNull)
            {
                requestEntityTypeSort_entityTypeSort_DataProductSort = null;
            }
            if (requestEntityTypeSort_entityTypeSort_DataProductSort != null)
            {
                request.EntityTypeSort.DataProductSort = requestEntityTypeSort_entityTypeSort_DataProductSort;
                requestEntityTypeSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.OfferSort requestEntityTypeSort_entityTypeSort_OfferSort = null;
            
             // populate OfferSort
            var requestEntityTypeSort_entityTypeSort_OfferSortIsNull = true;
            requestEntityTypeSort_entityTypeSort_OfferSort = new Amazon.MarketplaceCatalog.Model.OfferSort();
            Amazon.MarketplaceCatalog.OfferSortBy requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortBy = null;
            if (cmdletContext.OfferSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortBy = cmdletContext.OfferSort_SortBy;
            }
            if (requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_OfferSort.SortBy = requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortBy;
                requestEntityTypeSort_entityTypeSort_OfferSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.SortOrder requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortOrder = null;
            if (cmdletContext.OfferSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortOrder = cmdletContext.OfferSort_SortOrder;
            }
            if (requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_OfferSort.SortOrder = requestEntityTypeSort_entityTypeSort_OfferSort_offerSort_SortOrder;
                requestEntityTypeSort_entityTypeSort_OfferSortIsNull = false;
            }
             // determine if requestEntityTypeSort_entityTypeSort_OfferSort should be set to null
            if (requestEntityTypeSort_entityTypeSort_OfferSortIsNull)
            {
                requestEntityTypeSort_entityTypeSort_OfferSort = null;
            }
            if (requestEntityTypeSort_entityTypeSort_OfferSort != null)
            {
                request.EntityTypeSort.OfferSort = requestEntityTypeSort_entityTypeSort_OfferSort;
                requestEntityTypeSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ResaleAuthorizationSort requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort = null;
            
             // populate ResaleAuthorizationSort
            var requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSortIsNull = true;
            requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort = new Amazon.MarketplaceCatalog.Model.ResaleAuthorizationSort();
            Amazon.MarketplaceCatalog.ResaleAuthorizationSortBy requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortBy = null;
            if (cmdletContext.ResaleAuthorizationSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortBy = cmdletContext.ResaleAuthorizationSort_SortBy;
            }
            if (requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort.SortBy = requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortBy;
                requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.SortOrder requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortOrder = null;
            if (cmdletContext.ResaleAuthorizationSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortOrder = cmdletContext.ResaleAuthorizationSort_SortOrder;
            }
            if (requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort.SortOrder = requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort_resaleAuthorizationSort_SortOrder;
                requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSortIsNull = false;
            }
             // determine if requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort should be set to null
            if (requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSortIsNull)
            {
                requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort = null;
            }
            if (requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort != null)
            {
                request.EntityTypeSort.ResaleAuthorizationSort = requestEntityTypeSort_entityTypeSort_ResaleAuthorizationSort;
                requestEntityTypeSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.SaaSProductSort requestEntityTypeSort_entityTypeSort_SaaSProductSort = null;
            
             // populate SaaSProductSort
            var requestEntityTypeSort_entityTypeSort_SaaSProductSortIsNull = true;
            requestEntityTypeSort_entityTypeSort_SaaSProductSort = new Amazon.MarketplaceCatalog.Model.SaaSProductSort();
            Amazon.MarketplaceCatalog.SaaSProductSortBy requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortBy = null;
            if (cmdletContext.SaaSProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortBy = cmdletContext.SaaSProductSort_SortBy;
            }
            if (requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortBy != null)
            {
                requestEntityTypeSort_entityTypeSort_SaaSProductSort.SortBy = requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortBy;
                requestEntityTypeSort_entityTypeSort_SaaSProductSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.SortOrder requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortOrder = null;
            if (cmdletContext.SaaSProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortOrder = cmdletContext.SaaSProductSort_SortOrder;
            }
            if (requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortOrder != null)
            {
                requestEntityTypeSort_entityTypeSort_SaaSProductSort.SortOrder = requestEntityTypeSort_entityTypeSort_SaaSProductSort_saaSProductSort_SortOrder;
                requestEntityTypeSort_entityTypeSort_SaaSProductSortIsNull = false;
            }
             // determine if requestEntityTypeSort_entityTypeSort_SaaSProductSort should be set to null
            if (requestEntityTypeSort_entityTypeSort_SaaSProductSortIsNull)
            {
                requestEntityTypeSort_entityTypeSort_SaaSProductSort = null;
            }
            if (requestEntityTypeSort_entityTypeSort_SaaSProductSort != null)
            {
                request.EntityTypeSort.SaaSProductSort = requestEntityTypeSort_entityTypeSort_SaaSProductSort;
                requestEntityTypeSortIsNull = false;
            }
             // determine if request.EntityTypeSort should be set to null
            if (requestEntityTypeSortIsNull)
            {
                request.EntityTypeSort = null;
            }
            if (cmdletContext.FilterList != null)
            {
                request.FilterList = cmdletContext.FilterList;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OwnershipType != null)
            {
                request.OwnershipType = cmdletContext.OwnershipType;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.MarketplaceCatalog.Model.Sort();
            System.String requestSort_sort_SortBy = null;
            if (cmdletContext.Sort_SortBy != null)
            {
                requestSort_sort_SortBy = cmdletContext.Sort_SortBy;
            }
            if (requestSort_sort_SortBy != null)
            {
                request.Sort.SortBy = requestSort_sort_SortBy;
                requestSortIsNull = false;
            }
            Amazon.MarketplaceCatalog.SortOrder requestSort_sort_SortOrder = null;
            if (cmdletContext.Sort_SortOrder != null)
            {
                requestSort_sort_SortOrder = cmdletContext.Sort_SortOrder;
            }
            if (requestSort_sort_SortOrder != null)
            {
                request.Sort.SortOrder = requestSort_sort_SortOrder;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MarketplaceCatalog.Model.ListEntitiesResponse CallAWSServiceOperation(IAmazonMarketplaceCatalog client, Amazon.MarketplaceCatalog.Model.ListEntitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Catalog Service", "ListEntities");
            try
            {
                return client.ListEntitiesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Catalog { get; set; }
            public System.String EntityType { get; set; }
            public List<System.String> EntityTypeFilters_AmiProductFilters_EntityId_ValueList { get; set; }
            public System.String EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_AmiProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
            public List<System.String> EntityTypeFilters_AmiProductFilters_ProductTitle_ValueList { get; set; }
            public System.String EntityTypeFilters_AmiProductFilters_ProductTitle_WildCardValue { get; set; }
            public List<System.String> EntityTypeFilters_AmiProductFilters_Visibility_ValueList { get; set; }
            public List<System.String> EntityTypeFilters_ContainerProductFilters_EntityId_ValueList { get; set; }
            public System.String EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_ContainerProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
            public List<System.String> EntityTypeFilters_ContainerProductFilters_ProductTitle_ValueList { get; set; }
            public System.String EntityTypeFilters_ContainerProductFilters_ProductTitle_WildCardValue { get; set; }
            public List<System.String> EntityTypeFilters_ContainerProductFilters_Visibility_ValueList { get; set; }
            public List<System.String> EntityTypeFilters_DataProductFilters_EntityId_ValueList { get; set; }
            public System.String EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_DataProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
            public List<System.String> EntityTypeFilters_DataProductFilters_ProductTitle_ValueList { get; set; }
            public System.String EntityTypeFilters_DataProductFilters_ProductTitle_WildCardValue { get; set; }
            public List<System.String> EntityTypeFilters_DataProductFilters_Visibility_ValueList { get; set; }
            public System.String EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_OfferFilters_AvailabilityEndDate_DateRange_BeforeValue { get; set; }
            public System.String BuyerAccounts_WildCardValue { get; set; }
            public List<System.String> EntityTypeFilters_OfferFilters_EntityId_ValueList { get; set; }
            public System.String EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_OfferFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
            public List<System.String> EntityTypeFilters_OfferFilters_Name_ValueList { get; set; }
            public System.String EntityTypeFilters_OfferFilters_Name_WildCardValue { get; set; }
            public List<System.String> EntityTypeFilters_OfferFilters_ProductId_ValueList { get; set; }
            public System.String EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_OfferFilters_ReleaseDate_DateRange_BeforeValue { get; set; }
            public List<System.String> ResaleAuthorizationId_ValueList { get; set; }
            public List<System.String> State_ValueList { get; set; }
            public List<System.String> Targeting_ValueList { get; set; }
            public System.String EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_DateRange_BeforeValue { get; set; }
            public List<System.String> EntityTypeFilters_ResaleAuthorizationFilters_AvailabilityEndDate_ValueList { get; set; }
            public System.String EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_ResaleAuthorizationFilters_CreatedDate_DateRange_BeforeValue { get; set; }
            public List<System.String> CreatedDate_ValueList { get; set; }
            public List<System.String> EntityTypeFilters_ResaleAuthorizationFilters_EntityId_ValueList { get; set; }
            public System.String EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_ResaleAuthorizationFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
            public List<System.String> ManufacturerAccountId_ValueList { get; set; }
            public System.String ManufacturerAccountId_WildCardValue { get; set; }
            public List<System.String> ManufacturerLegalName_ValueList { get; set; }
            public System.String ManufacturerLegalName_WildCardValue { get; set; }
            public List<System.String> EntityTypeFilters_ResaleAuthorizationFilters_Name_ValueList { get; set; }
            public System.String EntityTypeFilters_ResaleAuthorizationFilters_Name_WildCardValue { get; set; }
            public List<System.String> OfferExtendedStatus_ValueList { get; set; }
            public List<System.String> EntityTypeFilters_ResaleAuthorizationFilters_ProductId_ValueList { get; set; }
            public System.String ProductId_WildCardValue { get; set; }
            public List<System.String> ProductName_ValueList { get; set; }
            public System.String ProductName_WildCardValue { get; set; }
            public List<System.String> ResellerAccountID_ValueList { get; set; }
            public System.String ResellerAccountID_WildCardValue { get; set; }
            public List<System.String> ResellerLegalName_ValueList { get; set; }
            public System.String ResellerLegalName_WildCardValue { get; set; }
            public List<System.String> Status_ValueList { get; set; }
            public List<System.String> EntityTypeFilters_SaaSProductFilters_EntityId_ValueList { get; set; }
            public System.String EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_AfterValue { get; set; }
            public System.String EntityTypeFilters_SaaSProductFilters_LastModifiedDate_DateRange_BeforeValue { get; set; }
            public List<System.String> EntityTypeFilters_SaaSProductFilters_ProductTitle_ValueList { get; set; }
            public System.String EntityTypeFilters_SaaSProductFilters_ProductTitle_WildCardValue { get; set; }
            public List<System.String> EntityTypeFilters_SaaSProductFilters_Visibility_ValueList { get; set; }
            public Amazon.MarketplaceCatalog.AmiProductSortBy AmiProductSort_SortBy { get; set; }
            public Amazon.MarketplaceCatalog.SortOrder AmiProductSort_SortOrder { get; set; }
            public Amazon.MarketplaceCatalog.ContainerProductSortBy ContainerProductSort_SortBy { get; set; }
            public Amazon.MarketplaceCatalog.SortOrder ContainerProductSort_SortOrder { get; set; }
            public Amazon.MarketplaceCatalog.DataProductSortBy DataProductSort_SortBy { get; set; }
            public Amazon.MarketplaceCatalog.SortOrder DataProductSort_SortOrder { get; set; }
            public Amazon.MarketplaceCatalog.OfferSortBy OfferSort_SortBy { get; set; }
            public Amazon.MarketplaceCatalog.SortOrder OfferSort_SortOrder { get; set; }
            public Amazon.MarketplaceCatalog.ResaleAuthorizationSortBy ResaleAuthorizationSort_SortBy { get; set; }
            public Amazon.MarketplaceCatalog.SortOrder ResaleAuthorizationSort_SortOrder { get; set; }
            public Amazon.MarketplaceCatalog.SaaSProductSortBy SaaSProductSort_SortBy { get; set; }
            public Amazon.MarketplaceCatalog.SortOrder SaaSProductSort_SortOrder { get; set; }
            public List<Amazon.MarketplaceCatalog.Model.Filter> FilterList { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.MarketplaceCatalog.OwnershipType OwnershipType { get; set; }
            public System.String Sort_SortBy { get; set; }
            public Amazon.MarketplaceCatalog.SortOrder Sort_SortOrder { get; set; }
            public System.Func<Amazon.MarketplaceCatalog.Model.ListEntitiesResponse, GetMCATEntityListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EntitySummaryList;
        }
        
    }
}
