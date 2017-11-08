/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Establishes a VPC peering connection between a virtual private cloud (VPC) in an AWS
    /// account with the VPC for your Amazon GameLift fleet. VPC peering enables the game
    /// servers on your fleet to communicate directly with other AWS resources. You can peer
    /// with VPCs in any AWS account that you have access to, including the account that you
    /// use to manage your Amazon GameLift fleets. You cannot peer with VPCs that are in different
    /// regions. For more information, see <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/vpc-peering.html">VPC
    /// Peering with Amazon GameLift Fleets</a>.
    /// 
    ///  
    /// <para>
    /// Before calling this operation to establish the peering connection, you first need
    /// to call <a>CreateVpcPeeringAuthorization</a> and identify the VPC you want to peer
    /// with. Once the authorization for the specified VPC is issued, you have 24 hours to
    /// establish the connection. These two operations handle all tasks necessary to peer
    /// the two VPCs, including acceptance, updating routing tables, etc. 
    /// </para><para>
    /// To establish the connection, call this operation from the AWS account that is used
    /// to manage the Amazon GameLift fleets. Identify the following values: (1) The ID of
    /// the fleet you want to be enable a VPC peering connection for; (2) The AWS account
    /// with the VPC that you want to peer with; and (3) The ID of the VPC you want to peer
    /// with. This operation is asynchronous. If successful, a <a>VpcPeeringConnection</a>
    /// request is created. You can use continuous polling to track the request's status using
    /// <a>DescribeVpcPeeringConnections</a>, or by monitoring fleet events for success or
    /// failure using <a>DescribeFleetEvents</a>. 
    /// </para><para>
    /// VPC peering connection operations include:
    /// </para><ul><li><para><a>CreateVpcPeeringAuthorization</a></para></li><li><para><a>DescribeVpcPeeringAuthorizations</a></para></li><li><para><a>DeleteVpcPeeringAuthorization</a></para></li><li><para><a>CreateVpcPeeringConnection</a></para></li><li><para><a>DescribeVpcPeeringConnections</a></para></li><li><para><a>DeleteVpcPeeringConnection</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLVpcPeeringConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateVpcPeeringConnection API operation.", Operation = new[] {"CreateVpcPeeringConnection"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the FleetId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.GameLift.Model.CreateVpcPeeringConnectionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLVpcPeeringConnectionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet. This tells Amazon GameLift which GameLift VPC to peer
        /// with. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter PeerVpcAwsAccountId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the AWS account with the VPC that you want to peer your Amazon
        /// GameLift fleet with. You can find your Account ID in the AWS Management Console under
        /// account settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PeerVpcAwsAccountId { get; set; }
        #endregion
        
        #region Parameter PeerVpcId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a VPC with resources to be accessed by your Amazon GameLift
        /// fleet. The VPC must be in the same region where your fleet is deployed. To get VPC
        /// information, including IDs, use the Virtual Private Cloud service tools, including
        /// the VPC Dashboard in the AWS Management Console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PeerVpcId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the FleetId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FleetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLVpcPeeringConnection (CreateVpcPeeringConnection)"))
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
            
            context.FleetId = this.FleetId;
            context.PeerVpcAwsAccountId = this.PeerVpcAwsAccountId;
            context.PeerVpcId = this.PeerVpcId;
            
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
            var request = new Amazon.GameLift.Model.CreateVpcPeeringConnectionRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.PeerVpcAwsAccountId != null)
            {
                request.PeerVpcAwsAccountId = cmdletContext.PeerVpcAwsAccountId;
            }
            if (cmdletContext.PeerVpcId != null)
            {
                request.PeerVpcId = cmdletContext.PeerVpcId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.FleetId;
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
        
        private Amazon.GameLift.Model.CreateVpcPeeringConnectionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateVpcPeeringConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateVpcPeeringConnection");
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
            public System.String FleetId { get; set; }
            public System.String PeerVpcAwsAccountId { get; set; }
            public System.String PeerVpcId { get; set; }
        }
        
    }
}
