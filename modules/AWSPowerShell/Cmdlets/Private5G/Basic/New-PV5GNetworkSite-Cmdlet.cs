/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Private5G;
using Amazon.Private5G.Model;

namespace Amazon.PowerShell.Cmdlets.PV5G
{
    /// <summary>
    /// Creates a network site.
    /// </summary>
    [Cmdlet("New", "PV5GNetworkSite", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Private5G.Model.NetworkSite")]
    [AWSCmdlet("Calls the AWS Private 5G CreateNetworkSite API operation.", Operation = new[] {"CreateNetworkSite"}, SelectReturnType = typeof(Amazon.Private5G.Model.CreateNetworkSiteResponse))]
    [AWSCmdletOutput("Amazon.Private5G.Model.NetworkSite or Amazon.Private5G.Model.CreateNetworkSiteResponse",
        "This cmdlet returns an Amazon.Private5G.Model.NetworkSite object.",
        "The service call response (type Amazon.Private5G.Model.CreateNetworkSiteResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPV5GNetworkSiteCmdlet : AmazonPrivate5GClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone that is the parent of this site. You can't change the Availability
        /// Zone after you create the site.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone that is the parent of this site. You can't change
        /// the Availability Zone after you create the site.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the site.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter NetworkArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network.</para>
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
        public System.String NetworkArn { get; set; }
        #endregion
        
        #region Parameter NetworkSiteName
        /// <summary>
        /// <para>
        /// <para>The name of the site. You can't change the name after you create the site.</para>
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
        public System.String NetworkSiteName { get; set; }
        #endregion
        
        #region Parameter PendingPlan_Option
        /// <summary>
        /// <para>
        /// <para>The options of the plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PendingPlan_Options")]
        public Amazon.Private5G.Model.NameValuePair[] PendingPlan_Option { get; set; }
        #endregion
        
        #region Parameter PendingPlan_ResourceDefinition
        /// <summary>
        /// <para>
        /// <para>The resource definitions of the plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PendingPlan_ResourceDefinitions")]
        public Amazon.Private5G.Model.NetworkResourceDefinition[] PendingPlan_ResourceDefinition { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The tags to apply to the network site. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkSite'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Private5G.Model.CreateNetworkSiteResponse).
        /// Specifying the name of a property of type Amazon.Private5G.Model.CreateNetworkSiteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkSite";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkSiteName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PV5GNetworkSite (CreateNetworkSite)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Private5G.Model.CreateNetworkSiteResponse, NewPV5GNetworkSiteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.NetworkArn = this.NetworkArn;
            #if MODULAR
            if (this.NetworkArn == null && ParameterWasBound(nameof(this.NetworkArn)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkSiteName = this.NetworkSiteName;
            #if MODULAR
            if (this.NetworkSiteName == null && ParameterWasBound(nameof(this.NetworkSiteName)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkSiteName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PendingPlan_Option != null)
            {
                context.PendingPlan_Option = new List<Amazon.Private5G.Model.NameValuePair>(this.PendingPlan_Option);
            }
            if (this.PendingPlan_ResourceDefinition != null)
            {
                context.PendingPlan_ResourceDefinition = new List<Amazon.Private5G.Model.NetworkResourceDefinition>(this.PendingPlan_ResourceDefinition);
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
            var request = new Amazon.Private5G.Model.CreateNetworkSiteRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.NetworkArn != null)
            {
                request.NetworkArn = cmdletContext.NetworkArn;
            }
            if (cmdletContext.NetworkSiteName != null)
            {
                request.NetworkSiteName = cmdletContext.NetworkSiteName;
            }
            
             // populate PendingPlan
            var requestPendingPlanIsNull = true;
            request.PendingPlan = new Amazon.Private5G.Model.SitePlan();
            List<Amazon.Private5G.Model.NameValuePair> requestPendingPlan_pendingPlan_Option = null;
            if (cmdletContext.PendingPlan_Option != null)
            {
                requestPendingPlan_pendingPlan_Option = cmdletContext.PendingPlan_Option;
            }
            if (requestPendingPlan_pendingPlan_Option != null)
            {
                request.PendingPlan.Options = requestPendingPlan_pendingPlan_Option;
                requestPendingPlanIsNull = false;
            }
            List<Amazon.Private5G.Model.NetworkResourceDefinition> requestPendingPlan_pendingPlan_ResourceDefinition = null;
            if (cmdletContext.PendingPlan_ResourceDefinition != null)
            {
                requestPendingPlan_pendingPlan_ResourceDefinition = cmdletContext.PendingPlan_ResourceDefinition;
            }
            if (requestPendingPlan_pendingPlan_ResourceDefinition != null)
            {
                request.PendingPlan.ResourceDefinitions = requestPendingPlan_pendingPlan_ResourceDefinition;
                requestPendingPlanIsNull = false;
            }
             // determine if request.PendingPlan should be set to null
            if (requestPendingPlanIsNull)
            {
                request.PendingPlan = null;
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
        
        private Amazon.Private5G.Model.CreateNetworkSiteResponse CallAWSServiceOperation(IAmazonPrivate5G client, Amazon.Private5G.Model.CreateNetworkSiteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Private 5G", "CreateNetworkSite");
            try
            {
                #if DESKTOP
                return client.CreateNetworkSite(request);
                #elif CORECLR
                return client.CreateNetworkSiteAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String AvailabilityZone { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String NetworkArn { get; set; }
            public System.String NetworkSiteName { get; set; }
            public List<Amazon.Private5G.Model.NameValuePair> PendingPlan_Option { get; set; }
            public List<Amazon.Private5G.Model.NetworkResourceDefinition> PendingPlan_ResourceDefinition { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Private5G.Model.CreateNetworkSiteResponse, NewPV5GNetworkSiteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkSite;
        }
        
    }
}
