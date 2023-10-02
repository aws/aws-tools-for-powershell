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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the VPC peering connection options on one side of a VPC peering connection.
    /// 
    ///  
    /// <para>
    /// If the peered VPCs are in the same Amazon Web Services account, you can enable DNS
    /// resolution for queries from the local VPC. This ensures that queries from the local
    /// VPC resolve to private IP addresses in the peer VPC. This option is not available
    /// if the peered VPCs are in different Amazon Web Services accounts or different Regions.
    /// For peered VPCs in different Amazon Web Services accounts, each Amazon Web Services
    /// account owner must initiate a separate request to modify the peering connection options.
    /// For inter-region peering connections, you must use the Region for the requester VPC
    /// to modify the requester VPC peering options and the Region for the accepter VPC to
    /// modify the accepter VPC peering options. To verify which VPCs are the accepter and
    /// the requester for a VPC peering connection, use the <a>DescribeVpcPeeringConnections</a>
    /// command.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2VpcPeeringConnectionOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcPeeringConnectionOptions API operation.", Operation = new[] {"ModifyVpcPeeringConnectionOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpcPeeringConnectionOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc
        /// <summary>
        /// <para>
        /// <para>If true, enables a local VPC to resolve public DNS hostnames to private IP addresses
        /// when queried from instances in the peer VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc { get; set; }
        #endregion
        
        #region Parameter RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc
        /// <summary>
        /// <para>
        /// <para>If true, enables a local VPC to resolve public DNS hostnames to private IP addresses
        /// when queried from instances in the peer VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc { get; set; }
        #endregion
        
        #region Parameter AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc { get; set; }
        #endregion
        
        #region Parameter RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc { get; set; }
        #endregion
        
        #region Parameter AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink { get; set; }
        #endregion
        
        #region Parameter RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink { get; set; }
        #endregion
        
        #region Parameter VpcPeeringConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC peering connection.</para>
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
        public System.String VpcPeeringConnectionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcPeeringConnectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcPeeringConnectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcPeeringConnectionId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcPeeringConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcPeeringConnectionOption (ModifyVpcPeeringConnectionOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse, EditEC2VpcPeeringConnectionOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcPeeringConnectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = this.AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc;
            context.AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = this.AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc;
            context.AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = this.AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink;
            context.RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = this.RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc;
            context.RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = this.RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc;
            context.RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = this.RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink;
            context.VpcPeeringConnectionId = this.VpcPeeringConnectionId;
            #if MODULAR
            if (this.VpcPeeringConnectionId == null && ParameterWasBound(nameof(this.VpcPeeringConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcPeeringConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsRequest();
            
            
             // populate AccepterPeeringConnectionOptions
            var requestAccepterPeeringConnectionOptionsIsNull = true;
            request.AccepterPeeringConnectionOptions = new Amazon.EC2.Model.PeeringConnectionOptionsRequest();
            System.Boolean? requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = null;
            if (cmdletContext.AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc != null)
            {
                requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = cmdletContext.AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc.Value;
            }
            if (requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc != null)
            {
                request.AccepterPeeringConnectionOptions.AllowDnsResolutionFromRemoteVpc = requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc.Value;
                requestAccepterPeeringConnectionOptionsIsNull = false;
            }
            System.Boolean? requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = null;
            if (cmdletContext.AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc != null)
            {
                requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = cmdletContext.AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc.Value;
            }
            if (requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc != null)
            {
                request.AccepterPeeringConnectionOptions.AllowEgressFromLocalClassicLinkToRemoteVpc = requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc.Value;
                requestAccepterPeeringConnectionOptionsIsNull = false;
            }
            System.Boolean? requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = null;
            if (cmdletContext.AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink != null)
            {
                requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = cmdletContext.AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink.Value;
            }
            if (requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink != null)
            {
                request.AccepterPeeringConnectionOptions.AllowEgressFromLocalVpcToRemoteClassicLink = requestAccepterPeeringConnectionOptions_accepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink.Value;
                requestAccepterPeeringConnectionOptionsIsNull = false;
            }
             // determine if request.AccepterPeeringConnectionOptions should be set to null
            if (requestAccepterPeeringConnectionOptionsIsNull)
            {
                request.AccepterPeeringConnectionOptions = null;
            }
            
             // populate RequesterPeeringConnectionOptions
            var requestRequesterPeeringConnectionOptionsIsNull = true;
            request.RequesterPeeringConnectionOptions = new Amazon.EC2.Model.PeeringConnectionOptionsRequest();
            System.Boolean? requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = null;
            if (cmdletContext.RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc != null)
            {
                requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = cmdletContext.RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc.Value;
            }
            if (requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc != null)
            {
                request.RequesterPeeringConnectionOptions.AllowDnsResolutionFromRemoteVpc = requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc.Value;
                requestRequesterPeeringConnectionOptionsIsNull = false;
            }
            System.Boolean? requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = null;
            if (cmdletContext.RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc != null)
            {
                requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = cmdletContext.RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc.Value;
            }
            if (requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc != null)
            {
                request.RequesterPeeringConnectionOptions.AllowEgressFromLocalClassicLinkToRemoteVpc = requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc.Value;
                requestRequesterPeeringConnectionOptionsIsNull = false;
            }
            System.Boolean? requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = null;
            if (cmdletContext.RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink != null)
            {
                requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = cmdletContext.RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink.Value;
            }
            if (requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink != null)
            {
                request.RequesterPeeringConnectionOptions.AllowEgressFromLocalVpcToRemoteClassicLink = requestRequesterPeeringConnectionOptions_requesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink.Value;
                requestRequesterPeeringConnectionOptionsIsNull = false;
            }
             // determine if request.RequesterPeeringConnectionOptions should be set to null
            if (requestRequesterPeeringConnectionOptionsIsNull)
            {
                request.RequesterPeeringConnectionOptions = null;
            }
            if (cmdletContext.VpcPeeringConnectionId != null)
            {
                request.VpcPeeringConnectionId = cmdletContext.VpcPeeringConnectionId;
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
        
        private Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcPeeringConnectionOptions");
            try
            {
                #if DESKTOP
                return client.ModifyVpcPeeringConnectionOptions(request);
                #elif CORECLR
                return client.ModifyVpcPeeringConnectionOptionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc { get; set; }
            public System.Boolean? AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc { get; set; }
            public System.Boolean? AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink { get; set; }
            public System.Boolean? RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc { get; set; }
            public System.Boolean? RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc { get; set; }
            public System.Boolean? RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink { get; set; }
            public System.String VpcPeeringConnectionId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse, EditEC2VpcPeeringConnectionOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
