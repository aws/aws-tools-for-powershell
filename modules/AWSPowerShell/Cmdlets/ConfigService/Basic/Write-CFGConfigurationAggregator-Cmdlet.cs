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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates and updates the configuration aggregator with the selected source accounts
    /// and regions. The source account can be individual account(s) or an organization.
    /// 
    ///  
    /// <para><c>accountIds</c> that are passed will be replaced with existing accounts. If you
    /// want to add additional accounts into the aggregator, call <c>DescribeConfigurationAggregators</c>
    /// to get the previous accounts and then append new ones.
    /// </para><note><para>
    /// Config should be enabled in source accounts and regions you want to aggregate.
    /// </para><para>
    /// If your source type is an organization, you must be signed in to the management account
    /// or a registered delegated administrator and all the features must be enabled in your
    /// organization. If the caller is a management account, Config calls <c>EnableAwsServiceAccess</c>
    /// API to enable integration between Config and Organizations. If the caller is a registered
    /// delegated administrator, Config calls <c>ListDelegatedAdministrators</c> API to verify
    /// whether the caller is a valid delegated administrator.
    /// </para><para>
    /// To register a delegated administrator, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/set-up-aggregator-cli.html#register-a-delegated-administrator-cli">Register
    /// a Delegated Administrator</a> in the <i>Config developer guide</i>. 
    /// </para></note><note><para><b>Tags are added at creation and cannot be updated with this operation</b></para><para><c>PutConfigurationAggregator</c> is an idempotent API. Subsequent requests won’t
    /// create a duplicate resource if one was already created. If a following request has
    /// different <c>tags</c> values, Config will ignore these differences and treat it as
    /// an idempotent request of the previous. In this case, <c>tags</c> will not be updated,
    /// even if they are different.
    /// </para><para>
    /// Use <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_TagResource.html">TagResource</a>
    /// and <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_UntagResource.html">UntagResource</a>
    /// to update tags after creation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConfigurationAggregator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.ConfigurationAggregator")]
    [AWSCmdlet("Calls the AWS Config PutConfigurationAggregator API operation.", Operation = new[] {"PutConfigurationAggregator"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutConfigurationAggregatorResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationAggregator or Amazon.ConfigService.Model.PutConfigurationAggregatorResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.ConfigurationAggregator object.",
        "The service call response (type Amazon.ConfigService.Model.PutConfigurationAggregatorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCFGConfigurationAggregatorCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountAggregationSource
        /// <summary>
        /// <para>
        /// <para>A list of AccountAggregationSource object. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountAggregationSources")]
        public Amazon.ConfigService.Model.AccountAggregationSource[] AccountAggregationSource { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_AllAwsRegion
        /// <summary>
        /// <para>
        /// <para>If true, aggregate existing Config regions and future regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationAggregationSource_AllAwsRegions")]
        public System.Boolean? OrganizationAggregationSource_AllAwsRegion { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_AwsRegion
        /// <summary>
        /// <para>
        /// <para>The source regions being aggregated.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationAggregationSource_AwsRegions")]
        public System.String[] OrganizationAggregationSource_AwsRegion { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
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
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_RoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role used to retrieve Amazon Web Services Organization details associated
        /// with the aggregator account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationAggregationSource_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of tag object.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ResourceType_Type
        /// <summary>
        /// <para>
        /// <para>The type of resource type filter to apply. <c>INCLUDE</c> specifies that the list
        /// of resource types in the <c>Value</c> field will be aggregated and no other resource
        /// types will be filtered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregatorFilters_ResourceType_Type")]
        [AWSConstantClassSource("Amazon.ConfigService.AggregatorFilterType")]
        public Amazon.ConfigService.AggregatorFilterType ResourceType_Type { get; set; }
        #endregion
        
        #region Parameter ServicePrincipal_Type
        /// <summary>
        /// <para>
        /// <para>The type of service principal filter to apply. <c>INCLUDE</c> specifies that the list
        /// of service principals in the <c>Value</c> field will be aggregated and no other service
        /// principals will be filtered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregatorFilters_ServicePrincipal_Type")]
        [AWSConstantClassSource("Amazon.ConfigService.AggregatorFilterType")]
        public Amazon.ConfigService.AggregatorFilterType ServicePrincipal_Type { get; set; }
        #endregion
        
        #region Parameter ResourceType_Value
        /// <summary>
        /// <para>
        /// <para>Comma-separate list of resource types to filter your aggregated configuration recorders.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregatorFilters_ResourceType_Value")]
        public System.String[] ResourceType_Value { get; set; }
        #endregion
        
        #region Parameter ServicePrincipal_Value
        /// <summary>
        /// <para>
        /// <para>Comma-separated list of service principals for the linked Amazon Web Services services
        /// to filter your aggregated service-linked configuration recorders.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregatorFilters_ServicePrincipal_Value")]
        public System.String[] ServicePrincipal_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigurationAggregator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutConfigurationAggregatorResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutConfigurationAggregatorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigurationAggregator";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationAggregatorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConfigurationAggregator (PutConfigurationAggregator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutConfigurationAggregatorResponse, WriteCFGConfigurationAggregatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountAggregationSource != null)
            {
                context.AccountAggregationSource = new List<Amazon.ConfigService.Model.AccountAggregationSource>(this.AccountAggregationSource);
            }
            context.ResourceType_Type = this.ResourceType_Type;
            if (this.ResourceType_Value != null)
            {
                context.ResourceType_Value = new List<System.String>(this.ResourceType_Value);
            }
            context.ServicePrincipal_Type = this.ServicePrincipal_Type;
            if (this.ServicePrincipal_Value != null)
            {
                context.ServicePrincipal_Value = new List<System.String>(this.ServicePrincipal_Value);
            }
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            #if MODULAR
            if (this.ConfigurationAggregatorName == null && ParameterWasBound(nameof(this.ConfigurationAggregatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationAggregatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationAggregationSource_AllAwsRegion = this.OrganizationAggregationSource_AllAwsRegion;
            if (this.OrganizationAggregationSource_AwsRegion != null)
            {
                context.OrganizationAggregationSource_AwsRegion = new List<System.String>(this.OrganizationAggregationSource_AwsRegion);
            }
            context.OrganizationAggregationSource_RoleArn = this.OrganizationAggregationSource_RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ConfigService.Model.PutConfigurationAggregatorRequest();
            
            if (cmdletContext.AccountAggregationSource != null)
            {
                request.AccountAggregationSources = cmdletContext.AccountAggregationSource;
            }
            
             // populate AggregatorFilters
            var requestAggregatorFiltersIsNull = true;
            request.AggregatorFilters = new Amazon.ConfigService.Model.AggregatorFilters();
            Amazon.ConfigService.Model.AggregatorFilterResourceType requestAggregatorFilters_aggregatorFilters_ResourceType = null;
            
             // populate ResourceType
            var requestAggregatorFilters_aggregatorFilters_ResourceTypeIsNull = true;
            requestAggregatorFilters_aggregatorFilters_ResourceType = new Amazon.ConfigService.Model.AggregatorFilterResourceType();
            Amazon.ConfigService.AggregatorFilterType requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Type = null;
            if (cmdletContext.ResourceType_Type != null)
            {
                requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Type = cmdletContext.ResourceType_Type;
            }
            if (requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Type != null)
            {
                requestAggregatorFilters_aggregatorFilters_ResourceType.Type = requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Type;
                requestAggregatorFilters_aggregatorFilters_ResourceTypeIsNull = false;
            }
            List<System.String> requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Value = null;
            if (cmdletContext.ResourceType_Value != null)
            {
                requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Value = cmdletContext.ResourceType_Value;
            }
            if (requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Value != null)
            {
                requestAggregatorFilters_aggregatorFilters_ResourceType.Value = requestAggregatorFilters_aggregatorFilters_ResourceType_resourceType_Value;
                requestAggregatorFilters_aggregatorFilters_ResourceTypeIsNull = false;
            }
             // determine if requestAggregatorFilters_aggregatorFilters_ResourceType should be set to null
            if (requestAggregatorFilters_aggregatorFilters_ResourceTypeIsNull)
            {
                requestAggregatorFilters_aggregatorFilters_ResourceType = null;
            }
            if (requestAggregatorFilters_aggregatorFilters_ResourceType != null)
            {
                request.AggregatorFilters.ResourceType = requestAggregatorFilters_aggregatorFilters_ResourceType;
                requestAggregatorFiltersIsNull = false;
            }
            Amazon.ConfigService.Model.AggregatorFilterServicePrincipal requestAggregatorFilters_aggregatorFilters_ServicePrincipal = null;
            
             // populate ServicePrincipal
            var requestAggregatorFilters_aggregatorFilters_ServicePrincipalIsNull = true;
            requestAggregatorFilters_aggregatorFilters_ServicePrincipal = new Amazon.ConfigService.Model.AggregatorFilterServicePrincipal();
            Amazon.ConfigService.AggregatorFilterType requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Type = null;
            if (cmdletContext.ServicePrincipal_Type != null)
            {
                requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Type = cmdletContext.ServicePrincipal_Type;
            }
            if (requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Type != null)
            {
                requestAggregatorFilters_aggregatorFilters_ServicePrincipal.Type = requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Type;
                requestAggregatorFilters_aggregatorFilters_ServicePrincipalIsNull = false;
            }
            List<System.String> requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Value = null;
            if (cmdletContext.ServicePrincipal_Value != null)
            {
                requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Value = cmdletContext.ServicePrincipal_Value;
            }
            if (requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Value != null)
            {
                requestAggregatorFilters_aggregatorFilters_ServicePrincipal.Value = requestAggregatorFilters_aggregatorFilters_ServicePrincipal_servicePrincipal_Value;
                requestAggregatorFilters_aggregatorFilters_ServicePrincipalIsNull = false;
            }
             // determine if requestAggregatorFilters_aggregatorFilters_ServicePrincipal should be set to null
            if (requestAggregatorFilters_aggregatorFilters_ServicePrincipalIsNull)
            {
                requestAggregatorFilters_aggregatorFilters_ServicePrincipal = null;
            }
            if (requestAggregatorFilters_aggregatorFilters_ServicePrincipal != null)
            {
                request.AggregatorFilters.ServicePrincipal = requestAggregatorFilters_aggregatorFilters_ServicePrincipal;
                requestAggregatorFiltersIsNull = false;
            }
             // determine if request.AggregatorFilters should be set to null
            if (requestAggregatorFiltersIsNull)
            {
                request.AggregatorFilters = null;
            }
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate OrganizationAggregationSource
            var requestOrganizationAggregationSourceIsNull = true;
            request.OrganizationAggregationSource = new Amazon.ConfigService.Model.OrganizationAggregationSource();
            System.Boolean? requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion = null;
            if (cmdletContext.OrganizationAggregationSource_AllAwsRegion != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion = cmdletContext.OrganizationAggregationSource_AllAwsRegion.Value;
            }
            if (requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion != null)
            {
                request.OrganizationAggregationSource.AllAwsRegions = requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion.Value;
                requestOrganizationAggregationSourceIsNull = false;
            }
            List<System.String> requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion = null;
            if (cmdletContext.OrganizationAggregationSource_AwsRegion != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion = cmdletContext.OrganizationAggregationSource_AwsRegion;
            }
            if (requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion != null)
            {
                request.OrganizationAggregationSource.AwsRegions = requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion;
                requestOrganizationAggregationSourceIsNull = false;
            }
            System.String requestOrganizationAggregationSource_organizationAggregationSource_RoleArn = null;
            if (cmdletContext.OrganizationAggregationSource_RoleArn != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_RoleArn = cmdletContext.OrganizationAggregationSource_RoleArn;
            }
            if (requestOrganizationAggregationSource_organizationAggregationSource_RoleArn != null)
            {
                request.OrganizationAggregationSource.RoleArn = requestOrganizationAggregationSource_organizationAggregationSource_RoleArn;
                requestOrganizationAggregationSourceIsNull = false;
            }
             // determine if request.OrganizationAggregationSource should be set to null
            if (requestOrganizationAggregationSourceIsNull)
            {
                request.OrganizationAggregationSource = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ConfigService.Model.PutConfigurationAggregatorResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutConfigurationAggregatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutConfigurationAggregator");
            try
            {
                return client.PutConfigurationAggregatorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConfigService.Model.AccountAggregationSource> AccountAggregationSource { get; set; }
            public Amazon.ConfigService.AggregatorFilterType ResourceType_Type { get; set; }
            public List<System.String> ResourceType_Value { get; set; }
            public Amazon.ConfigService.AggregatorFilterType ServicePrincipal_Type { get; set; }
            public List<System.String> ServicePrincipal_Value { get; set; }
            public System.String ConfigurationAggregatorName { get; set; }
            public System.Boolean? OrganizationAggregationSource_AllAwsRegion { get; set; }
            public List<System.String> OrganizationAggregationSource_AwsRegion { get; set; }
            public System.String OrganizationAggregationSource_RoleArn { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutConfigurationAggregatorResponse, WriteCFGConfigurationAggregatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationAggregator;
        }
        
    }
}
