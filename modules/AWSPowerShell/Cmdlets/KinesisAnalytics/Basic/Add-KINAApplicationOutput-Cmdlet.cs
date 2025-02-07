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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// <note><para>
    /// This documentation is for version 1 of the Amazon Kinesis Data Analytics API, which
    /// only supports SQL applications. Version 2 of the API supports SQL and Java applications.
    /// For more information about version 2, see <a href="/kinesisanalytics/latest/apiv2/Welcome.html">Amazon
    /// Kinesis Data Analytics API V2 Documentation</a>.
    /// </para></note><para>
    /// Adds an external destination to your Amazon Kinesis Analytics application.
    /// </para><para>
    /// If you want Amazon Kinesis Analytics to deliver data from an in-application stream
    /// within your application to an external destination (such as an Amazon Kinesis stream,
    /// an Amazon Kinesis Firehose delivery stream, or an AWS Lambda function), you add the
    /// relevant configuration to your application using this operation. You can configure
    /// one or more outputs for your application. Each output configuration maps an in-application
    /// stream and an external destination.
    /// </para><para>
    ///  You can use one of the output configurations to deliver data from your in-application
    /// error stream to an external destination so that you can analyze the errors. For more
    /// information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-output.html">Understanding
    /// Application Output (Destination)</a>. 
    /// </para><para>
    ///  Any configuration update, including adding a streaming source using this operation,
    /// results in a new version of the application. You can use the <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/API_DescribeApplication.html">DescribeApplication</a>
    /// operation to find the current application version.
    /// </para><para>
    /// For the limits on the number of application inputs and outputs you can configure,
    /// see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/limits.html">Limits</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <c>kinesisanalytics:AddApplicationOutput</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "KINAApplicationOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics AddApplicationOutput API operation.", Operation = new[] {"AddApplicationOutput"}, SelectReturnType = typeof(Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddKINAApplicationOutputCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of the application to which you want to add the output configuration.</para>
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
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>Version of the application to which you want to add the output configuration. You
        /// can use the <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/API_DescribeApplication.html">DescribeApplication</a>
        /// operation to get the current application version. If the version specified is not
        /// the current version, the <c>ConcurrentModificationException</c> is returned. </para>
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
        
        #region Parameter Output_Name
        /// <summary>
        /// <para>
        /// <para>Name of the in-application stream.</para>
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
        public System.String Output_Name { get; set; }
        #endregion
        
        #region Parameter DestinationSchema_RecordFormatType
        /// <summary>
        /// <para>
        /// <para>Specifies the format of the records on the output stream.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Output_DestinationSchema_RecordFormatType")]
        [AWSConstantClassSource("Amazon.KinesisAnalytics.RecordFormatType")]
        public Amazon.KinesisAnalytics.RecordFormatType DestinationSchema_RecordFormatType { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseOutput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the destination Amazon Kinesis Firehose delivery stream to write to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_KinesisFirehoseOutput_ResourceARN")]
        public System.String KinesisFirehoseOutput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamsOutput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the destination Amazon Kinesis stream to write to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_KinesisStreamsOutput_ResourceARN")]
        public System.String KinesisStreamsOutput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter LambdaOutput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the destination Lambda function to write to.</para><note><para>To specify an earlier version of the Lambda function than the latest, include the
        /// Lambda function version in the Lambda function ARN. For more information about Lambda
        /// ARNs, see <a href="/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-lambda">Example
        /// ARNs: AWS Lambda</a></para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_LambdaOutput_ResourceARN")]
        public System.String LambdaOutput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseOutput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to write to the destination
        /// stream on your behalf. You need to grant the necessary permissions to this role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_KinesisFirehoseOutput_RoleARN")]
        public System.String KinesisFirehoseOutput_RoleARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamsOutput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to write to the destination
        /// stream on your behalf. You need to grant the necessary permissions to this role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_KinesisStreamsOutput_RoleARN")]
        public System.String KinesisStreamsOutput_RoleARN { get; set; }
        #endregion
        
        #region Parameter LambdaOutput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to write to the destination
        /// function on your behalf. You need to grant the necessary permissions to this role.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_LambdaOutput_RoleARN")]
        public System.String LambdaOutput_RoleARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINAApplicationOutput (AddApplicationOutput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse, AddKINAApplicationOutputCmdlet>(Select) ??
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
            context.DestinationSchema_RecordFormatType = this.DestinationSchema_RecordFormatType;
            #if MODULAR
            if (this.DestinationSchema_RecordFormatType == null && ParameterWasBound(nameof(this.DestinationSchema_RecordFormatType)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationSchema_RecordFormatType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KinesisFirehoseOutput_ResourceARN = this.KinesisFirehoseOutput_ResourceARN;
            context.KinesisFirehoseOutput_RoleARN = this.KinesisFirehoseOutput_RoleARN;
            context.KinesisStreamsOutput_ResourceARN = this.KinesisStreamsOutput_ResourceARN;
            context.KinesisStreamsOutput_RoleARN = this.KinesisStreamsOutput_RoleARN;
            context.LambdaOutput_ResourceARN = this.LambdaOutput_ResourceARN;
            context.LambdaOutput_RoleARN = this.LambdaOutput_RoleARN;
            context.Output_Name = this.Output_Name;
            #if MODULAR
            if (this.Output_Name == null && ParameterWasBound(nameof(this.Output_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Output_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalytics.Model.AddApplicationOutputRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            
             // populate Output
            var requestOutputIsNull = true;
            request.Output = new Amazon.KinesisAnalytics.Model.Output();
            System.String requestOutput_output_Name = null;
            if (cmdletContext.Output_Name != null)
            {
                requestOutput_output_Name = cmdletContext.Output_Name;
            }
            if (requestOutput_output_Name != null)
            {
                request.Output.Name = requestOutput_output_Name;
                requestOutputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.DestinationSchema requestOutput_output_DestinationSchema = null;
            
             // populate DestinationSchema
            var requestOutput_output_DestinationSchemaIsNull = true;
            requestOutput_output_DestinationSchema = new Amazon.KinesisAnalytics.Model.DestinationSchema();
            Amazon.KinesisAnalytics.RecordFormatType requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType = null;
            if (cmdletContext.DestinationSchema_RecordFormatType != null)
            {
                requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType = cmdletContext.DestinationSchema_RecordFormatType;
            }
            if (requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType != null)
            {
                requestOutput_output_DestinationSchema.RecordFormatType = requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType;
                requestOutput_output_DestinationSchemaIsNull = false;
            }
             // determine if requestOutput_output_DestinationSchema should be set to null
            if (requestOutput_output_DestinationSchemaIsNull)
            {
                requestOutput_output_DestinationSchema = null;
            }
            if (requestOutput_output_DestinationSchema != null)
            {
                request.Output.DestinationSchema = requestOutput_output_DestinationSchema;
                requestOutputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.KinesisFirehoseOutput requestOutput_output_KinesisFirehoseOutput = null;
            
             // populate KinesisFirehoseOutput
            var requestOutput_output_KinesisFirehoseOutputIsNull = true;
            requestOutput_output_KinesisFirehoseOutput = new Amazon.KinesisAnalytics.Model.KinesisFirehoseOutput();
            System.String requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN = null;
            if (cmdletContext.KinesisFirehoseOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN = cmdletContext.KinesisFirehoseOutput_ResourceARN;
            }
            if (requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput.ResourceARN = requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN;
                requestOutput_output_KinesisFirehoseOutputIsNull = false;
            }
            System.String requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN = null;
            if (cmdletContext.KinesisFirehoseOutput_RoleARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN = cmdletContext.KinesisFirehoseOutput_RoleARN;
            }
            if (requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput.RoleARN = requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN;
                requestOutput_output_KinesisFirehoseOutputIsNull = false;
            }
             // determine if requestOutput_output_KinesisFirehoseOutput should be set to null
            if (requestOutput_output_KinesisFirehoseOutputIsNull)
            {
                requestOutput_output_KinesisFirehoseOutput = null;
            }
            if (requestOutput_output_KinesisFirehoseOutput != null)
            {
                request.Output.KinesisFirehoseOutput = requestOutput_output_KinesisFirehoseOutput;
                requestOutputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.KinesisStreamsOutput requestOutput_output_KinesisStreamsOutput = null;
            
             // populate KinesisStreamsOutput
            var requestOutput_output_KinesisStreamsOutputIsNull = true;
            requestOutput_output_KinesisStreamsOutput = new Amazon.KinesisAnalytics.Model.KinesisStreamsOutput();
            System.String requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN = null;
            if (cmdletContext.KinesisStreamsOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN = cmdletContext.KinesisStreamsOutput_ResourceARN;
            }
            if (requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisStreamsOutput.ResourceARN = requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN;
                requestOutput_output_KinesisStreamsOutputIsNull = false;
            }
            System.String requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN = null;
            if (cmdletContext.KinesisStreamsOutput_RoleARN != null)
            {
                requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN = cmdletContext.KinesisStreamsOutput_RoleARN;
            }
            if (requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN != null)
            {
                requestOutput_output_KinesisStreamsOutput.RoleARN = requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN;
                requestOutput_output_KinesisStreamsOutputIsNull = false;
            }
             // determine if requestOutput_output_KinesisStreamsOutput should be set to null
            if (requestOutput_output_KinesisStreamsOutputIsNull)
            {
                requestOutput_output_KinesisStreamsOutput = null;
            }
            if (requestOutput_output_KinesisStreamsOutput != null)
            {
                request.Output.KinesisStreamsOutput = requestOutput_output_KinesisStreamsOutput;
                requestOutputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.LambdaOutput requestOutput_output_LambdaOutput = null;
            
             // populate LambdaOutput
            var requestOutput_output_LambdaOutputIsNull = true;
            requestOutput_output_LambdaOutput = new Amazon.KinesisAnalytics.Model.LambdaOutput();
            System.String requestOutput_output_LambdaOutput_lambdaOutput_ResourceARN = null;
            if (cmdletContext.LambdaOutput_ResourceARN != null)
            {
                requestOutput_output_LambdaOutput_lambdaOutput_ResourceARN = cmdletContext.LambdaOutput_ResourceARN;
            }
            if (requestOutput_output_LambdaOutput_lambdaOutput_ResourceARN != null)
            {
                requestOutput_output_LambdaOutput.ResourceARN = requestOutput_output_LambdaOutput_lambdaOutput_ResourceARN;
                requestOutput_output_LambdaOutputIsNull = false;
            }
            System.String requestOutput_output_LambdaOutput_lambdaOutput_RoleARN = null;
            if (cmdletContext.LambdaOutput_RoleARN != null)
            {
                requestOutput_output_LambdaOutput_lambdaOutput_RoleARN = cmdletContext.LambdaOutput_RoleARN;
            }
            if (requestOutput_output_LambdaOutput_lambdaOutput_RoleARN != null)
            {
                requestOutput_output_LambdaOutput.RoleARN = requestOutput_output_LambdaOutput_lambdaOutput_RoleARN;
                requestOutput_output_LambdaOutputIsNull = false;
            }
             // determine if requestOutput_output_LambdaOutput should be set to null
            if (requestOutput_output_LambdaOutputIsNull)
            {
                requestOutput_output_LambdaOutput = null;
            }
            if (requestOutput_output_LambdaOutput != null)
            {
                request.Output.LambdaOutput = requestOutput_output_LambdaOutput;
                requestOutputIsNull = false;
            }
             // determine if request.Output should be set to null
            if (requestOutputIsNull)
            {
                request.Output = null;
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
        
        private Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.AddApplicationOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "AddApplicationOutput");
            try
            {
                #if DESKTOP
                return client.AddApplicationOutput(request);
                #elif CORECLR
                return client.AddApplicationOutputAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public Amazon.KinesisAnalytics.RecordFormatType DestinationSchema_RecordFormatType { get; set; }
            public System.String KinesisFirehoseOutput_ResourceARN { get; set; }
            public System.String KinesisFirehoseOutput_RoleARN { get; set; }
            public System.String KinesisStreamsOutput_ResourceARN { get; set; }
            public System.String KinesisStreamsOutput_RoleARN { get; set; }
            public System.String LambdaOutput_ResourceARN { get; set; }
            public System.String LambdaOutput_RoleARN { get; set; }
            public System.String Output_Name { get; set; }
            public System.Func<Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse, AddKINAApplicationOutputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
