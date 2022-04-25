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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Requests authorization to create or delete a peer connection between the VPC for your
    /// Amazon GameLift fleet and a virtual private cloud (VPC) in your Amazon Web Services
    /// account. VPC peering enables the game servers on your fleet to communicate directly
    /// with other Amazon Web Services resources. Once you've received authorization, call
    /// <a>CreateVpcPeeringConnection</a> to establish the peering connection. For more information,
    /// see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/vpc-peering.html">VPC
    /// Peering with Amazon GameLift Fleets</a>.
    /// 
    ///  
    /// <para>
    /// You can peer with VPCs that are owned by any Amazon Web Services account you have
    /// access to, including the account that you use to manage your Amazon GameLift fleets.
    /// You cannot peer with VPCs that are in different Regions.
    /// </para><para>
    /// To request authorization to create a connection, call this operation from the Amazon
    /// Web Services account with the VPC that you want to peer to your Amazon GameLift fleet.
    /// For example, to enable your game servers to retrieve data from a DynamoDB table, use
    /// the account that manages that DynamoDB resource. Identify the following values: (1)
    /// The ID of the VPC that you want to peer with, and (2) the ID of the Amazon Web Services
    /// account that you use to manage Amazon GameLift. If successful, VPC peering is authorized
    /// for the specified VPC. 
    /// </para><para>
    /// To request authorization to delete a connection, call this operation from the Amazon
    /// Web Services account with the VPC that is peered with your Amazon GameLift fleet.
    /// Identify the following values: (1) VPC ID that you want to delete the peering connection
    /// for, and (2) ID of the Amazon Web Services account that you use to manage Amazon GameLift.
    /// 
    /// </para><para>
    /// The authorization remains valid for 24 hours unless it is canceled by a call to <a>DeleteVpcPeeringAuthorization</a>.
    /// You must create or delete the peering connection while the authorization is valid.
    /// 
    /// </para><para><b>Related actions</b></para><para><a>CreateVpcPeeringAuthorization</a> | <a>DescribeVpcPeeringAuthorizations</a> |
    /// <a>DeleteVpcPeeringAuthorization</a> | <a>CreateVpcPeeringConnection</a> | <a>DescribeVpcPeeringConnections</a>
    /// | <a>DeleteVpcPeeringConnection</a> | <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("New", "GMLVpcPeeringAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.VpcPeeringAuthorization")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateVpcPeeringAuthorization API operation.", Operation = new[] {"CreateVpcPeeringAuthorization"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.VpcPeeringAuthorization or Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse",
        "This cmdlet returns an Amazon.GameLift.Model.VpcPeeringAuthorization object.",
        "The service call response (type Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLVpcPeeringAuthorizationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter GameLiftAwsAccountId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Amazon Web Services account that you use to manage your
        /// GameLift fleet. You can find your Account ID in the Amazon Web Services Management
        /// Console under account settings.</para>
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
        public System.String GameLiftAwsAccountId { get; set; }
        #endregion
        
        #region Parameter PeerVpcId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a VPC with resources to be accessed by your GameLift fleet.
        /// The VPC must be in the same Region as your fleet. To look up a VPC ID, use the <a href="https://console.aws.amazon.com/vpc/">VPC Dashboard</a> in the Amazon Web Services
        /// Management Console. Learn more about VPC peering in <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/vpc-peering.html">VPC
        /// Peering with GameLift Fleets</a>.</para>
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
        public System.String PeerVpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcPeeringAuthorization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcPeeringAuthorization";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PeerVpcId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PeerVpcId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PeerVpcId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PeerVpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLVpcPeeringAuthorization (CreateVpcPeeringAuthorization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse, NewGMLVpcPeeringAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PeerVpcId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GameLiftAwsAccountId = this.GameLiftAwsAccountId;
            #if MODULAR
            if (this.GameLiftAwsAccountId == null && ParameterWasBound(nameof(this.GameLiftAwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter GameLiftAwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerVpcId = this.PeerVpcId;
            #if MODULAR
            if (this.PeerVpcId == null && ParameterWasBound(nameof(this.PeerVpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerVpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
        
        private Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateVpcPeeringAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateVpcPeeringAuthorization");
            try
            {
                #if DESKTOP
                return client.CreateVpcPeeringAuthorization(request);
                #elif CORECLR
                return client.CreateVpcPeeringAuthorizationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.GameLift.Model.CreateVpcPeeringAuthorizationResponse, NewGMLVpcPeeringAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcPeeringAuthorization;
        }
        
    }
}
