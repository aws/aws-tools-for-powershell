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
using Amazon.Notifications;
using Amazon.Notifications.Model;

namespace Amazon.PowerShell.Cmdlets.UNO
{
    /// <summary>
    /// Returns a list of <c>EventRules</c> according to specified filters, in reverse chronological
    /// order (newest first).
    /// </summary>
    [Cmdlet("Get", "UNOEventRuleList")]
    [OutputType("Amazon.Notifications.Model.EventRuleStructure")]
    [AWSCmdlet("Calls the AWS User Notifications ListEventRules API operation.", Operation = new[] {"ListEventRules"}, SelectReturnType = typeof(Amazon.Notifications.Model.ListEventRulesResponse))]
    [AWSCmdletOutput("Amazon.Notifications.Model.EventRuleStructure or Amazon.Notifications.Model.ListEventRulesResponse",
        "This cmdlet returns a collection of Amazon.Notifications.Model.EventRuleStructure objects.",
        "The service call response (type Amazon.Notifications.Model.ListEventRulesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetUNOEventRuleListCmdlet : AmazonNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NotificationConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <c>NotificationConfiguration</c>.</para>
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
        public System.String NotificationConfigurationArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned in this call. The default value is 20.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The start token for paginated calls. Retrieved from the response of a previous <c>ListEventRules</c>
        /// call. Next token uses Base64 encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventRules'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Notifications.Model.ListEventRulesResponse).
        /// Specifying the name of a property of type Amazon.Notifications.Model.ListEventRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventRules";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Notifications.Model.ListEventRulesResponse, GetUNOEventRuleListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.NotificationConfigurationArn = this.NotificationConfigurationArn;
            #if MODULAR
            if (this.NotificationConfigurationArn == null && ParameterWasBound(nameof(this.NotificationConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter NotificationConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Notifications.Model.ListEventRulesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.NotificationConfigurationArn != null)
            {
                request.NotificationConfigurationArn = cmdletContext.NotificationConfigurationArn;
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
        
        private Amazon.Notifications.Model.ListEventRulesResponse CallAWSServiceOperation(IAmazonNotifications client, Amazon.Notifications.Model.ListEventRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS User Notifications", "ListEventRules");
            try
            {
                return client.ListEventRulesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String NotificationConfigurationArn { get; set; }
            public System.Func<Amazon.Notifications.Model.ListEventRulesResponse, GetUNOEventRuleListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventRules;
        }
        
    }
}
