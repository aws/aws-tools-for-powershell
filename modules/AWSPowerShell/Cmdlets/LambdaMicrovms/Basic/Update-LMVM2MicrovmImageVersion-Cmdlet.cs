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
using Amazon.LambdaMicrovms;
using Amazon.LambdaMicrovms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMVM2
{
    /// <summary>
    /// Updates the status of a specific MicroVM image version.
    /// </summary>
    [Cmdlet("Update", "LMVM2MicrovmImageVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse")]
    [AWSCmdlet("Calls the Lambda MicroVMs UpdateMicrovmImageVersion API operation.", Operation = new[] {"UpdateMicrovmImageVersion"}, SelectReturnType = typeof(Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse))]
    [AWSCmdletOutput("Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse",
        "This cmdlet returns an Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse object containing multiple properties."
    )]
    public partial class UpdateLMVM2MicrovmImageVersionCmdlet : AmazonLambdaMicrovmsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ImageIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ARN or ID) of the MicroVM image.</para>
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
        public System.String ImageIdentifier { get; set; }
        #endregion
        
        #region Parameter ImageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the MicroVM image to update.</para>
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
        public System.String ImageVersion { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new status to set for the MicroVM image version.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LambdaMicrovms.MicrovmImageVersionStatus")]
        public Amazon.LambdaMicrovms.MicrovmImageVersionStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse).
        /// Specifying the name of a property of type Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMVM2MicrovmImageVersion (UpdateMicrovmImageVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse, UpdateLMVM2MicrovmImageVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImageIdentifier = this.ImageIdentifier;
            #if MODULAR
            if (this.ImageIdentifier == null && ParameterWasBound(nameof(this.ImageIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageVersion = this.ImageVersion;
            #if MODULAR
            if (this.ImageVersion == null && ParameterWasBound(nameof(this.ImageVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionRequest();
            
            if (cmdletContext.ImageIdentifier != null)
            {
                request.ImageIdentifier = cmdletContext.ImageIdentifier;
            }
            if (cmdletContext.ImageVersion != null)
            {
                request.ImageVersion = cmdletContext.ImageVersion;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse CallAWSServiceOperation(IAmazonLambdaMicrovms client, Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda MicroVMs", "UpdateMicrovmImageVersion");
            try
            {
                return client.UpdateMicrovmImageVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ImageIdentifier { get; set; }
            public System.String ImageVersion { get; set; }
            public Amazon.LambdaMicrovms.MicrovmImageVersionStatus Status { get; set; }
            public System.Func<Amazon.LambdaMicrovms.Model.UpdateMicrovmImageVersionResponse, UpdateLMVM2MicrovmImageVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
