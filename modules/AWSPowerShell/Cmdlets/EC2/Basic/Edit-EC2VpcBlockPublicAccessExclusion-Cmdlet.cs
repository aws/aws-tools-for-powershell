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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modify VPC Block Public Access (BPA) exclusions. A VPC BPA exclusion is a mode that
    /// can be applied to a single VPC or subnet that exempts it from the account’s BPA mode
    /// and will allow bidirectional or egress-only access. You can create BPA exclusions
    /// for VPCs and subnets even when BPA is not enabled on the account to ensure that there
    /// is no traffic disruption to the exclusions when VPC BPA is turned on.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcBlockPublicAccessExclusion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpcBlockPublicAccessExclusion")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcBlockPublicAccessExclusion API operation.", Operation = new[] {"ModifyVpcBlockPublicAccessExclusion"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcBlockPublicAccessExclusion or Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpcBlockPublicAccessExclusion object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2VpcBlockPublicAccessExclusionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExclusionId
        /// <summary>
        /// <para>
        /// <para>The ID of an exclusion.</para>
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
        public System.String ExclusionId { get; set; }
        #endregion
        
        #region Parameter InternetGatewayExclusionMode
        /// <summary>
        /// <para>
        /// <para>The exclusion mode for internet gateway traffic.</para><ul><li><para><c>allow-bidirectional</c>: Allow all internet traffic to and from the excluded VPCs
        /// and subnets.</para></li><li><para><c>allow-egress</c>: Allow outbound internet traffic from the excluded VPCs and subnets.
        /// Block inbound internet traffic to the excluded VPCs and subnets. Only applies when
        /// VPC Block Public Access is set to Bidirectional.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.InternetGatewayExclusionMode")]
        public Amazon.EC2.InternetGatewayExclusionMode InternetGatewayExclusionMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcBlockPublicAccessExclusion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcBlockPublicAccessExclusion";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExclusionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExclusionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExclusionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExclusionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcBlockPublicAccessExclusion (ModifyVpcBlockPublicAccessExclusion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse, EditEC2VpcBlockPublicAccessExclusionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExclusionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExclusionId = this.ExclusionId;
            #if MODULAR
            if (this.ExclusionId == null && ParameterWasBound(nameof(this.ExclusionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExclusionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InternetGatewayExclusionMode = this.InternetGatewayExclusionMode;
            #if MODULAR
            if (this.InternetGatewayExclusionMode == null && ParameterWasBound(nameof(this.InternetGatewayExclusionMode)))
            {
                WriteWarning("You are passing $null as a value for parameter InternetGatewayExclusionMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionRequest();
            
            if (cmdletContext.ExclusionId != null)
            {
                request.ExclusionId = cmdletContext.ExclusionId;
            }
            if (cmdletContext.InternetGatewayExclusionMode != null)
            {
                request.InternetGatewayExclusionMode = cmdletContext.InternetGatewayExclusionMode;
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
        
        private Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcBlockPublicAccessExclusion");
            try
            {
                #if DESKTOP
                return client.ModifyVpcBlockPublicAccessExclusion(request);
                #elif CORECLR
                return client.ModifyVpcBlockPublicAccessExclusionAsync(request).GetAwaiter().GetResult();
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
            public System.String ExclusionId { get; set; }
            public Amazon.EC2.InternetGatewayExclusionMode InternetGatewayExclusionMode { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcBlockPublicAccessExclusionResponse, EditEC2VpcBlockPublicAccessExclusionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcBlockPublicAccessExclusion;
        }
        
    }
}
