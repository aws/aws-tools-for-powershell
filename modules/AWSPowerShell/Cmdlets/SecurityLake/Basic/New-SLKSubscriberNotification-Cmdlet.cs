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
    /// Notifies the subscriber when new data is written to the data lake for the sources
    /// that the subscriber consumes in Security Lake. You can create only one subscriber
    /// notification per subscriber.
    /// </summary>
    [Cmdlet("New", "SLKSubscriberNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Security Lake CreateSubscriberNotification API operation.", Operation = new[] {"CreateSubscriberNotification"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSLKSubscriberNotificationCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HttpsNotificationConfiguration_AuthorizationApiKeyName
        /// <summary>
        /// <para>
        /// <para>The key name for the notification subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_HttpsNotificationConfiguration_AuthorizationApiKeyName")]
        public System.String HttpsNotificationConfiguration_AuthorizationApiKeyName { get; set; }
        #endregion
        
        #region Parameter HttpsNotificationConfiguration_AuthorizationApiKeyValue
        /// <summary>
        /// <para>
        /// <para>The key value for the notification subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_HttpsNotificationConfiguration_AuthorizationApiKeyValue")]
        public System.String HttpsNotificationConfiguration_AuthorizationApiKeyValue { get; set; }
        #endregion
        
        #region Parameter HttpsNotificationConfiguration_Endpoint
        /// <summary>
        /// <para>
        /// <para>The subscription endpoint in Security Lake. If you prefer notification with an HTTPs
        /// endpoint, populate this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_HttpsNotificationConfiguration_Endpoint")]
        public System.String HttpsNotificationConfiguration_Endpoint { get; set; }
        #endregion
        
        #region Parameter HttpsNotificationConfiguration_HttpMethod
        /// <summary>
        /// <para>
        /// <para>The HTTPS method used for the notification subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_HttpsNotificationConfiguration_HttpMethod")]
        [AWSConstantClassSource("Amazon.SecurityLake.HttpMethod")]
        public Amazon.SecurityLake.HttpMethod HttpsNotificationConfiguration_HttpMethod { get; set; }
        #endregion
        
        #region Parameter Configuration_SqsNotificationConfiguration
        /// <summary>
        /// <para>
        /// <para>The configurations for SQS subscriber notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityLake.Model.SqsNotificationConfiguration Configuration_SqsNotificationConfiguration { get; set; }
        #endregion
        
        #region Parameter SubscriberId
        /// <summary>
        /// <para>
        /// <para>The subscriber ID for the notification subscription.</para>
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
        public System.String SubscriberId { get; set; }
        #endregion
        
        #region Parameter HttpsNotificationConfiguration_TargetRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the EventBridge API destinations IAM role that you
        /// created. For more information about ARNs and how to use them in policies, see <a href="https://docs.aws.amazon.com//security-lake/latest/userguide/subscriber-data-access.html">Managing
        /// data access</a> and <a href="https://docs.aws.amazon.com/security-lake/latest/userguide/security-iam-awsmanpol.html">Amazon
        /// Web Services Managed Policies</a> in the <i>Amazon Security Lake User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_HttpsNotificationConfiguration_TargetRoleArn")]
        public System.String HttpsNotificationConfiguration_TargetRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SubscriberEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SubscriberEndpoint";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriberId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SLKSubscriberNotification (CreateSubscriberNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse, NewSLKSubscriberNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HttpsNotificationConfiguration_AuthorizationApiKeyName = this.HttpsNotificationConfiguration_AuthorizationApiKeyName;
            context.HttpsNotificationConfiguration_AuthorizationApiKeyValue = this.HttpsNotificationConfiguration_AuthorizationApiKeyValue;
            context.HttpsNotificationConfiguration_Endpoint = this.HttpsNotificationConfiguration_Endpoint;
            context.HttpsNotificationConfiguration_HttpMethod = this.HttpsNotificationConfiguration_HttpMethod;
            context.HttpsNotificationConfiguration_TargetRoleArn = this.HttpsNotificationConfiguration_TargetRoleArn;
            context.Configuration_SqsNotificationConfiguration = this.Configuration_SqsNotificationConfiguration;
            context.SubscriberId = this.SubscriberId;
            #if MODULAR
            if (this.SubscriberId == null && ParameterWasBound(nameof(this.SubscriberId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityLake.Model.CreateSubscriberNotificationRequest();
            
            
             // populate Configuration
            request.Configuration = new Amazon.SecurityLake.Model.NotificationConfiguration();
            Amazon.SecurityLake.Model.SqsNotificationConfiguration requestConfiguration_configuration_SqsNotificationConfiguration = null;
            if (cmdletContext.Configuration_SqsNotificationConfiguration != null)
            {
                requestConfiguration_configuration_SqsNotificationConfiguration = cmdletContext.Configuration_SqsNotificationConfiguration;
            }
            if (requestConfiguration_configuration_SqsNotificationConfiguration != null)
            {
                request.Configuration.SqsNotificationConfiguration = requestConfiguration_configuration_SqsNotificationConfiguration;
            }
            Amazon.SecurityLake.Model.HttpsNotificationConfiguration requestConfiguration_configuration_HttpsNotificationConfiguration = null;
            
             // populate HttpsNotificationConfiguration
            var requestConfiguration_configuration_HttpsNotificationConfigurationIsNull = true;
            requestConfiguration_configuration_HttpsNotificationConfiguration = new Amazon.SecurityLake.Model.HttpsNotificationConfiguration();
            System.String requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyName = null;
            if (cmdletContext.HttpsNotificationConfiguration_AuthorizationApiKeyName != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyName = cmdletContext.HttpsNotificationConfiguration_AuthorizationApiKeyName;
            }
            if (requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyName != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration.AuthorizationApiKeyName = requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyName;
                requestConfiguration_configuration_HttpsNotificationConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyValue = null;
            if (cmdletContext.HttpsNotificationConfiguration_AuthorizationApiKeyValue != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyValue = cmdletContext.HttpsNotificationConfiguration_AuthorizationApiKeyValue;
            }
            if (requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyValue != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration.AuthorizationApiKeyValue = requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_AuthorizationApiKeyValue;
                requestConfiguration_configuration_HttpsNotificationConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_Endpoint = null;
            if (cmdletContext.HttpsNotificationConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_Endpoint = cmdletContext.HttpsNotificationConfiguration_Endpoint;
            }
            if (requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration.Endpoint = requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_Endpoint;
                requestConfiguration_configuration_HttpsNotificationConfigurationIsNull = false;
            }
            Amazon.SecurityLake.HttpMethod requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_HttpMethod = null;
            if (cmdletContext.HttpsNotificationConfiguration_HttpMethod != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_HttpMethod = cmdletContext.HttpsNotificationConfiguration_HttpMethod;
            }
            if (requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_HttpMethod != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration.HttpMethod = requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_HttpMethod;
                requestConfiguration_configuration_HttpsNotificationConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_TargetRoleArn = null;
            if (cmdletContext.HttpsNotificationConfiguration_TargetRoleArn != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_TargetRoleArn = cmdletContext.HttpsNotificationConfiguration_TargetRoleArn;
            }
            if (requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_TargetRoleArn != null)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration.TargetRoleArn = requestConfiguration_configuration_HttpsNotificationConfiguration_httpsNotificationConfiguration_TargetRoleArn;
                requestConfiguration_configuration_HttpsNotificationConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_HttpsNotificationConfiguration should be set to null
            if (requestConfiguration_configuration_HttpsNotificationConfigurationIsNull)
            {
                requestConfiguration_configuration_HttpsNotificationConfiguration = null;
            }
            if (requestConfiguration_configuration_HttpsNotificationConfiguration != null)
            {
                request.Configuration.HttpsNotificationConfiguration = requestConfiguration_configuration_HttpsNotificationConfiguration;
            }
            if (cmdletContext.SubscriberId != null)
            {
                request.SubscriberId = cmdletContext.SubscriberId;
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
        
        private Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.CreateSubscriberNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "CreateSubscriberNotification");
            try
            {
                return client.CreateSubscriberNotificationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HttpsNotificationConfiguration_AuthorizationApiKeyName { get; set; }
            public System.String HttpsNotificationConfiguration_AuthorizationApiKeyValue { get; set; }
            public System.String HttpsNotificationConfiguration_Endpoint { get; set; }
            public Amazon.SecurityLake.HttpMethod HttpsNotificationConfiguration_HttpMethod { get; set; }
            public System.String HttpsNotificationConfiguration_TargetRoleArn { get; set; }
            public Amazon.SecurityLake.Model.SqsNotificationConfiguration Configuration_SqsNotificationConfiguration { get; set; }
            public System.String SubscriberId { get; set; }
            public System.Func<Amazon.SecurityLake.Model.CreateSubscriberNotificationResponse, NewSLKSubscriberNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SubscriberEndpoint;
        }
        
    }
}
