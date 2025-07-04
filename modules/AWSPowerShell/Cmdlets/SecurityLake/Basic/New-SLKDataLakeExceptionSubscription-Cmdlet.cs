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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Creates the specified notification subscription in Amazon Security Lake for the organization
    /// you specify. The notification subscription is created for exceptions that cannot be
    /// resolved by Security Lake automatically.
    /// </summary>
    [Cmdlet("New", "SLKDataLakeExceptionSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Security Lake CreateDataLakeExceptionSubscription API operation.", Operation = new[] {"CreateDataLakeExceptionSubscription"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSLKDataLakeExceptionSubscriptionCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExceptionTimeToLive
        /// <summary>
        /// <para>
        /// <para>The expiration period and time-to-live (TTL). It is the duration of time until which
        /// the exception message remains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExceptionTimeToLive { get; set; }
        #endregion
        
        #region Parameter NotificationEndpoint
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account where you want to receive exception notifications.</para>
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
        public System.String NotificationEndpoint { get; set; }
        #endregion
        
        #region Parameter SubscriptionProtocol
        /// <summary>
        /// <para>
        /// <para>The subscription protocol to which exception notifications are posted.</para>
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
        public System.String SubscriptionProtocol { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotificationEndpoint), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SLKDataLakeExceptionSubscription (CreateDataLakeExceptionSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionResponse, NewSLKDataLakeExceptionSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExceptionTimeToLive = this.ExceptionTimeToLive;
            context.NotificationEndpoint = this.NotificationEndpoint;
            #if MODULAR
            if (this.NotificationEndpoint == null && ParameterWasBound(nameof(this.NotificationEndpoint)))
            {
                WriteWarning("You are passing $null as a value for parameter NotificationEndpoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriptionProtocol = this.SubscriptionProtocol;
            #if MODULAR
            if (this.SubscriptionProtocol == null && ParameterWasBound(nameof(this.SubscriptionProtocol)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionProtocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionRequest();
            
            if (cmdletContext.ExceptionTimeToLive != null)
            {
                request.ExceptionTimeToLive = cmdletContext.ExceptionTimeToLive.Value;
            }
            if (cmdletContext.NotificationEndpoint != null)
            {
                request.NotificationEndpoint = cmdletContext.NotificationEndpoint;
            }
            if (cmdletContext.SubscriptionProtocol != null)
            {
                request.SubscriptionProtocol = cmdletContext.SubscriptionProtocol;
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
        
        private Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "CreateDataLakeExceptionSubscription");
            try
            {
                return client.CreateDataLakeExceptionSubscriptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? ExceptionTimeToLive { get; set; }
            public System.String NotificationEndpoint { get; set; }
            public System.String SubscriptionProtocol { get; set; }
            public System.Func<Amazon.SecurityLake.Model.CreateDataLakeExceptionSubscriptionResponse, NewSLKDataLakeExceptionSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
