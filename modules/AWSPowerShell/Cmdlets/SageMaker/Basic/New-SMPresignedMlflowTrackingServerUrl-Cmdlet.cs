/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Returns a presigned URL that you can use to connect to the MLflow UI attached to your
    /// tracking server. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/mlflow-launch-ui.html">Launch
    /// the MLflow UI using a presigned URL</a>.
    /// </summary>
    [Cmdlet("New", "SMPresignedMlflowTrackingServerUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreatePresignedMlflowTrackingServerUrl API operation.", Operation = new[] {"CreatePresignedMlflowTrackingServerUrl"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMPresignedMlflowTrackingServerUrlCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExpiresInSecond
        /// <summary>
        /// <para>
        /// <para>The duration in seconds that your presigned URL is valid. The presigned URL can be
        /// used only once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpiresInSeconds")]
        public System.Int32? ExpiresInSecond { get; set; }
        #endregion
        
        #region Parameter SessionExpirationDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The duration in seconds that your MLflow UI session is valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionExpirationDurationInSeconds")]
        public System.Int32? SessionExpirationDurationInSecond { get; set; }
        #endregion
        
        #region Parameter TrackingServerName
        /// <summary>
        /// <para>
        /// <para>The name of the tracking server to connect to your MLflow UI.</para>
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
        public System.String TrackingServerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthorizedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthorizedUrl";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrackingServerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMPresignedMlflowTrackingServerUrl (CreatePresignedMlflowTrackingServerUrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse, NewSMPresignedMlflowTrackingServerUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExpiresInSecond = this.ExpiresInSecond;
            context.SessionExpirationDurationInSecond = this.SessionExpirationDurationInSecond;
            context.TrackingServerName = this.TrackingServerName;
            #if MODULAR
            if (this.TrackingServerName == null && ParameterWasBound(nameof(this.TrackingServerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackingServerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlRequest();
            
            if (cmdletContext.ExpiresInSecond != null)
            {
                request.ExpiresInSeconds = cmdletContext.ExpiresInSecond.Value;
            }
            if (cmdletContext.SessionExpirationDurationInSecond != null)
            {
                request.SessionExpirationDurationInSeconds = cmdletContext.SessionExpirationDurationInSecond.Value;
            }
            if (cmdletContext.TrackingServerName != null)
            {
                request.TrackingServerName = cmdletContext.TrackingServerName;
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
        
        private Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreatePresignedMlflowTrackingServerUrl");
            try
            {
                #if DESKTOP
                return client.CreatePresignedMlflowTrackingServerUrl(request);
                #elif CORECLR
                return client.CreatePresignedMlflowTrackingServerUrlAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.Int32? ExpiresInSecond { get; set; }
            public System.Int32? SessionExpirationDurationInSecond { get; set; }
            public System.String TrackingServerName { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreatePresignedMlflowTrackingServerUrlResponse, NewSMPresignedMlflowTrackingServerUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthorizedUrl;
        }
        
    }
}
