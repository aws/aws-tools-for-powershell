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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Adds an Amazon CloudWatch log stream to monitor application configuration errors.
    /// </summary>
    [Cmdlet("Add", "KINA2ApplicationCloudWatchLoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 AddApplicationCloudWatchLoggingOption API operation.", Operation = new[] {"AddApplicationCloudWatchLoggingOption"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse object containing multiple properties."
    )]
    public partial class AddKINA2ApplicationCloudWatchLoggingOptionCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The Kinesis Data Analytics application name.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter ConditionalToken
        /// <summary>
        /// <para>
        /// <para>A value you use to implement strong concurrency for application updates. You must
        /// provide the <c>CurrentApplicationVersionId</c> or the <c>ConditionalToken</c>. You
        /// get the application's current <c>ConditionalToken</c> using <a>DescribeApplication</a>.
        /// For better concurrency support, use the <c>ConditionalToken</c> parameter instead
        /// of <c>CurrentApplicationVersionId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConditionalToken { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the SQL-based Kinesis Data Analytics application. You must provide
        /// the <c>CurrentApplicationVersionId</c> or the <c>ConditionalToken</c>.You can retrieve
        /// the application version ID using <a>DescribeApplication</a>. For better concurrency
        /// support, use the <c>ConditionalToken</c> parameter instead of <c>CurrentApplicationVersionId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption_LogStreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the CloudWatch log to receive application messages.</para>
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
        public System.String CloudWatchLoggingOption_LogStreamARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINA2ApplicationCloudWatchLoggingOption (AddApplicationCloudWatchLoggingOption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse, AddKINA2ApplicationCloudWatchLoggingOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLoggingOption_LogStreamARN = this.CloudWatchLoggingOption_LogStreamARN;
            #if MODULAR
            if (this.CloudWatchLoggingOption_LogStreamARN == null && ParameterWasBound(nameof(this.CloudWatchLoggingOption_LogStreamARN)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudWatchLoggingOption_LogStreamARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConditionalToken = this.ConditionalToken;
            context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            
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
            var request = new Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate CloudWatchLoggingOption
            var requestCloudWatchLoggingOptionIsNull = true;
            request.CloudWatchLoggingOption = new Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOption();
            System.String requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN = null;
            if (cmdletContext.CloudWatchLoggingOption_LogStreamARN != null)
            {
                requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN = cmdletContext.CloudWatchLoggingOption_LogStreamARN;
            }
            if (requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN != null)
            {
                request.CloudWatchLoggingOption.LogStreamARN = requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN;
                requestCloudWatchLoggingOptionIsNull = false;
            }
             // determine if request.CloudWatchLoggingOption should be set to null
            if (requestCloudWatchLoggingOptionIsNull)
            {
                request.CloudWatchLoggingOption = null;
            }
            if (cmdletContext.ConditionalToken != null)
            {
                request.ConditionalToken = cmdletContext.ConditionalToken;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
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
        
        private Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "AddApplicationCloudWatchLoggingOption");
            try
            {
                #if DESKTOP
                return client.AddApplicationCloudWatchLoggingOption(request);
                #elif CORECLR
                return client.AddApplicationCloudWatchLoggingOptionAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.String CloudWatchLoggingOption_LogStreamARN { get; set; }
            public System.String ConditionalToken { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.AddApplicationCloudWatchLoggingOptionResponse, AddKINA2ApplicationCloudWatchLoggingOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
