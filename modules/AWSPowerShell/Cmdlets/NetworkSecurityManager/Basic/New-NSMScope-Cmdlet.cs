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
using Amazon.NetworkSecurityManager;
using Amazon.NetworkSecurityManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NSM
{
    /// <summary>
    /// Creates a scope. A scope selects the accounts and resources that a deployment applies
    /// to. Use <c>isPublished</c> to create the scope in published (<c>ACTIVE</c>) or draft
    /// (<c>DRAFT</c>) state.
    /// </summary>
    [Cmdlet("New", "NSMScope", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkSecurityManager.Model.CreateScopeResponse")]
    [AWSCmdlet("Calls the AWS Network Security Manager Customer API CreateScope API operation.", Operation = new[] {"CreateScope"}, SelectReturnType = typeof(Amazon.NetworkSecurityManager.Model.CreateScopeResponse))]
    [AWSCmdletOutput("Amazon.NetworkSecurityManager.Model.CreateScopeResponse",
        "This cmdlet returns an Amazon.NetworkSecurityManager.Model.CreateScopeResponse object containing multiple properties."
    )]
    public partial class NewNSMScopeCmdlet : AmazonNetworkSecurityManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ScopeConfiguration_AccountFilter_Exclude_AccountId
        /// <summary>
        /// <para>
        /// <para>The list of AWS account IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeConfiguration_AccountFilter_Exclude_AccountIds")]
        public System.String[] ScopeConfiguration_AccountFilter_Exclude_AccountId { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_AccountFilter_Include_AccountId
        /// <summary>
        /// <para>
        /// <para>The list of AWS account IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeConfiguration_AccountFilter_Include_AccountIds")]
        public System.String[] ScopeConfiguration_AccountFilter_Include_AccountId { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_AccountFilter_IncludeAll
        /// <summary>
        /// <para>
        /// <para>Includes all accounts. No account filtering is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkSecurityManager.Model.Unit ScopeConfiguration_AccountFilter_IncludeAll { get; set; }
        #endregion
        
        #region Parameter IsPublished
        /// <summary>
        /// <para>
        /// <para>Specifies whether to publish the resource. When <c>true</c>, the resource is saved
        /// in published (<c>ACTIVE</c>) state. When <c>false</c>, it is saved as a draft (<c>DRAFT</c>).
        /// Default: <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsPublished { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>The AWS Organizations organizational units (OUs) in the selection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnits")]
        public System.String[] ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_AccountFilter_Include_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>The AWS Organizations organizational units (OUs) in the selection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeConfiguration_AccountFilter_Include_OrganizationalUnits")]
        public System.String[] ScopeConfiguration_AccountFilter_Include_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter ScopeConfiguration_ResourceScope
        /// <summary>
        /// <para>
        /// <para>The resource-level scoping configuration, keyed by resource type, that defines which
        /// resources within the selected accounts are in scope.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ScopeConfiguration_ResourceScopes")]
        public System.Collections.Hashtable ScopeConfiguration_ResourceScope { get; set; }
        #endregion
        
        #region Parameter ScopeDescription
        /// <summary>
        /// <para>
        /// <para>A description of the scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScopeDescription { get; set; }
        #endregion
        
        #region Parameter ScopeName
        /// <summary>
        /// <para>
        /// <para>The name of the scope.</para>
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
        public System.String ScopeName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the resource when it is created.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure that the operation completes
        /// no more than one time. If you retry a request with the same client token and the same
        /// parameters, the service returns the result of the original successful request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkSecurityManager.Model.CreateScopeResponse).
        /// Specifying the name of a property of type Amazon.NetworkSecurityManager.Model.CreateScopeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScopeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NSMScope (CreateScope)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkSecurityManager.Model.CreateScopeResponse, NewNSMScopeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.IsPublished = this.IsPublished;
            if (this.ScopeConfiguration_AccountFilter_Exclude_AccountId != null)
            {
                context.ScopeConfiguration_AccountFilter_Exclude_AccountId = new List<System.String>(this.ScopeConfiguration_AccountFilter_Exclude_AccountId);
            }
            if (this.ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit != null)
            {
                context.ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit = new List<System.String>(this.ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit);
            }
            if (this.ScopeConfiguration_AccountFilter_Include_AccountId != null)
            {
                context.ScopeConfiguration_AccountFilter_Include_AccountId = new List<System.String>(this.ScopeConfiguration_AccountFilter_Include_AccountId);
            }
            if (this.ScopeConfiguration_AccountFilter_Include_OrganizationalUnit != null)
            {
                context.ScopeConfiguration_AccountFilter_Include_OrganizationalUnit = new List<System.String>(this.ScopeConfiguration_AccountFilter_Include_OrganizationalUnit);
            }
            context.ScopeConfiguration_AccountFilter_IncludeAll = this.ScopeConfiguration_AccountFilter_IncludeAll;
            if (this.ScopeConfiguration_ResourceScope != null)
            {
                context.ScopeConfiguration_ResourceScope = new Dictionary<System.String, Amazon.NetworkSecurityManager.Model.ResourceScope>(StringComparer.Ordinal);
                foreach (var hashKey in this.ScopeConfiguration_ResourceScope.Keys)
                {
                    context.ScopeConfiguration_ResourceScope.Add((String)hashKey, (Amazon.NetworkSecurityManager.Model.ResourceScope)(this.ScopeConfiguration_ResourceScope[hashKey]));
                }
            }
            #if MODULAR
            if (this.ScopeConfiguration_ResourceScope == null && ParameterWasBound(nameof(this.ScopeConfiguration_ResourceScope)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeConfiguration_ResourceScope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScopeDescription = this.ScopeDescription;
            context.ScopeName = this.ScopeName;
            #if MODULAR
            if (this.ScopeName == null && ParameterWasBound(nameof(this.ScopeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.NetworkSecurityManager.Model.CreateScopeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.IsPublished != null)
            {
                request.IsPublished = cmdletContext.IsPublished.Value;
            }
            
             // populate ScopeConfiguration
            var requestScopeConfigurationIsNull = true;
            request.ScopeConfiguration = new Amazon.NetworkSecurityManager.Model.ScopeConfiguration();
            Dictionary<System.String, Amazon.NetworkSecurityManager.Model.ResourceScope> requestScopeConfiguration_scopeConfiguration_ResourceScope = null;
            if (cmdletContext.ScopeConfiguration_ResourceScope != null)
            {
                requestScopeConfiguration_scopeConfiguration_ResourceScope = cmdletContext.ScopeConfiguration_ResourceScope;
            }
            if (requestScopeConfiguration_scopeConfiguration_ResourceScope != null)
            {
                request.ScopeConfiguration.ResourceScopes = requestScopeConfiguration_scopeConfiguration_ResourceScope;
                requestScopeConfigurationIsNull = false;
            }
            Amazon.NetworkSecurityManager.Model.AccountFilter requestScopeConfiguration_scopeConfiguration_AccountFilter = null;
            
             // populate AccountFilter
            var requestScopeConfiguration_scopeConfiguration_AccountFilterIsNull = true;
            requestScopeConfiguration_scopeConfiguration_AccountFilter = new Amazon.NetworkSecurityManager.Model.AccountFilter();
            Amazon.NetworkSecurityManager.Model.Unit requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeAll = null;
            if (cmdletContext.ScopeConfiguration_AccountFilter_IncludeAll != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeAll = cmdletContext.ScopeConfiguration_AccountFilter_IncludeAll;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeAll != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter.IncludeAll = requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeAll;
                requestScopeConfiguration_scopeConfiguration_AccountFilterIsNull = false;
            }
            Amazon.NetworkSecurityManager.Model.AccountSet requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude = null;
            
             // populate Exclude
            var requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_ExcludeIsNull = true;
            requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude = new Amazon.NetworkSecurityManager.Model.AccountSet();
            List<System.String> requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_AccountId = null;
            if (cmdletContext.ScopeConfiguration_AccountFilter_Exclude_AccountId != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_AccountId = cmdletContext.ScopeConfiguration_AccountFilter_Exclude_AccountId;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_AccountId != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude.AccountIds = requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_AccountId;
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_ExcludeIsNull = false;
            }
            List<System.String> requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_OrganizationalUnit = null;
            if (cmdletContext.ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_OrganizationalUnit = cmdletContext.ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_OrganizationalUnit != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude.OrganizationalUnits = requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude_scopeConfiguration_AccountFilter_Exclude_OrganizationalUnit;
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_ExcludeIsNull = false;
            }
             // determine if requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude should be set to null
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_ExcludeIsNull)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude = null;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter.Exclude = requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Exclude;
                requestScopeConfiguration_scopeConfiguration_AccountFilterIsNull = false;
            }
            Amazon.NetworkSecurityManager.Model.AccountSet requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include = null;
            
             // populate Include
            var requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeIsNull = true;
            requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include = new Amazon.NetworkSecurityManager.Model.AccountSet();
            List<System.String> requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_AccountId = null;
            if (cmdletContext.ScopeConfiguration_AccountFilter_Include_AccountId != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_AccountId = cmdletContext.ScopeConfiguration_AccountFilter_Include_AccountId;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_AccountId != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include.AccountIds = requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_AccountId;
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeIsNull = false;
            }
            List<System.String> requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_OrganizationalUnit = null;
            if (cmdletContext.ScopeConfiguration_AccountFilter_Include_OrganizationalUnit != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_OrganizationalUnit = cmdletContext.ScopeConfiguration_AccountFilter_Include_OrganizationalUnit;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_OrganizationalUnit != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include.OrganizationalUnits = requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include_scopeConfiguration_AccountFilter_Include_OrganizationalUnit;
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeIsNull = false;
            }
             // determine if requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include should be set to null
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_IncludeIsNull)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include = null;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include != null)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter.Include = requestScopeConfiguration_scopeConfiguration_AccountFilter_scopeConfiguration_AccountFilter_Include;
                requestScopeConfiguration_scopeConfiguration_AccountFilterIsNull = false;
            }
             // determine if requestScopeConfiguration_scopeConfiguration_AccountFilter should be set to null
            if (requestScopeConfiguration_scopeConfiguration_AccountFilterIsNull)
            {
                requestScopeConfiguration_scopeConfiguration_AccountFilter = null;
            }
            if (requestScopeConfiguration_scopeConfiguration_AccountFilter != null)
            {
                request.ScopeConfiguration.AccountFilter = requestScopeConfiguration_scopeConfiguration_AccountFilter;
                requestScopeConfigurationIsNull = false;
            }
             // determine if request.ScopeConfiguration should be set to null
            if (requestScopeConfigurationIsNull)
            {
                request.ScopeConfiguration = null;
            }
            if (cmdletContext.ScopeDescription != null)
            {
                request.ScopeDescription = cmdletContext.ScopeDescription;
            }
            if (cmdletContext.ScopeName != null)
            {
                request.ScopeName = cmdletContext.ScopeName;
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
        
        private Amazon.NetworkSecurityManager.Model.CreateScopeResponse CallAWSServiceOperation(IAmazonNetworkSecurityManager client, Amazon.NetworkSecurityManager.Model.CreateScopeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Security Manager Customer API", "CreateScope");
            try
            {
                return client.CreateScopeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? IsPublished { get; set; }
            public List<System.String> ScopeConfiguration_AccountFilter_Exclude_AccountId { get; set; }
            public List<System.String> ScopeConfiguration_AccountFilter_Exclude_OrganizationalUnit { get; set; }
            public List<System.String> ScopeConfiguration_AccountFilter_Include_AccountId { get; set; }
            public List<System.String> ScopeConfiguration_AccountFilter_Include_OrganizationalUnit { get; set; }
            public Amazon.NetworkSecurityManager.Model.Unit ScopeConfiguration_AccountFilter_IncludeAll { get; set; }
            public Dictionary<System.String, Amazon.NetworkSecurityManager.Model.ResourceScope> ScopeConfiguration_ResourceScope { get; set; }
            public System.String ScopeDescription { get; set; }
            public System.String ScopeName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NetworkSecurityManager.Model.CreateScopeResponse, NewNSMScopeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
