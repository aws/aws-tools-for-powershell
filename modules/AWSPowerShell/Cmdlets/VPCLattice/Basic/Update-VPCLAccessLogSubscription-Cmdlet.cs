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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Updates the specified access log subscription.
    /// </summary>
    [Cmdlet("Update", "VPCLAccessLogSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse")]
    [AWSCmdlet("Calls the VPC Lattice UpdateAccessLogSubscription API operation.", Operation = new[] {"UpdateAccessLogSubscription"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse object containing multiple properties."
    )]
    public partial class UpdateVPCLAccessLogSubscriptionCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessLogSubscriptionIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the access log subscription.</para>
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
        public System.String AccessLogSubscriptionIdentifier { get; set; }
        #endregion
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the access log destination.</para>
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
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccessLogSubscriptionIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-VPCLAccessLogSubscription (UpdateAccessLogSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse, UpdateVPCLAccessLogSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessLogSubscriptionIdentifier = this.AccessLogSubscriptionIdentifier;
            #if MODULAR
            if (this.AccessLogSubscriptionIdentifier == null && ParameterWasBound(nameof(this.AccessLogSubscriptionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessLogSubscriptionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationArn = this.DestinationArn;
            #if MODULAR
            if (this.DestinationArn == null && ParameterWasBound(nameof(this.DestinationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionRequest();
            
            if (cmdletContext.AccessLogSubscriptionIdentifier != null)
            {
                request.AccessLogSubscriptionIdentifier = cmdletContext.AccessLogSubscriptionIdentifier;
            }
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
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
        
        private Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "UpdateAccessLogSubscription");
            try
            {
                return client.UpdateAccessLogSubscriptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccessLogSubscriptionIdentifier { get; set; }
            public System.String DestinationArn { get; set; }
            public System.Func<Amazon.VPCLattice.Model.UpdateAccessLogSubscriptionResponse, UpdateVPCLAccessLogSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
