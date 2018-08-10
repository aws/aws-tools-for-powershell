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
    /// Requests a VPC peering connection between two VPCs: a requester VPC that you own and
    /// an accepter VPC with which to create the connection. The accepter VPC can belong to
    /// another AWS account and can be in a different Region to the requester VPC. The requester
    /// VPC and accepter VPC cannot have overlapping CIDR blocks.
    /// 
    ///  <note><para>
    /// Limitations and rules apply to a VPC peering connection. For more information, see
    /// the <a href="http://docs.aws.amazon.com/AmazonVPC/latest/PeeringGuide/vpc-peering-basics.html#vpc-peering-limitations">limitations</a>
    /// section in the <i>VPC Peering Guide</i>.
    /// </para></note><para>
    /// The owner of the accepter VPC must accept the peering request to activate the peering
    /// connection. The VPC peering connection request expires after 7 days, after which it
    /// cannot be accepted or rejected.
    /// </para><para>
    /// If you create a VPC peering connection request between VPCs with overlapping CIDR
    /// blocks, the VPC peering connection has a status of <code>failed</code>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpcPeeringConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpcPeeringConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateVpcPeeringConnection API operation.", Operation = new[] {"CreateVpcPeeringConnection"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcPeeringConnection",
        "This cmdlet returns a VpcPeeringConnection object.",
        "The service call response (type Amazon.EC2.Model.CreateVpcPeeringConnectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VpcPeeringConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter PeerOwnerId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID of the owner of the accepter VPC.</para><para>Default: Your AWS account ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String PeerOwnerId { get; set; }
        #endregion
        
        #region Parameter PeerRegion
        /// <summary>
        /// <para>
        /// <para>The region code for the accepter VPC, if the accepter VPC is located in a region other
        /// than the region in which you make the request.</para><para>Default: The region in which you make the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PeerRegion { get; set; }
        #endregion
        
        #region Parameter PeerVpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC with which you are creating the VPC peering connection. You must
        /// specify this parameter in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String PeerVpcId { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the requester VPC. You must specify this parameter in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VpcId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VpcId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpcPeeringConnection (CreateVpcPeeringConnection)"))
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
            
            context.PeerOwnerId = this.PeerOwnerId;
            context.PeerRegion = this.PeerRegion;
            context.PeerVpcId = this.PeerVpcId;
            context.VpcId = this.VpcId;
            
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
            var request = new Amazon.EC2.Model.CreateVpcPeeringConnectionRequest();
            
            if (cmdletContext.PeerOwnerId != null)
            {
                request.PeerOwnerId = cmdletContext.PeerOwnerId;
            }
            if (cmdletContext.PeerRegion != null)
            {
                request.PeerRegion = cmdletContext.PeerRegion;
            }
            if (cmdletContext.PeerVpcId != null)
            {
                request.PeerVpcId = cmdletContext.PeerVpcId;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpcPeeringConnection;
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
        
        private Amazon.EC2.Model.CreateVpcPeeringConnectionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcPeeringConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateVpcPeeringConnection");
            try
            {
                #if DESKTOP
                return client.CreateVpcPeeringConnection(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVpcPeeringConnectionAsync(request);
                return task.Result;
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
            public System.String PeerOwnerId { get; set; }
            public System.String PeerRegion { get; set; }
            public System.String PeerVpcId { get; set; }
            public System.String VpcId { get; set; }
        }
        
    }
}
