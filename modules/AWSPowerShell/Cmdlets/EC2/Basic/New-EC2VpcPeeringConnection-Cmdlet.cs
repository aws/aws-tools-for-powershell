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
    /// Requests a VPC peering connection between two VPCs: a requester VPC that you own and
    /// an accepter VPC with which to create the connection. The accepter VPC can belong to
    /// another Amazon Web Services account and can be in a different Region to the requester
    /// VPC. The requester VPC and accepter VPC cannot have overlapping CIDR blocks.
    /// 
    ///  <note><para>
    /// Limitations and rules apply to a VPC peering connection. For more information, see
    /// the <a href="https://docs.aws.amazon.com/vpc/latest/peering/vpc-peering-basics.html#vpc-peering-limitations">limitations</a>
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
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVpcPeeringConnection API operation.", Operation = new[] {"CreateVpcPeeringConnection"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVpcPeeringConnectionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcPeeringConnection or Amazon.EC2.Model.CreateVpcPeeringConnectionResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpcPeeringConnection object.",
        "The service call response (type Amazon.EC2.Model.CreateVpcPeeringConnectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VpcPeeringConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter PeerOwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the owner of the accepter VPC.</para><para>Default: Your Amazon Web Services account ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String PeerOwnerId { get; set; }
        #endregion
        
        #region Parameter PeerRegion
        /// <summary>
        /// <para>
        /// <para>The Region code for the accepter VPC, if the accepter VPC is located in a Region other
        /// than the Region in which you make the request.</para><para>Default: The Region in which you make the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerRegion { get; set; }
        #endregion
        
        #region Parameter PeerVpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC with which you are creating the VPC peering connection. You must
        /// specify this parameter in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String PeerVpcId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the peering connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcPeeringConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVpcPeeringConnectionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVpcPeeringConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcPeeringConnection";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpcPeeringConnection (CreateVpcPeeringConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVpcPeeringConnectionResponse, NewEC2VpcPeeringConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PeerOwnerId = this.PeerOwnerId;
            context.PeerRegion = this.PeerRegion;
            context.PeerVpcId = this.PeerVpcId;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
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
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.EC2.Model.CreateVpcPeeringConnectionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcPeeringConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVpcPeeringConnection");
            try
            {
                #if DESKTOP
                return client.CreateVpcPeeringConnection(request);
                #elif CORECLR
                return client.CreateVpcPeeringConnectionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVpcPeeringConnectionResponse, NewEC2VpcPeeringConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcPeeringConnection;
        }
        
    }
}
