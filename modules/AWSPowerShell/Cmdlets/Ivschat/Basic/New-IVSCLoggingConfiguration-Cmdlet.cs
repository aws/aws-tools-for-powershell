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
using Amazon.Ivschat;
using Amazon.Ivschat.Model;

namespace Amazon.PowerShell.Cmdlets.IVSC
{
    /// <summary>
    /// Creates a logging configuration that allows clients to store and record sent messages.
    /// </summary>
    [Cmdlet("New", "IVSCLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Ivschat.Model.CreateLoggingConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service Chat CreateLoggingConfiguration API operation.", Operation = new[] {"CreateLoggingConfiguration"}, SelectReturnType = typeof(Amazon.Ivschat.Model.CreateLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Ivschat.Model.CreateLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.Ivschat.Model.CreateLoggingConfigurationResponse object containing multiple properties."
    )]
    public partial class NewIVSCLoggingConfigurationCmdlet : AmazonIvschatClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon S3 bucket where chat activity will be logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter Firehose_DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Kinesis Firehose delivery stream where chat activity will be logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_Firehose_DeliveryStreamName")]
        public System.String Firehose_DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Cloudwatch Logs destination where chat activity will be logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_CloudWatchLogs_LogGroupName")]
        public System.String CloudWatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Logging-configuration name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to attach to the resource. Array of maps, each of the form <c>string:string (key:value)</c>.
        /// See <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/best-practices-and-strats.html">Best
        /// practices and strategies</a> in <i>Tagging Amazon Web Services Resources and Tag Editor</i>
        /// for details, including restrictions that apply to tags and "Tag naming limits and
        /// requirements"; Amazon IVS Chat has no constraints on tags beyond what is documented
        /// there.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Ivschat.Model.CreateLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Ivschat.Model.CreateLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IVSCLoggingConfiguration (CreateLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Ivschat.Model.CreateLoggingConfigurationResponse, NewIVSCLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchLogs_LogGroupName = this.CloudWatchLogs_LogGroupName;
            context.Firehose_DeliveryStreamName = this.Firehose_DeliveryStreamName;
            context.S3_BucketName = this.S3_BucketName;
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Ivschat.Model.CreateLoggingConfigurationRequest();
            
            
             // populate DestinationConfiguration
            request.DestinationConfiguration = new Amazon.Ivschat.Model.DestinationConfiguration();
            Amazon.Ivschat.Model.CloudWatchLogsDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestDestinationConfiguration_destinationConfiguration_CloudWatchLogsIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs = new Amazon.Ivschat.Model.CloudWatchLogsDestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName = null;
            if (cmdletContext.CloudWatchLogs_LogGroupName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName = cmdletContext.CloudWatchLogs_LogGroupName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs.LogGroupName = requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName;
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogsIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_CloudWatchLogsIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs != null)
            {
                request.DestinationConfiguration.CloudWatchLogs = requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs;
            }
            Amazon.Ivschat.Model.FirehoseDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_Firehose = null;
            
             // populate Firehose
            var requestDestinationConfiguration_destinationConfiguration_FirehoseIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_Firehose = new Amazon.Ivschat.Model.FirehoseDestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName = null;
            if (cmdletContext.Firehose_DeliveryStreamName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName = cmdletContext.Firehose_DeliveryStreamName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_Firehose.DeliveryStreamName = requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName;
                requestDestinationConfiguration_destinationConfiguration_FirehoseIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_Firehose should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_FirehoseIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_Firehose = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_Firehose != null)
            {
                request.DestinationConfiguration.Firehose = requestDestinationConfiguration_destinationConfiguration_Firehose;
            }
            Amazon.Ivschat.Model.S3DestinationConfiguration requestDestinationConfiguration_destinationConfiguration_S3 = null;
            
             // populate S3
            var requestDestinationConfiguration_destinationConfiguration_S3IsNull = true;
            requestDestinationConfiguration_destinationConfiguration_S3 = new Amazon.Ivschat.Model.S3DestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3.BucketName = requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName;
                requestDestinationConfiguration_destinationConfiguration_S3IsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_S3 should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_S3IsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_S3 = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3 != null)
            {
                request.DestinationConfiguration.S3 = requestDestinationConfiguration_destinationConfiguration_S3;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Ivschat.Model.CreateLoggingConfigurationResponse CallAWSServiceOperation(IAmazonIvschat client, Amazon.Ivschat.Model.CreateLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service Chat", "CreateLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateLoggingConfiguration(request);
                #elif CORECLR
                return client.CreateLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogs_LogGroupName { get; set; }
            public System.String Firehose_DeliveryStreamName { get; set; }
            public System.String S3_BucketName { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Ivschat.Model.CreateLoggingConfigurationResponse, NewIVSCLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
