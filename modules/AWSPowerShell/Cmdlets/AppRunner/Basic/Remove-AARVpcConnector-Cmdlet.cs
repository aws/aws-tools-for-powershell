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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Delete an App Runner VPC connector resource. You can't delete a connector that's used
    /// by one or more App Runner services.
    /// </summary>
    [Cmdlet("Remove", "AARVpcConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.AppRunner.Model.VpcConnector")]
    [AWSCmdlet("Calls the AWS App Runner DeleteVpcConnector API operation.", Operation = new[] {"DeleteVpcConnector"}, SelectReturnType = typeof(Amazon.AppRunner.Model.DeleteVpcConnectorResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.VpcConnector or Amazon.AppRunner.Model.DeleteVpcConnectorResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.VpcConnector object.",
        "The service call response (type Amazon.AppRunner.Model.DeleteVpcConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveAARVpcConnectorCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VpcConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the App Runner VPC connector that you want to delete.</para><para>The ARN must be a full VPC connector ARN.</para>
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
        public System.String VpcConnectorArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcConnector'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.DeleteVpcConnectorResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.DeleteVpcConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcConnector";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcConnectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AARVpcConnector (DeleteVpcConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.DeleteVpcConnectorResponse, RemoveAARVpcConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.VpcConnectorArn = this.VpcConnectorArn;
            #if MODULAR
            if (this.VpcConnectorArn == null && ParameterWasBound(nameof(this.VpcConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRunner.Model.DeleteVpcConnectorRequest();
            
            if (cmdletContext.VpcConnectorArn != null)
            {
                request.VpcConnectorArn = cmdletContext.VpcConnectorArn;
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
        
        private Amazon.AppRunner.Model.DeleteVpcConnectorResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.DeleteVpcConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "DeleteVpcConnector");
            try
            {
                return client.DeleteVpcConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String VpcConnectorArn { get; set; }
            public System.Func<Amazon.AppRunner.Model.DeleteVpcConnectorResponse, RemoveAARVpcConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcConnector;
        }
        
    }
}
