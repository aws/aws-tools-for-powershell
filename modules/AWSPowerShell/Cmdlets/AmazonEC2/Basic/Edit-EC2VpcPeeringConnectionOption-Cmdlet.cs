/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// You can do the following:
    /// 
    ///  <ul><li><para>
    /// Enable/disable communication over the peering connection between an EC2-Classic instance
    /// that's linked to your VPC (using ClassicLink) and instances in the peer VPC.
    /// </para></li><li><para>
    /// Enable/disable communication over the peering connection between instances in your
    /// VPC and an EC2-Classic instance that's linked to the peer VPC.
    /// </para></li><li><para>
    /// Enable/disable the ability to resolve public DNS hostnames to private IP addresses
    /// when queried from instances in the peer VPC.
    /// </para></li></ul><para>
    /// If the peered VPCs are in the same AWS account, you can enable DNS resolution for
    /// queries from the local VPC. This ensures that queries from the local VPC resolve to
    /// private IP addresses in the peer VPC. This option is not available if the peered VPCs
    /// are in different AWS accounts or different regions. For peered VPCs in different AWS
    /// accounts, each AWS account owner must initiate a separate request to modify the peering
    /// connection options. For inter-region peering connections, you must use the region
    /// for the requester VPC to modify the requester VPC peering options and the region for
    /// the accepter VPC to modify the accepter VPC peering options. To verify which VPCs
    /// are the accepter and the requester for a VPC peering connection, use the <a>DescribeVpcPeeringConnections</a>
    /// command.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2VpcPeeringConnectionOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyVpcPeeringConnectionOptions API operation.", Operation = new[] {"ModifyVpcPeeringConnectionOptions"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse",
        "This cmdlet returns a Amazon.EC2.Model.ModifyVpcPeeringConnectionOptionsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpcPeeringConnectionOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc
        /// <summary>
        /// <para>
        /// <para>If true, enables a local VPC to resolve public DNS hostnames to private IP addresses
        /// when queried from instances in the peer VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc { get; set; }
        #endregion
        
        #region Parameter RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc
        /// <summary>
        /// <para>
        /// <para>If true, enables a local VPC to resolve public DNS hostnames to private IP addresses
        /// when queried from instances in the peer VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc { get; set; }
        #endregion
        
        #region Parameter AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc
        /// <summary>
        /// <para>
        /// <para>If true, enables outbound communication from an EC2-Classic instance that's linked
        /// to a local VPC using ClassicLink to instances in a peer VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc { get; set; }
        #endregion
        
        #region Parameter RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc
        /// <summary>
        /// <para>
        /// <para>If true, enables outbound communication from an EC2-Classic instance that's linked
        /// to a local VPC using ClassicLink to instances in a peer VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc { get; set; }
        #endregion
        
        #region Parameter AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink
        /// <summary>
        /// <para>
        /// <para>If true, enables outbound communication from instances in a local VPC to an EC2-Classic
        /// instance that's linked to a peer VPC using ClassicLink.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink { get; set; }
        #endregion
        
        #region Parameter RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink
        /// <summary>
        /// <para>
        /// <para>If true, enables outbound communication from instances in a local VPC to an EC2-Classic
        /// instance that's linked to a peer VPC using ClassicLink.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink { get; set; }
        #endregion
        
        #region Parameter VpcPeeringConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC peering connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String VpcPeeringConnectionId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VpcPeeringConnectionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcPeeringConnectionOption (ModifyVpcPeeringConnectionOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc"))
                context.AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = this.AccepterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc;
            if (ParameterWasBound("AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc"))
                context.AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = this.AccepterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc;
            if (ParameterWasBound("AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink"))
                context.AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = this.AccepterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink;
            if (ParameterWasBound("RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc"))
                context.RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc = this.RequesterPeeringConnectionOptions_AllowDnsResolutionFromRemoteVpc;
            if (ParameterWasBound("RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc"))
                context.RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc = this.RequesterPeeringConnectionOptions_AllowEgressFromLocalClassicLinkToRemoteVpc;
            if (ParameterWasBound("RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink"))
                context.RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink = this.RequesterPeeringConnectionOptions_AllowEgressFromLocalVpcToRemoteClassicLink;
            context.VpcPeeringConnectionId = this.VpcPeeringConnectionId;
            
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
            bool requestAccepterPeeringConnectionOptionsIsNull = true;
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
            bool requestRequesterPeeringConnectionOptionsIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyVpcPeeringConnectionOptions");
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
        }
        
    }
}
