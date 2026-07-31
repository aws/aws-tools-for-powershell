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
using Amazon.Resiliencehubv2;
using Amazon.Resiliencehubv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RH2
{
    /// <summary>
    /// Creates a test for a service by configuring a test template. Each service has one
    /// test per template.
    /// </summary>
    [Cmdlet("New", "RH2Test", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Resiliencehubv2.Model.Test")]
    [AWSCmdlet("Calls the AWS Resilience Hub V2 CreateTest API operation.", Operation = new[] {"CreateTest"}, SelectReturnType = typeof(Amazon.Resiliencehubv2.Model.CreateTestResponse))]
    [AWSCmdletOutput("Amazon.Resiliencehubv2.Model.Test or Amazon.Resiliencehubv2.Model.CreateTestResponse",
        "This cmdlet returns an Amazon.Resiliencehubv2.Model.Test object.",
        "The service call response (type Amazon.Resiliencehubv2.Model.CreateTestResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRH2TestCmdlet : AmazonResiliencehubv2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LoggingConfiguration_CloudWatchLogGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the CloudWatch Logs log group for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_CloudWatchLogGroupArn { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_LogSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The version of the log schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_LogSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameter values for the test.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM execution role to use when running the test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_S3BucketName { get; set; }
        #endregion
        
        #region Parameter ServiceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the service to create the test for.</para>
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
        public System.String ServiceArn { get; set; }
        #endregion
        
        #region Parameter StopCondition
        /// <summary>
        /// <para>
        /// <para>The stop conditions for the test.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StopConditions")]
        public Amazon.Resiliencehubv2.Model.StopCondition[] StopCondition { get; set; }
        #endregion
        
        #region Parameter TestTemplateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the test template to configure.</para>
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
        public System.String TestTemplateArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Test'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Resiliencehubv2.Model.CreateTestResponse).
        /// Specifying the name of a property of type Amazon.Resiliencehubv2.Model.CreateTestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Test";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TestTemplateArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RH2Test (CreateTest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Resiliencehubv2.Model.CreateTestResponse, NewRH2TestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoggingConfiguration_CloudWatchLogGroupArn = this.LoggingConfiguration_CloudWatchLogGroupArn;
            context.LoggingConfiguration_LogSchemaVersion = this.LoggingConfiguration_LogSchemaVersion;
            context.LoggingConfiguration_S3BucketName = this.LoggingConfiguration_S3BucketName;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Parameter.Add((String)hashKey, valueSet);
                }
            }
            context.RoleName = this.RoleName;
            context.ServiceArn = this.ServiceArn;
            #if MODULAR
            if (this.ServiceArn == null && ParameterWasBound(nameof(this.ServiceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StopCondition != null)
            {
                context.StopCondition = new List<Amazon.Resiliencehubv2.Model.StopCondition>(this.StopCondition);
            }
            context.TestTemplateArn = this.TestTemplateArn;
            #if MODULAR
            if (this.TestTemplateArn == null && ParameterWasBound(nameof(this.TestTemplateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TestTemplateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Resiliencehubv2.Model.CreateTestRequest();
            
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.Resiliencehubv2.Model.LoggingConfiguration();
            System.String requestLoggingConfiguration_loggingConfiguration_CloudWatchLogGroupArn = null;
            if (cmdletContext.LoggingConfiguration_CloudWatchLogGroupArn != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogGroupArn = cmdletContext.LoggingConfiguration_CloudWatchLogGroupArn;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogGroupArn != null)
            {
                request.LoggingConfiguration.CloudWatchLogGroupArn = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogGroupArn;
                requestLoggingConfigurationIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_LogSchemaVersion = null;
            if (cmdletContext.LoggingConfiguration_LogSchemaVersion != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogSchemaVersion = cmdletContext.LoggingConfiguration_LogSchemaVersion;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogSchemaVersion != null)
            {
                request.LoggingConfiguration.LogSchemaVersion = requestLoggingConfiguration_loggingConfiguration_LogSchemaVersion;
                requestLoggingConfigurationIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_S3BucketName = null;
            if (cmdletContext.LoggingConfiguration_S3BucketName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_S3BucketName = cmdletContext.LoggingConfiguration_S3BucketName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_S3BucketName != null)
            {
                request.LoggingConfiguration.S3BucketName = requestLoggingConfiguration_loggingConfiguration_S3BucketName;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
            }
            if (cmdletContext.ServiceArn != null)
            {
                request.ServiceArn = cmdletContext.ServiceArn;
            }
            if (cmdletContext.StopCondition != null)
            {
                request.StopConditions = cmdletContext.StopCondition;
            }
            if (cmdletContext.TestTemplateArn != null)
            {
                request.TestTemplateArn = cmdletContext.TestTemplateArn;
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
        
        private Amazon.Resiliencehubv2.Model.CreateTestResponse CallAWSServiceOperation(IAmazonResiliencehubv2 client, Amazon.Resiliencehubv2.Model.CreateTestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub V2", "CreateTest");
            try
            {
                return client.CreateTestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LoggingConfiguration_CloudWatchLogGroupArn { get; set; }
            public System.String LoggingConfiguration_LogSchemaVersion { get; set; }
            public System.String LoggingConfiguration_S3BucketName { get; set; }
            public Dictionary<System.String, List<System.String>> Parameter { get; set; }
            public System.String RoleName { get; set; }
            public System.String ServiceArn { get; set; }
            public List<Amazon.Resiliencehubv2.Model.StopCondition> StopCondition { get; set; }
            public System.String TestTemplateArn { get; set; }
            public System.Func<Amazon.Resiliencehubv2.Model.CreateTestResponse, NewRH2TestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Test;
        }
        
    }
}
