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
using Amazon.CognitoSync;
using Amazon.CognitoSync.Model;

namespace Amazon.PowerShell.Cmdlets.CGIS
{
    /// <summary>
    /// Unsubscribes from receiving notifications when a dataset is modified by another device.
    /// 
    /// 
    /// <para>
    /// This API can only be called with temporary credentials provided by Cognito Identity.
    /// You cannot call this API with developer credentials.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CGISDatasetSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Sync UnsubscribeFromDataset API operation.", Operation = new[] {"UnsubscribeFromDataset"}, SelectReturnType = typeof(Amazon.CognitoSync.Model.UnsubscribeFromDatasetResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoSync.Model.UnsubscribeFromDatasetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoSync.Model.UnsubscribeFromDatasetResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCGISDatasetSubscriptionCmdlet : AmazonCognitoSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>The name of the dataset from which to unsubcribe.</para>
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
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter DeviceId
        /// <summary>
        /// <para>
        /// <para>The unique ID generated for this device by Cognito.</para>
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
        public System.String DeviceId { get; set; }
        #endregion
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// <para>Unique ID for this identity.</para>
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
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE) created
        /// by Amazon Cognito. The ID of the pool to which this identity belongs.</para>
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
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoSync.Model.UnsubscribeFromDatasetResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CGISDatasetSubscription (UnsubscribeFromDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoSync.Model.UnsubscribeFromDatasetResponse, RemoveCGISDatasetSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceId = this.DeviceId;
            #if MODULAR
            if (this.DeviceId == null && ParameterWasBound(nameof(this.DeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityId = this.IdentityId;
            #if MODULAR
            if (this.IdentityId == null && ParameterWasBound(nameof(this.IdentityId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityPoolId = this.IdentityPoolId;
            #if MODULAR
            if (this.IdentityPoolId == null && ParameterWasBound(nameof(this.IdentityPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoSync.Model.UnsubscribeFromDatasetRequest();
            
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.DeviceId != null)
            {
                request.DeviceId = cmdletContext.DeviceId;
            }
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
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
        
        private Amazon.CognitoSync.Model.UnsubscribeFromDatasetResponse CallAWSServiceOperation(IAmazonCognitoSync client, Amazon.CognitoSync.Model.UnsubscribeFromDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Sync", "UnsubscribeFromDataset");
            try
            {
                return client.UnsubscribeFromDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetName { get; set; }
            public System.String DeviceId { get; set; }
            public System.String IdentityId { get; set; }
            public System.String IdentityPoolId { get; set; }
            public System.Func<Amazon.CognitoSync.Model.UnsubscribeFromDatasetResponse, RemoveCGISDatasetSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
