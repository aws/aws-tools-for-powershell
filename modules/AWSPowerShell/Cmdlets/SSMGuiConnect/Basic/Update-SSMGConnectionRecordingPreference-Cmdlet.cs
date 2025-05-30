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
using Amazon.SSMGuiConnect;
using Amazon.SSMGuiConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSMG
{
    /// <summary>
    /// Updates the preferences for recording RDP connections.
    /// </summary>
    [Cmdlet("Update", "SSMGConnectionRecordingPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SSMGuiConnect.Model.ConnectionRecordingPreferences")]
    [AWSCmdlet("Calls the AWS SSM-GUIConnect UpdateConnectionRecordingPreferences API operation.", Operation = new[] {"UpdateConnectionRecordingPreferences"}, SelectReturnType = typeof(Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse))]
    [AWSCmdletOutput("Amazon.SSMGuiConnect.Model.ConnectionRecordingPreferences or Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse",
        "This cmdlet returns an Amazon.SSMGuiConnect.Model.ConnectionRecordingPreferences object.",
        "The service call response (type Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSMGConnectionRecordingPreferenceCmdlet : AmazonSSMGuiConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectionRecordingPreferences_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a KMS key that is used to encrypt data while it is being processed by the
        /// service. This key must exist in the same Amazon Web Services Region as the node you
        /// start an RDP connection to.</para>
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
        public System.String ConnectionRecordingPreferences_KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter RecordingDestinations_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket where RDP connection recordings are stored.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ConnectionRecordingPreferences_RecordingDestinations_S3Buckets")]
        public Amazon.SSMGuiConnect.Model.S3Bucket[] RecordingDestinations_S3Bucket { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectionRecordingPreferences'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse).
        /// Specifying the name of a property of type Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectionRecordingPreferences";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionRecordingPreferences_KMSKeyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMGConnectionRecordingPreference (UpdateConnectionRecordingPreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse, UpdateSSMGConnectionRecordingPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectionRecordingPreferences_KMSKeyArn = this.ConnectionRecordingPreferences_KMSKeyArn;
            #if MODULAR
            if (this.ConnectionRecordingPreferences_KMSKeyArn == null && ParameterWasBound(nameof(this.ConnectionRecordingPreferences_KMSKeyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionRecordingPreferences_KMSKeyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RecordingDestinations_S3Bucket != null)
            {
                context.RecordingDestinations_S3Bucket = new List<Amazon.SSMGuiConnect.Model.S3Bucket>(this.RecordingDestinations_S3Bucket);
            }
            #if MODULAR
            if (this.RecordingDestinations_S3Bucket == null && ParameterWasBound(nameof(this.RecordingDestinations_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordingDestinations_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConnectionRecordingPreferences
            var requestConnectionRecordingPreferencesIsNull = true;
            request.ConnectionRecordingPreferences = new Amazon.SSMGuiConnect.Model.ConnectionRecordingPreferences();
            System.String requestConnectionRecordingPreferences_connectionRecordingPreferences_KMSKeyArn = null;
            if (cmdletContext.ConnectionRecordingPreferences_KMSKeyArn != null)
            {
                requestConnectionRecordingPreferences_connectionRecordingPreferences_KMSKeyArn = cmdletContext.ConnectionRecordingPreferences_KMSKeyArn;
            }
            if (requestConnectionRecordingPreferences_connectionRecordingPreferences_KMSKeyArn != null)
            {
                request.ConnectionRecordingPreferences.KMSKeyArn = requestConnectionRecordingPreferences_connectionRecordingPreferences_KMSKeyArn;
                requestConnectionRecordingPreferencesIsNull = false;
            }
            Amazon.SSMGuiConnect.Model.RecordingDestinations requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations = null;
            
             // populate RecordingDestinations
            var requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinationsIsNull = true;
            requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations = new Amazon.SSMGuiConnect.Model.RecordingDestinations();
            List<Amazon.SSMGuiConnect.Model.S3Bucket> requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations_recordingDestinations_S3Bucket = null;
            if (cmdletContext.RecordingDestinations_S3Bucket != null)
            {
                requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations_recordingDestinations_S3Bucket = cmdletContext.RecordingDestinations_S3Bucket;
            }
            if (requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations_recordingDestinations_S3Bucket != null)
            {
                requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations.S3Buckets = requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations_recordingDestinations_S3Bucket;
                requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinationsIsNull = false;
            }
             // determine if requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations should be set to null
            if (requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinationsIsNull)
            {
                requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations = null;
            }
            if (requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations != null)
            {
                request.ConnectionRecordingPreferences.RecordingDestinations = requestConnectionRecordingPreferences_connectionRecordingPreferences_RecordingDestinations;
                requestConnectionRecordingPreferencesIsNull = false;
            }
             // determine if request.ConnectionRecordingPreferences should be set to null
            if (requestConnectionRecordingPreferencesIsNull)
            {
                request.ConnectionRecordingPreferences = null;
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
        
        private Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse CallAWSServiceOperation(IAmazonSSMGuiConnect client, Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS SSM-GUIConnect", "UpdateConnectionRecordingPreferences");
            try
            {
                return client.UpdateConnectionRecordingPreferencesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectionRecordingPreferences_KMSKeyArn { get; set; }
            public List<Amazon.SSMGuiConnect.Model.S3Bucket> RecordingDestinations_S3Bucket { get; set; }
            public System.Func<Amazon.SSMGuiConnect.Model.UpdateConnectionRecordingPreferencesResponse, UpdateSSMGConnectionRecordingPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectionRecordingPreferences;
        }
        
    }
}
