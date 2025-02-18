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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Move a BYOIPv4 CIDR to IPAM from a public IPv4 pool.
    /// 
    ///  
    /// <para>
    /// If you already have a BYOIPv4 CIDR with Amazon Web Services, you can move the CIDR
    /// to IPAM from a public IPv4 pool. You cannot move an IPv6 CIDR to IPAM. If you are
    /// bringing a new IP address to Amazon Web Services for the first time, complete the
    /// steps in <a href="https://docs.aws.amazon.com/vpc/latest/ipam/tutorials-byoip-ipam.html">Tutorial:
    /// BYOIP address CIDRs to IPAM</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Move", "EC2ByoipCidrToIpam", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ByoipCidr")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) MoveByoipCidrToIpam API operation.", Operation = new[] {"MoveByoipCidrToIpam"}, SelectReturnType = typeof(Amazon.EC2.Model.MoveByoipCidrToIpamResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ByoipCidr or Amazon.EC2.Model.MoveByoipCidrToIpamResponse",
        "This cmdlet returns an Amazon.EC2.Model.ByoipCidr object.",
        "The service call response (type Amazon.EC2.Model.MoveByoipCidrToIpamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class MoveEC2ByoipCidrToIpamCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The BYOIP CIDR.</para>
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
        public System.String Cidr { get; set; }
        #endregion
        
        #region Parameter IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The IPAM pool ID.</para>
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
        public System.String IpamPoolId { get; set; }
        #endregion
        
        #region Parameter IpamPoolOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the owner of the IPAM pool.</para>
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
        public System.String IpamPoolOwner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ByoipCidr'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.MoveByoipCidrToIpamResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.MoveByoipCidrToIpamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ByoipCidr";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Move-EC2ByoipCidrToIpam (MoveByoipCidrToIpam)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.MoveByoipCidrToIpamResponse, MoveEC2ByoipCidrToIpamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cidr = this.Cidr;
            #if MODULAR
            if (this.Cidr == null && ParameterWasBound(nameof(this.Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpamPoolId = this.IpamPoolId;
            #if MODULAR
            if (this.IpamPoolId == null && ParameterWasBound(nameof(this.IpamPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpamPoolOwner = this.IpamPoolOwner;
            #if MODULAR
            if (this.IpamPoolOwner == null && ParameterWasBound(nameof(this.IpamPoolOwner)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPoolOwner which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.MoveByoipCidrToIpamRequest();
            
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            if (cmdletContext.IpamPoolId != null)
            {
                request.IpamPoolId = cmdletContext.IpamPoolId;
            }
            if (cmdletContext.IpamPoolOwner != null)
            {
                request.IpamPoolOwner = cmdletContext.IpamPoolOwner;
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
        
        private Amazon.EC2.Model.MoveByoipCidrToIpamResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.MoveByoipCidrToIpamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "MoveByoipCidrToIpam");
            try
            {
                return client.MoveByoipCidrToIpamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Cidr { get; set; }
            public System.String IpamPoolId { get; set; }
            public System.String IpamPoolOwner { get; set; }
            public System.Func<Amazon.EC2.Model.MoveByoipCidrToIpamResponse, MoveEC2ByoipCidrToIpamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ByoipCidr;
        }
        
    }
}
