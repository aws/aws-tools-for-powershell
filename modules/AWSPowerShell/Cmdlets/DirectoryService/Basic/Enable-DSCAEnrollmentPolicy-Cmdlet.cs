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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Enables certificate authority (CA) enrollment policy for the specified directory.
    /// This allows domain-joined clients to automatically request and receive certificates
    /// from the specified Amazon Web Services Private Certificate Authority.
    /// 
    ///  <note><para>
    /// Before enabling CA enrollment, ensure that the PCA connector is properly configured
    /// and accessible from the directory. The connector must be in an active state and have
    /// the necessary permissions.
    /// </para></note>
    /// </summary>
    [Cmdlet("Enable", "DSCAEnrollmentPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Directory Service EnableCAEnrollmentPolicy API operation.", Operation = new[] {"EnableCAEnrollmentPolicy"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class EnableDSCAEnrollmentPolicyCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory for which to enable the CA enrollment policy.</para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter PcaConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Private Certificate Authority (PCA) connector
        /// to use for automatic certificate enrollment. This connector must be properly configured
        /// and accessible from the directory.</para><para>The ARN format is: <c>arn:aws:pca-connector-ad:<i>region</i>:<i>account-id</i>:connector/<i>connector-id</i></c></para>
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
        public System.String PcaConnectorArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DSCAEnrollmentPolicy (EnableCAEnrollmentPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyResponse, EnableDSCAEnrollmentPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PcaConnectorArn = this.PcaConnectorArn;
            #if MODULAR
            if (this.PcaConnectorArn == null && ParameterWasBound(nameof(this.PcaConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PcaConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.PcaConnectorArn != null)
            {
                request.PcaConnectorArn = cmdletContext.PcaConnectorArn;
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
        
        private Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "EnableCAEnrollmentPolicy");
            try
            {
                return client.EnableCAEnrollmentPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DirectoryId { get; set; }
            public System.String PcaConnectorArn { get; set; }
            public System.Func<Amazon.DirectoryService.Model.EnableCAEnrollmentPolicyResponse, EnableDSCAEnrollmentPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
