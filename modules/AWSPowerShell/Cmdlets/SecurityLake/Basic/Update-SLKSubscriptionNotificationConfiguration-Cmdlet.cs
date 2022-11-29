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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Create a new subscription notification or add the existing subscription notification
    /// setting for the specified subscription ID.
    /// </summary>
    [Cmdlet("Update", "SLKSubscriptionNotificationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Security Lake UpdateSubscriptionNotificationConfiguration API operation.", Operation = new[] {"UpdateSubscriptionNotificationConfiguration"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSLKSubscriptionNotificationConfigurationCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        #region Parameter CreateSq
        /// <summary>
        /// <para>
        /// <para>Create a new subscription notification for the specified subscription ID in Security
        /// Lake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CreateSqs")]
        public System.Boolean? CreateSq { get; set; }
        #endregion
        
        #region Parameter HttpsApiKeyName
        /// <summary>
        /// <para>
        /// <para>The key name for the subscription notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpsApiKeyName { get; set; }
        #endregion
        
        #region Parameter HttpsApiKeyValue
        /// <summary>
        /// <para>
        /// <para>The key value for the subscription notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpsApiKeyValue { get; set; }
        #endregion
        
        #region Parameter HttpsMethod
        /// <summary>
        /// <para>
        /// <para>The HTTPS method used for the subscription notification. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityLake.HttpsMethod")]
        public Amazon.SecurityLake.HttpsMethod HttpsMethod { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) specifying the role of the subscriber. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SubscriptionEndpoint
        /// <summary>
        /// <para>
        /// <para>The subscription endpoint in Security Lake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriptionEndpoint { get; set; }
        #endregion
        
        #region Parameter SubscriptionId
        /// <summary>
        /// <para>
        /// <para>The subscription ID for which the subscription notification is specified. </para>
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
        public System.String SubscriptionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueueArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueueArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubscriptionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubscriptionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubscriptionId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SLKSubscriptionNotificationConfiguration (UpdateSubscriptionNotificationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse, UpdateSLKSubscriptionNotificationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubscriptionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CreateSq = this.CreateSq;
            context.HttpsApiKeyName = this.HttpsApiKeyName;
            context.HttpsApiKeyValue = this.HttpsApiKeyValue;
            context.HttpsMethod = this.HttpsMethod;
            context.RoleArn = this.RoleArn;
            context.SubscriptionEndpoint = this.SubscriptionEndpoint;
            context.SubscriptionId = this.SubscriptionId;
            #if MODULAR
            if (this.SubscriptionId == null && ParameterWasBound(nameof(this.SubscriptionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationRequest();
            
            if (cmdletContext.CreateSq != null)
            {
                request.CreateSqs = cmdletContext.CreateSq.Value;
            }
            if (cmdletContext.HttpsApiKeyName != null)
            {
                request.HttpsApiKeyName = cmdletContext.HttpsApiKeyName;
            }
            if (cmdletContext.HttpsApiKeyValue != null)
            {
                request.HttpsApiKeyValue = cmdletContext.HttpsApiKeyValue;
            }
            if (cmdletContext.HttpsMethod != null)
            {
                request.HttpsMethod = cmdletContext.HttpsMethod;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SubscriptionEndpoint != null)
            {
                request.SubscriptionEndpoint = cmdletContext.SubscriptionEndpoint;
            }
            if (cmdletContext.SubscriptionId != null)
            {
                request.SubscriptionId = cmdletContext.SubscriptionId;
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
        
        private Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "UpdateSubscriptionNotificationConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateSubscriptionNotificationConfiguration(request);
                #elif CORECLR
                return client.UpdateSubscriptionNotificationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CreateSq { get; set; }
            public System.String HttpsApiKeyName { get; set; }
            public System.String HttpsApiKeyValue { get; set; }
            public Amazon.SecurityLake.HttpsMethod HttpsMethod { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SubscriptionEndpoint { get; set; }
            public System.String SubscriptionId { get; set; }
            public System.Func<Amazon.SecurityLake.Model.UpdateSubscriptionNotificationConfigurationResponse, UpdateSLKSubscriptionNotificationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueArn;
        }
        
    }
}
