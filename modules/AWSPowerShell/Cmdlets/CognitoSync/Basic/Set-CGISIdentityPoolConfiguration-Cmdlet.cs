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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGIS
{
    /// <summary>
    /// Sets the necessary configuration for push sync.
    /// 
    /// 
    /// <para>
    /// This API can only be called with developer credentials. You cannot call this API with
    /// the temporary user credentials provided by Cognito Identity.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "CGISIdentityPoolConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Sync SetIdentityPoolConfiguration API operation.", Operation = new[] {"SetIdentityPoolConfiguration"}, SelectReturnType = typeof(Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse",
        "This cmdlet returns an Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse object containing multiple properties."
    )]
    public partial class SetCGISIdentityPoolConfigurationCmdlet : AmazonCognitoSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CognitoStream
        /// <summary>
        /// <para>
        /// Options to apply to this identity pool
        /// for Amazon Cognito streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CognitoStreams")]
        public Amazon.CognitoSync.Model.CognitoStreams CognitoStream { get; set; }
        #endregion
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE) created
        /// by Amazon Cognito. This is the ID of the pool to modify.</para>
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
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter PushSync
        /// <summary>
        /// <para>
        /// <para>Options to apply to this identity pool for push synchronization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CognitoSync.Model.PushSync PushSync { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGISIdentityPoolConfiguration (SetIdentityPoolConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse, SetCGISIdentityPoolConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CognitoStream = this.CognitoStream;
            context.IdentityPoolId = this.IdentityPoolId;
            #if MODULAR
            if (this.IdentityPoolId == null && ParameterWasBound(nameof(this.IdentityPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PushSync = this.PushSync;
            
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
            var request = new Amazon.CognitoSync.Model.SetIdentityPoolConfigurationRequest();
            
            if (cmdletContext.CognitoStream != null)
            {
                request.CognitoStreams = cmdletContext.CognitoStream;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.PushSync != null)
            {
                request.PushSync = cmdletContext.PushSync;
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
        
        private Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse CallAWSServiceOperation(IAmazonCognitoSync client, Amazon.CognitoSync.Model.SetIdentityPoolConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Sync", "SetIdentityPoolConfiguration");
            try
            {
                return client.SetIdentityPoolConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CognitoSync.Model.CognitoStreams CognitoStream { get; set; }
            public System.String IdentityPoolId { get; set; }
            public Amazon.CognitoSync.Model.PushSync PushSync { get; set; }
            public System.Func<Amazon.CognitoSync.Model.SetIdentityPoolConfigurationResponse, SetCGISIdentityPoolConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
