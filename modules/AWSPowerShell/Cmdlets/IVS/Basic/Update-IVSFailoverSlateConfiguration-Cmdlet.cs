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
using Amazon.IVS;
using Amazon.IVS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Updates a specified failover slate configuration.
    /// </summary>
    [Cmdlet("Update", "IVSFailoverSlateConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.FailoverSlateConfiguration")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service UpdateFailoverSlateConfiguration API operation.", Operation = new[] {"UpdateFailoverSlateConfiguration"}, SelectReturnType = typeof(Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.FailoverSlateConfiguration or Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse",
        "This cmdlet returns an Amazon.IVS.Model.FailoverSlateConfiguration object.",
        "The service call response (type Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIVSFailoverSlateConfigurationCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActivationThresholdSecond
        /// <summary>
        /// <para>
        /// <para>Number of seconds of ingest interruption before the failover slate activates. Default:
        /// <c>3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActivationThresholdSeconds")]
        public System.Int32? ActivationThresholdSecond { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the failover slate configuration to be updated.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter MaxSlateDisplaySecond
        /// <summary>
        /// <para>
        /// <para>Maximum number of seconds that the failover slate displays. Default: <c>60</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxSlateDisplaySeconds")]
        public System.Int32? MaxSlateDisplaySecond { get; set; }
        #endregion
        
        #region Parameter MinSlateDisplaySecond
        /// <summary>
        /// <para>
        /// <para>Minimum number of seconds that the failover slate displays after activation. Default:
        /// <c>3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinSlateDisplaySeconds")]
        public System.Int32? MinSlateDisplaySecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Failover-slate-configuration name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailoverSlateConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailoverSlateConfiguration";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IVSFailoverSlateConfiguration (UpdateFailoverSlateConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse, UpdateIVSFailoverSlateConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActivationThresholdSecond = this.ActivationThresholdSecond;
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxSlateDisplaySecond = this.MaxSlateDisplaySecond;
            context.MinSlateDisplaySecond = this.MinSlateDisplaySecond;
            context.Name = this.Name;
            
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
            var request = new Amazon.IVS.Model.UpdateFailoverSlateConfigurationRequest();
            
            if (cmdletContext.ActivationThresholdSecond != null)
            {
                request.ActivationThresholdSeconds = cmdletContext.ActivationThresholdSecond.Value;
            }
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.MaxSlateDisplaySecond != null)
            {
                request.MaxSlateDisplaySeconds = cmdletContext.MaxSlateDisplaySecond.Value;
            }
            if (cmdletContext.MinSlateDisplaySecond != null)
            {
                request.MinSlateDisplaySeconds = cmdletContext.MinSlateDisplaySecond.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.UpdateFailoverSlateConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "UpdateFailoverSlateConfiguration");
            try
            {
                return client.UpdateFailoverSlateConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ActivationThresholdSecond { get; set; }
            public System.String Arn { get; set; }
            public System.Int32? MaxSlateDisplaySecond { get; set; }
            public System.Int32? MinSlateDisplaySecond { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.IVS.Model.UpdateFailoverSlateConfigurationResponse, UpdateIVSFailoverSlateConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailoverSlateConfiguration;
        }
        
    }
}
