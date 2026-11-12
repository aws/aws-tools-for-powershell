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
using Amazon.MWAAServerless;
using Amazon.MWAAServerless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MWAAS
{
    /// <summary>
    /// Creates a launch URL that opens the Apache Airflow UI for your workflows in Amazon
    /// Managed Workflows for Apache Airflow Serverless. The UI shows the workflows in your
    /// account in the current AWS Region. To start a UI session, open the URL in a browser
    /// before it expires.
    /// 
    ///  
    /// <para>
    /// The UI runs with the permissions of the IAM identity that you use to call this operation.
    /// You see only the workflows, workflow runs, and logs that the identity can read, and
    /// you can start a workflow run only if the identity has permission to start one.
    /// </para><para>
    /// The UI session uses the caller's permissions. The session works only from the network
    /// address that opened the URL. It ends at <c>SessionExpiresAt</c> or when you sign out
    /// from the UI.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MWAASAirflowUiUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse")]
    [AWSCmdlet("Calls the AmazonMWAAServerless CreateAirflowUiUrl API operation.", Operation = new[] {"CreateAirflowUiUrl"}, SelectReturnType = typeof(Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse))]
    [AWSCmdletOutput("Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse",
        "This cmdlet returns an Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse object containing multiple properties."
    )]
    public partial class NewMWAASAirflowUiUrlCmdlet : AmazonMWAAServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExpiresInSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the number of seconds that the launch URL stays valid. This value limits
        /// only the time to open the URL, not the length of the UI session. The default is 300.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpiresInSeconds")]
        public System.Int32? ExpiresInSecond { get; set; }
        #endregion
        
        #region Parameter SessionDurationInSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the number of seconds that the UI session lasts, starting from when you
        /// call this operation. The default is 43200 (12 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionDurationInSeconds")]
        public System.Int32? SessionDurationInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse).
        /// Specifying the name of a property of type Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MWAASAirflowUiUrl (CreateAirflowUiUrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse, NewMWAASAirflowUiUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExpiresInSecond = this.ExpiresInSecond;
            context.SessionDurationInSecond = this.SessionDurationInSecond;
            
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
            var request = new Amazon.MWAAServerless.Model.CreateAirflowUiUrlRequest();
            
            if (cmdletContext.ExpiresInSecond != null)
            {
                request.ExpiresInSeconds = cmdletContext.ExpiresInSecond.Value;
            }
            if (cmdletContext.SessionDurationInSecond != null)
            {
                request.SessionDurationInSeconds = cmdletContext.SessionDurationInSecond.Value;
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
        
        private Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse CallAWSServiceOperation(IAmazonMWAAServerless client, Amazon.MWAAServerless.Model.CreateAirflowUiUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAAServerless", "CreateAirflowUiUrl");
            try
            {
                return client.CreateAirflowUiUrlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? SessionDurationInSecond { get; set; }
            public System.Func<Amazon.MWAAServerless.Model.CreateAirflowUiUrlResponse, NewMWAASAirflowUiUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
