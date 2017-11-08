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
    /// Requests authorization to create or delete a peer connection between the VPC for your
    /// Amazon GameLift fleet and a virtual private cloud (VPC) in your AWS account. VPC peering
    /// enables the game servers on your fleet to communicate directly with other AWS resources.
    /// Once you've received authorization, call <a>CreateVpcPeeringConnection</a> to establish
    /// the peering connection. For more information, see <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/vpc-peering.html">VPC
    /// Peering with Amazon GameLift Fleets</a>.
    /// 
    ///  
    /// <para>
    /// You can peer with VPCs that are owned by any AWS account you have access to, including
    /// the account that you use to manage your Amazon GameLift fleets. You cannot peer with
    /// VPCs that are in different regions.
    /// </para><para>
    /// To request authorization to create a connection, call this operation from the AWS
    /// account with the VPC that you want to peer to your Amazon GameLift fleet. For example,
    /// to enable your game servers to retrieve data from a DynamoDB table, use the account
    /// that manages that DynamoDB resource. Identify the following values: (1) The ID of
    /// the VPC that you want to peer with, and (2) the ID of the AWS account that you use
    /// to manage Amazon GameLift. If successful, VPC peering is authorized for the specified
    /// VPC. 
    /// </para><para>
    /// To request authorization to delete a connection, call this operation from the AWS
    /// account with the VPC that is peered with your Amazon GameLift fleet. Identify the
    /// following values: (1) VPC ID that you want to delete the peering connection for, and
    /// (2) ID of the AWS account that you use to manage Amazon GameLift. 
    /// </para><para>
    /// The authorization remains valid for 24 hours unless it is canceled by a call to <a>DeleteVpcPeeringAuthorization</a>.
    /// You must create or delete the peering connection while the authorization is valid.
    /// 
    /// </para><para>
    /// VPC peering connection operations include:
    /// </para><ul><li><para><a>CreateVpcPeeringAuthorization</a></para></li><li><para><a>DescribeVpcPeeringAuthorizations</a></para></li><li><para><a>DeleteVpcPeeringAuthorization</a></para></li><li><para><a>CreateVpcPeeringConnection</a></para></li><li><para><a>DescribeVpcPeeringConnections</a></para></li><li><para><a>DeleteVpcPeeringConnection</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLVpcPeeringAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.VpcPeeringAuthorization")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateVpcPeeringAuthorization API operation.", Operation = new[] {"CreateVpcPeeringAuthorization"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.VpcPeeringAuthorization",
        "This cmdlet returns a VpcPeeringAuthorization object.",
        "The service call response (type Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLVpcPeeringAuthorizationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter GameLiftAwsAccountId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the AWS account that you use to manage your Amazon GameLift
        /// fleet. You can find your Account ID in the AWS Management Console under account settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GameLiftAwsAccountId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PeerVpcId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLVpcPeeringAuthorization (CreateVpcPeeringAuthorization)"))
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
            
            context.GameLiftAwsAccountId = this.GameLiftAwsAccountId;
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
            var request = new Amazon.GameLift.Model.CreateVpcPeeringAuthorizationRequest();
            
            if (cmdletContext.GameLiftAwsAccountId != null)
            {
                request.GameLiftAwsAccountId = cmdletContext.GameLiftAwsAccountId;
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
                object pipelineOutput = response.VpcPeeringAuthorization;
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
        
        private Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateVpcPeeringAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateVpcPeeringAuthorization");
            try
            {
                #if DESKTOP
                return client.CreateVpcPeeringAuthorization(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVpcPeeringAuthorizationAsync(request);
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
            public System.String GameLiftAwsAccountId { get; set; }
            public System.String PeerVpcId { get; set; }
        }
        
    }
}
