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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Deregisters an instance. Before you deregister an instance, all bridges running on
    /// the instance must be stopped. If you want to deregister an instance without stopping
    /// the bridges, you must use the --force option.
    /// </summary>
    [Cmdlet("Remove", "EMCNGatewayInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect DeregisterGatewayInstance API operation.", Operation = new[] {"DeregisterGatewayInstance"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse object containing multiple properties."
    )]
    public partial class RemoveEMCNGatewayInstanceCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ForceRemove
        /// <summary>
        /// <para>
        /// Force the deregistration of an instance. Force will
        /// deregister an instance, even if there are bridges running on it.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceRemove { get; set; }
        #endregion
        
        #region Parameter GatewayInstanceArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the
        /// gateway that contains the instance that you want to deregister.
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
        public System.String GatewayInstanceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EMCNGatewayInstance (DeregisterGatewayInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse, RemoveEMCNGatewayInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ForceRemove = this.ForceRemove;
            context.GatewayInstanceArn = this.GatewayInstanceArn;
            #if MODULAR
            if (this.GatewayInstanceArn == null && ParameterWasBound(nameof(this.GatewayInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaConnect.Model.DeregisterGatewayInstanceRequest();
            
            if (cmdletContext.ForceRemove != null)
            {
                request.Force = cmdletContext.ForceRemove.Value;
            }
            if (cmdletContext.GatewayInstanceArn != null)
            {
                request.GatewayInstanceArn = cmdletContext.GatewayInstanceArn;
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
        
        private Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.DeregisterGatewayInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "DeregisterGatewayInstance");
            try
            {
                return client.DeregisterGatewayInstanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ForceRemove { get; set; }
            public System.String GatewayInstanceArn { get; set; }
            public System.Func<Amazon.MediaConnect.Model.DeregisterGatewayInstanceResponse, RemoveEMCNGatewayInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
