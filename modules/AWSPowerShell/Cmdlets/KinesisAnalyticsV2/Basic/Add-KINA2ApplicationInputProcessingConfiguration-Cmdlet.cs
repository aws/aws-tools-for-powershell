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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Adds an <a>InputProcessingConfiguration</a> to a SQL-based Kinesis Data Analytics
    /// application. An input processor pre-processes records on the input stream before the
    /// application's SQL code executes. Currently, the only input processor available is
    /// <a href="https://docs.aws.amazon.com/lambda/">Amazon Lambda</a>.
    /// </summary>
    [Cmdlet("Add", "KINA2ApplicationInputProcessingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 AddApplicationInputProcessingConfiguration API operation.", Operation = new[] {"AddApplicationInputProcessingConfiguration"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse object containing multiple properties."
    )]
    public partial class AddKINA2ApplicationInputProcessingConfigurationCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application to which you want to add the input processing configuration.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The version of the application to which you want to add the input processing configuration.
        /// You can use the <a>DescribeApplication</a> operation to get the current application
        /// version. If the version specified is not the current version, the <c>ConcurrentModificationException</c>
        /// is returned.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter InputId
        /// <summary>
        /// <para>
        /// <para>The ID of the input configuration to add the input processing configuration to. You
        /// can get a list of the input IDs for an application using the <a>DescribeApplication</a>
        /// operation.</para>
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
        public System.String InputId { get; set; }
        #endregion
        
        #region Parameter InputLambdaProcessor_ResourceARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Lambda function that operates on records in the stream.</para><note><para>To specify an earlier version of the Lambda function than the latest, include the
        /// Lambda function version in the Lambda function ARN. For more information about Lambda
        /// ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-lambda">Example
        /// ARNs: Amazon Lambda</a></para></note>
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
        [Alias("InputProcessingConfiguration_InputLambdaProcessor_ResourceARN")]
        public System.String InputLambdaProcessor_ResourceARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InputId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINA2ApplicationInputProcessingConfiguration (AddApplicationInputProcessingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse, AddKINA2ApplicationInputProcessingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            #if MODULAR
            if (this.CurrentApplicationVersionId == null && ParameterWasBound(nameof(this.CurrentApplicationVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentApplicationVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputId = this.InputId;
            #if MODULAR
            if (this.InputId == null && ParameterWasBound(nameof(this.InputId)))
            {
                WriteWarning("You are passing $null as a value for parameter InputId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputLambdaProcessor_ResourceARN = this.InputLambdaProcessor_ResourceARN;
            #if MODULAR
            if (this.InputLambdaProcessor_ResourceARN == null && ParameterWasBound(nameof(this.InputLambdaProcessor_ResourceARN)))
            {
                WriteWarning("You are passing $null as a value for parameter InputLambdaProcessor_ResourceARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            if (cmdletContext.InputId != null)
            {
                request.InputId = cmdletContext.InputId;
            }
            
             // populate InputProcessingConfiguration
            var requestInputProcessingConfigurationIsNull = true;
            request.InputProcessingConfiguration = new Amazon.KinesisAnalyticsV2.Model.InputProcessingConfiguration();
            Amazon.KinesisAnalyticsV2.Model.InputLambdaProcessor requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = null;
            
             // populate InputLambdaProcessor
            var requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull = true;
            requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = new Amazon.KinesisAnalyticsV2.Model.InputLambdaProcessor();
            System.String requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = null;
            if (cmdletContext.InputLambdaProcessor_ResourceARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = cmdletContext.InputLambdaProcessor_ResourceARN;
            }
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor.ResourceARN = requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN;
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull = false;
            }
             // determine if requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor should be set to null
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = null;
            }
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor != null)
            {
                request.InputProcessingConfiguration.InputLambdaProcessor = requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor;
                requestInputProcessingConfigurationIsNull = false;
            }
             // determine if request.InputProcessingConfiguration should be set to null
            if (requestInputProcessingConfigurationIsNull)
            {
                request.InputProcessingConfiguration = null;
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
        
        private Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "AddApplicationInputProcessingConfiguration");
            try
            {
                return client.AddApplicationInputProcessingConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public System.String InputId { get; set; }
            public System.String InputLambdaProcessor_ResourceARN { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse, AddKINA2ApplicationInputProcessingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
