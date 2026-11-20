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
using Amazon.APIPortal;
using Amazon.APIPortal.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APIP
{
    /// <summary>
    /// Creates or updates the organization-wide discovery configuration. This is a singleton
    /// per organization. Only the organization management account and registered delegated
    /// administrators may call this operation.
    /// </summary>
    [Cmdlet("Write", "APIPOrganizationDiscoveryConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse")]
    [AWSCmdlet("Calls the APIPortal PutOrganizationDiscoveryConfiguration API operation.", Operation = new[] {"PutOrganizationDiscoveryConfiguration"}, SelectReturnType = typeof(Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse))]
    [AWSCmdletOutput("Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse",
        "This cmdlet returns an Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse object containing multiple properties."
    )]
    public partial class WriteAPIPOrganizationDiscoveryConfigurationCmdlet : AmazonAPIPortalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DiscoveryFilters_ExclusionFilters_AccountId
        /// <summary>
        /// <para>
        /// List of AWS account IDs to exclude from discovery.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryFilters_ExclusionFilters_AccountIds")]
        public System.String[] DiscoveryFilters_ExclusionFilters_AccountId { get; set; }
        #endregion
        
        #region Parameter DiscoveryFilters_InclusionFilters_AccountId
        /// <summary>
        /// <para>
        /// List of AWS account IDs to include in discovery.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryFilters_InclusionFilters_AccountIds")]
        public System.String[] DiscoveryFilters_InclusionFilters_AccountId { get; set; }
        #endregion
        
        #region Parameter ExclusionFilters_AccountId
        /// <summary>
        /// <para>
        /// List of AWS account IDs to exclude from discovery.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionFilters_AccountIds")]
        public System.String[] ExclusionFilters_AccountId { get; set; }
        #endregion
        
        #region Parameter DiscoverySource
        /// <summary>
        /// <para>
        /// The sources to discover APIs from. Omitting
        /// it removes all sources, which stops discovery for this configuration.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoverySources")]
        public System.String[] DiscoverySource { get; set; }
        #endregion
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// Optional capabilities to enable. Omitting it
        /// disables all of them, as with the other fields.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Features")]
        public System.String[] Feature { get; set; }
        #endregion
        
        #region Parameter DiscoveryFilters_ExclusionFilters_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// List of organizational unit IDs
        /// to exclude from discovery.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryFilters_ExclusionFilters_OrganizationalUnitIds")]
        public System.String[] DiscoveryFilters_ExclusionFilters_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter DiscoveryFilters_InclusionFilters_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// List of organizational unit IDs
        /// to include in discovery.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryFilters_InclusionFilters_OrganizationalUnitIds")]
        public System.String[] DiscoveryFilters_InclusionFilters_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter ExclusionFilters_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// List of organizational unit IDs
        /// to exclude from discovery.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionFilters_OrganizationalUnitIds")]
        public System.String[] ExclusionFilters_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter DiscoveryFilters_ExclusionFilters_ResourceArn
        /// <summary>
        /// <para>
        /// List of resource ARNs to exclude. Only ELB
        /// and CloudFront resource ARNs are supported.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryFilters_ExclusionFilters_ResourceArns")]
        public System.String[] DiscoveryFilters_ExclusionFilters_ResourceArn { get; set; }
        #endregion
        
        #region Parameter ExclusionFilters_ResourceArn
        /// <summary>
        /// <para>
        /// List of resource ARNs to exclude. Only ELB
        /// and CloudFront resource ARNs are supported.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionFilters_ResourceArns")]
        public System.String[] ExclusionFilters_ResourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse).
        /// Specifying the name of a property of type Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-APIPOrganizationDiscoveryConfiguration (PutOrganizationDiscoveryConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse, WriteAPIPOrganizationDiscoveryConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DiscoveryFilters_ExclusionFilters_AccountId != null)
            {
                context.DiscoveryFilters_ExclusionFilters_AccountId = new List<System.String>(this.DiscoveryFilters_ExclusionFilters_AccountId);
            }
            if (this.DiscoveryFilters_ExclusionFilters_OrganizationalUnitId != null)
            {
                context.DiscoveryFilters_ExclusionFilters_OrganizationalUnitId = new List<System.String>(this.DiscoveryFilters_ExclusionFilters_OrganizationalUnitId);
            }
            if (this.DiscoveryFilters_ExclusionFilters_ResourceArn != null)
            {
                context.DiscoveryFilters_ExclusionFilters_ResourceArn = new List<System.String>(this.DiscoveryFilters_ExclusionFilters_ResourceArn);
            }
            if (this.DiscoveryFilters_InclusionFilters_AccountId != null)
            {
                context.DiscoveryFilters_InclusionFilters_AccountId = new List<System.String>(this.DiscoveryFilters_InclusionFilters_AccountId);
            }
            if (this.DiscoveryFilters_InclusionFilters_OrganizationalUnitId != null)
            {
                context.DiscoveryFilters_InclusionFilters_OrganizationalUnitId = new List<System.String>(this.DiscoveryFilters_InclusionFilters_OrganizationalUnitId);
            }
            if (this.DiscoverySource != null)
            {
                context.DiscoverySource = new List<System.String>(this.DiscoverySource);
            }
            if (this.ExclusionFilters_AccountId != null)
            {
                context.ExclusionFilters_AccountId = new List<System.String>(this.ExclusionFilters_AccountId);
            }
            if (this.ExclusionFilters_OrganizationalUnitId != null)
            {
                context.ExclusionFilters_OrganizationalUnitId = new List<System.String>(this.ExclusionFilters_OrganizationalUnitId);
            }
            if (this.ExclusionFilters_ResourceArn != null)
            {
                context.ExclusionFilters_ResourceArn = new List<System.String>(this.ExclusionFilters_ResourceArn);
            }
            if (this.Feature != null)
            {
                context.Feature = new List<System.String>(this.Feature);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationRequest();
            
            
             // populate DiscoveryFilters
            var requestDiscoveryFiltersIsNull = true;
            request.DiscoveryFilters = new Amazon.APIPortal.Model.OrganizationDiscoveryFilters();
            Amazon.APIPortal.Model.DiscoveryInclusionFilters requestDiscoveryFilters_discoveryFilters_InclusionFilters = null;
            
             // populate InclusionFilters
            var requestDiscoveryFilters_discoveryFilters_InclusionFiltersIsNull = true;
            requestDiscoveryFilters_discoveryFilters_InclusionFilters = new Amazon.APIPortal.Model.DiscoveryInclusionFilters();
            List<System.String> requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_AccountId = null;
            if (cmdletContext.DiscoveryFilters_InclusionFilters_AccountId != null)
            {
                requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_AccountId = cmdletContext.DiscoveryFilters_InclusionFilters_AccountId;
            }
            if (requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_AccountId != null)
            {
                requestDiscoveryFilters_discoveryFilters_InclusionFilters.AccountIds = requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_AccountId;
                requestDiscoveryFilters_discoveryFilters_InclusionFiltersIsNull = false;
            }
            List<System.String> requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_OrganizationalUnitId = null;
            if (cmdletContext.DiscoveryFilters_InclusionFilters_OrganizationalUnitId != null)
            {
                requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_OrganizationalUnitId = cmdletContext.DiscoveryFilters_InclusionFilters_OrganizationalUnitId;
            }
            if (requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_OrganizationalUnitId != null)
            {
                requestDiscoveryFilters_discoveryFilters_InclusionFilters.OrganizationalUnitIds = requestDiscoveryFilters_discoveryFilters_InclusionFilters_discoveryFilters_InclusionFilters_OrganizationalUnitId;
                requestDiscoveryFilters_discoveryFilters_InclusionFiltersIsNull = false;
            }
             // determine if requestDiscoveryFilters_discoveryFilters_InclusionFilters should be set to null
            if (requestDiscoveryFilters_discoveryFilters_InclusionFiltersIsNull)
            {
                requestDiscoveryFilters_discoveryFilters_InclusionFilters = null;
            }
            if (requestDiscoveryFilters_discoveryFilters_InclusionFilters != null)
            {
                request.DiscoveryFilters.InclusionFilters = requestDiscoveryFilters_discoveryFilters_InclusionFilters;
                requestDiscoveryFiltersIsNull = false;
            }
            Amazon.APIPortal.Model.DiscoveryExclusionFilters requestDiscoveryFilters_discoveryFilters_ExclusionFilters = null;
            
             // populate ExclusionFilters
            var requestDiscoveryFilters_discoveryFilters_ExclusionFiltersIsNull = true;
            requestDiscoveryFilters_discoveryFilters_ExclusionFilters = new Amazon.APIPortal.Model.DiscoveryExclusionFilters();
            List<System.String> requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_AccountId = null;
            if (cmdletContext.DiscoveryFilters_ExclusionFilters_AccountId != null)
            {
                requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_AccountId = cmdletContext.DiscoveryFilters_ExclusionFilters_AccountId;
            }
            if (requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_AccountId != null)
            {
                requestDiscoveryFilters_discoveryFilters_ExclusionFilters.AccountIds = requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_AccountId;
                requestDiscoveryFilters_discoveryFilters_ExclusionFiltersIsNull = false;
            }
            List<System.String> requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_OrganizationalUnitId = null;
            if (cmdletContext.DiscoveryFilters_ExclusionFilters_OrganizationalUnitId != null)
            {
                requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_OrganizationalUnitId = cmdletContext.DiscoveryFilters_ExclusionFilters_OrganizationalUnitId;
            }
            if (requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_OrganizationalUnitId != null)
            {
                requestDiscoveryFilters_discoveryFilters_ExclusionFilters.OrganizationalUnitIds = requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_OrganizationalUnitId;
                requestDiscoveryFilters_discoveryFilters_ExclusionFiltersIsNull = false;
            }
            List<System.String> requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_ResourceArn = null;
            if (cmdletContext.DiscoveryFilters_ExclusionFilters_ResourceArn != null)
            {
                requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_ResourceArn = cmdletContext.DiscoveryFilters_ExclusionFilters_ResourceArn;
            }
            if (requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_ResourceArn != null)
            {
                requestDiscoveryFilters_discoveryFilters_ExclusionFilters.ResourceArns = requestDiscoveryFilters_discoveryFilters_ExclusionFilters_discoveryFilters_ExclusionFilters_ResourceArn;
                requestDiscoveryFilters_discoveryFilters_ExclusionFiltersIsNull = false;
            }
             // determine if requestDiscoveryFilters_discoveryFilters_ExclusionFilters should be set to null
            if (requestDiscoveryFilters_discoveryFilters_ExclusionFiltersIsNull)
            {
                requestDiscoveryFilters_discoveryFilters_ExclusionFilters = null;
            }
            if (requestDiscoveryFilters_discoveryFilters_ExclusionFilters != null)
            {
                request.DiscoveryFilters.ExclusionFilters = requestDiscoveryFilters_discoveryFilters_ExclusionFilters;
                requestDiscoveryFiltersIsNull = false;
            }
             // determine if request.DiscoveryFilters should be set to null
            if (requestDiscoveryFiltersIsNull)
            {
                request.DiscoveryFilters = null;
            }
            if (cmdletContext.DiscoverySource != null)
            {
                request.DiscoverySources = cmdletContext.DiscoverySource;
            }
            
             // populate ExclusionFilters
            var requestExclusionFiltersIsNull = true;
            request.ExclusionFilters = new Amazon.APIPortal.Model.DiscoveryExclusionFilters();
            List<System.String> requestExclusionFilters_exclusionFilters_AccountId = null;
            if (cmdletContext.ExclusionFilters_AccountId != null)
            {
                requestExclusionFilters_exclusionFilters_AccountId = cmdletContext.ExclusionFilters_AccountId;
            }
            if (requestExclusionFilters_exclusionFilters_AccountId != null)
            {
                request.ExclusionFilters.AccountIds = requestExclusionFilters_exclusionFilters_AccountId;
                requestExclusionFiltersIsNull = false;
            }
            List<System.String> requestExclusionFilters_exclusionFilters_OrganizationalUnitId = null;
            if (cmdletContext.ExclusionFilters_OrganizationalUnitId != null)
            {
                requestExclusionFilters_exclusionFilters_OrganizationalUnitId = cmdletContext.ExclusionFilters_OrganizationalUnitId;
            }
            if (requestExclusionFilters_exclusionFilters_OrganizationalUnitId != null)
            {
                request.ExclusionFilters.OrganizationalUnitIds = requestExclusionFilters_exclusionFilters_OrganizationalUnitId;
                requestExclusionFiltersIsNull = false;
            }
            List<System.String> requestExclusionFilters_exclusionFilters_ResourceArn = null;
            if (cmdletContext.ExclusionFilters_ResourceArn != null)
            {
                requestExclusionFilters_exclusionFilters_ResourceArn = cmdletContext.ExclusionFilters_ResourceArn;
            }
            if (requestExclusionFilters_exclusionFilters_ResourceArn != null)
            {
                request.ExclusionFilters.ResourceArns = requestExclusionFilters_exclusionFilters_ResourceArn;
                requestExclusionFiltersIsNull = false;
            }
             // determine if request.ExclusionFilters should be set to null
            if (requestExclusionFiltersIsNull)
            {
                request.ExclusionFilters = null;
            }
            if (cmdletContext.Feature != null)
            {
                request.Features = cmdletContext.Feature;
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
        
        private Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse CallAWSServiceOperation(IAmazonAPIPortal client, Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "APIPortal", "PutOrganizationDiscoveryConfiguration");
            try
            {
                return client.PutOrganizationDiscoveryConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> DiscoveryFilters_ExclusionFilters_AccountId { get; set; }
            public List<System.String> DiscoveryFilters_ExclusionFilters_OrganizationalUnitId { get; set; }
            public List<System.String> DiscoveryFilters_ExclusionFilters_ResourceArn { get; set; }
            public List<System.String> DiscoveryFilters_InclusionFilters_AccountId { get; set; }
            public List<System.String> DiscoveryFilters_InclusionFilters_OrganizationalUnitId { get; set; }
            public List<System.String> DiscoverySource { get; set; }
            public List<System.String> ExclusionFilters_AccountId { get; set; }
            public List<System.String> ExclusionFilters_OrganizationalUnitId { get; set; }
            public List<System.String> ExclusionFilters_ResourceArn { get; set; }
            public List<System.String> Feature { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.APIPortal.Model.PutOrganizationDiscoveryConfigurationResponse, WriteAPIPOrganizationDiscoveryConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
