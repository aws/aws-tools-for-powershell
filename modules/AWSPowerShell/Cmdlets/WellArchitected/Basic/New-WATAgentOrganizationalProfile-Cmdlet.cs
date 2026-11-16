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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Creates an Organizational Profile for use with AWS Organizations integration. Organizational
    /// Profiles are scoped to an AWS Organization and do not require an execution role or
    /// aggregation configuration. The organization is inferred from the caller's identity.
    /// </summary>
    [Cmdlet("New", "WATAgentOrganizationalProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool CreateAgentOrganizationalProfile API operation.", Operation = new[] {"CreateAgentOrganizationalProfile"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse object containing multiple properties."
    )]
    public partial class NewWATAgentOrganizationalProfileCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OrganizationalAggregationConfiguration_Account
        /// <summary>
        /// <para>
        /// <para>A list of individual account entries that define additional accounts to include. Each
        /// entry specifies an account ID and the regions to monitor within it.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationalAggregationConfiguration_Accounts")]
        public Amazon.WellArchitected.Model.OrganizationalAccountEntry[] OrganizationalAggregationConfiguration_Account { get; set; }
        #endregion
        
        #region Parameter BusinessOverview
        /// <summary>
        /// <para>
        /// <para>The business overview for this organizational profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BusinessOverview { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Indicates whether deletion protection is enabled for the organizational profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the organizational profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the organizational profile shown to users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The system name of the organizational profile.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OrganizationalAggregationConfiguration_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>A list of organizational unit or root entries that define the organizational scope.
        /// Each entry specifies an OU or root ID and the regions to monitor within it.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationalAggregationConfiguration_OrganizationalUnits")]
        public Amazon.WellArchitected.Model.OrganizationalUnitEntry[] OrganizationalAggregationConfiguration_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter Pillar
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Well-Architected Framework pillars to associate with this
        /// organizational profile.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
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
        [Alias("Pillars")]
        public System.String[] Pillar { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the organizational profile.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WellArchitected.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WATAgentOrganizationalProfile (CreateAgentOrganizationalProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse, NewWATAgentOrganizationalProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BusinessOverview = this.BusinessOverview;
            context.ClientToken = this.ClientToken;
            context.DeletionProtection = this.DeletionProtection;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OrganizationalAggregationConfiguration_Account != null)
            {
                context.OrganizationalAggregationConfiguration_Account = new List<Amazon.WellArchitected.Model.OrganizationalAccountEntry>(this.OrganizationalAggregationConfiguration_Account);
            }
            if (this.OrganizationalAggregationConfiguration_OrganizationalUnit != null)
            {
                context.OrganizationalAggregationConfiguration_OrganizationalUnit = new List<Amazon.WellArchitected.Model.OrganizationalUnitEntry>(this.OrganizationalAggregationConfiguration_OrganizationalUnit);
            }
            if (this.Pillar != null)
            {
                context.Pillar = new List<System.String>(this.Pillar);
            }
            #if MODULAR
            if (this.Pillar == null && ParameterWasBound(nameof(this.Pillar)))
            {
                WriteWarning("You are passing $null as a value for parameter Pillar which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WellArchitected.Model.Tag>(this.Tag);
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
            var request = new Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileRequest();
            
            if (cmdletContext.BusinessOverview != null)
            {
                request.BusinessOverview = cmdletContext.BusinessOverview;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OrganizationalAggregationConfiguration
            var requestOrganizationalAggregationConfigurationIsNull = true;
            request.OrganizationalAggregationConfiguration = new Amazon.WellArchitected.Model.OrganizationalAggregationConfiguration();
            List<Amazon.WellArchitected.Model.OrganizationalAccountEntry> requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_Account = null;
            if (cmdletContext.OrganizationalAggregationConfiguration_Account != null)
            {
                requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_Account = cmdletContext.OrganizationalAggregationConfiguration_Account;
            }
            if (requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_Account != null)
            {
                request.OrganizationalAggregationConfiguration.Accounts = requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_Account;
                requestOrganizationalAggregationConfigurationIsNull = false;
            }
            List<Amazon.WellArchitected.Model.OrganizationalUnitEntry> requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_OrganizationalUnit = null;
            if (cmdletContext.OrganizationalAggregationConfiguration_OrganizationalUnit != null)
            {
                requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_OrganizationalUnit = cmdletContext.OrganizationalAggregationConfiguration_OrganizationalUnit;
            }
            if (requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_OrganizationalUnit != null)
            {
                request.OrganizationalAggregationConfiguration.OrganizationalUnits = requestOrganizationalAggregationConfiguration_organizationalAggregationConfiguration_OrganizationalUnit;
                requestOrganizationalAggregationConfigurationIsNull = false;
            }
             // determine if request.OrganizationalAggregationConfiguration should be set to null
            if (requestOrganizationalAggregationConfigurationIsNull)
            {
                request.OrganizationalAggregationConfiguration = null;
            }
            if (cmdletContext.Pillar != null)
            {
                request.Pillars = cmdletContext.Pillar;
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
        
        private Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "CreateAgentOrganizationalProfile");
            try
            {
                return client.CreateAgentOrganizationalProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BusinessOverview { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.WellArchitected.Model.OrganizationalAccountEntry> OrganizationalAggregationConfiguration_Account { get; set; }
            public List<Amazon.WellArchitected.Model.OrganizationalUnitEntry> OrganizationalAggregationConfiguration_OrganizationalUnit { get; set; }
            public List<System.String> Pillar { get; set; }
            public List<Amazon.WellArchitected.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WellArchitected.Model.CreateAgentOrganizationalProfileResponse, NewWATAgentOrganizationalProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
