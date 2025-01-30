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
using Amazon.Textract;
using Amazon.Textract.Model;

namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Starts the asynchronous analysis of an input document for relationships between detected
    /// items such as key-value pairs, tables, and selection elements.
    /// 
    ///  
    /// <para><c>StartDocumentAnalysis</c> can analyze text in documents that are in JPEG, PNG,
    /// TIFF, and PDF format. The documents are stored in an Amazon S3 bucket. Use <a>DocumentLocation</a>
    /// to specify the bucket name and file name of the document. 
    /// </para><para><c>StartDocumentAnalysis</c> returns a job identifier (<c>JobId</c>) that you use
    /// to get the results of the operation. When text analysis is finished, Amazon Textract
    /// publishes a completion status to the Amazon Simple Notification Service (Amazon SNS)
    /// topic that you specify in <c>NotificationChannel</c>. To get the results of the text
    /// analysis operation, first check that the status value published to the Amazon SNS
    /// topic is <c>SUCCEEDED</c>. If so, call <a>GetDocumentAnalysis</a>, and pass the job
    /// identifier (<c>JobId</c>) from the initial call to <c>StartDocumentAnalysis</c>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/textract/latest/dg/how-it-works-analyzing.html">Document
    /// Text Analysis</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "TXTDocumentAnalysis", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Textract StartDocumentAnalysis API operation.", Operation = new[] {"StartDocumentAnalysis"}, SelectReturnType = typeof(Amazon.Textract.Model.StartDocumentAnalysisResponse))]
    [AWSCmdletOutput("System.String or Amazon.Textract.Model.StartDocumentAnalysisResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Textract.Model.StartDocumentAnalysisResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTXTDocumentAnalysisCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdaptersConfig_Adapter
        /// <summary>
        /// <para>
        /// <para>A list of adapters to be used when analyzing the specified document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdaptersConfig_Adapters")]
        public Amazon.Textract.Model.Adapter[] AdaptersConfig_Adapter { get; set; }
        #endregion
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket. Note that the # character is not valid in the file name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentLocation_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The idempotent token that you use to identify the start request. If you use the same
        /// token with multiple <c>StartDocumentAnalysis</c> requests, the same <c>JobId</c> is
        /// returned. Use <c>ClientRequestToken</c> to prevent the same job from being accidentally
        /// started more than once. For more information, see <a href="https://docs.aws.amazon.com/textract/latest/dg/api-async.html">Calling
        /// Amazon Textract Asynchronous Operations</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter FeatureType
        /// <summary>
        /// <para>
        /// <para>A list of the types of analysis to perform. Add TABLES to the list to return information
        /// about the tables that are detected in the input document. Add FORMS to return detected
        /// form data. To perform both types of analysis, add TABLES and FORMS to <c>FeatureTypes</c>.
        /// All lines and words detected in the document are included in the response (including
        /// text that isn't related to the value of <c>FeatureTypes</c>). </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FeatureTypes")]
        public System.String[] FeatureType { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>An identifier that you specify that's included in the completion notification published
        /// to the Amazon SNS topic. For example, you can use <c>JobTag</c> to identify the type
        /// of document that the completion notification corresponds to (such as a tax form or
        /// a receipt).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobTag { get; set; }
        #endregion
        
        #region Parameter KMSKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key used to encrypt the inference results. This can be in either Key ID or
        /// Key Alias format. When a KMS key is provided, the KMS key will be used for server-side
        /// encryption of the objects in the customer bucket. When this parameter is not enabled,
        /// the result will be encrypted server side,using SSE-S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyId { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>The file name of the input document. Synchronous operations can use image files that
        /// are in JPEG or PNG format. Asynchronous operations also support PDF and TIFF format
        /// files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentLocation_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter QueriesConfig_Query
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueriesConfig_Queries")]
        public Amazon.Textract.Model.Query[] QueriesConfig_Query { get; set; }
        #endregion
        
        #region Parameter NotificationChannel_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that gives Amazon Textract publishing
        /// permissions to the Amazon SNS topic. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationChannel_RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the bucket your output will go to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the object key that the output will be saved to. When not enabled, the
        /// prefix will be “textract_output".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3Prefix { get; set; }
        #endregion
        
        #region Parameter NotificationChannel_SNSTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic that Amazon Textract posts the completion status to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationChannel_SNSTopicArn { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket has versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentLocation_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.StartDocumentAnalysisResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.StartDocumentAnalysisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FeatureType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FeatureType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FeatureType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TXTDocumentAnalysis (StartDocumentAnalysis)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.StartDocumentAnalysisResponse, StartTXTDocumentAnalysisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FeatureType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdaptersConfig_Adapter != null)
            {
                context.AdaptersConfig_Adapter = new List<Amazon.Textract.Model.Adapter>(this.AdaptersConfig_Adapter);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            if (this.FeatureType != null)
            {
                context.FeatureType = new List<System.String>(this.FeatureType);
            }
            #if MODULAR
            if (this.FeatureType == null && ParameterWasBound(nameof(this.FeatureType)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobTag = this.JobTag;
            context.KMSKeyId = this.KMSKeyId;
            context.NotificationChannel_RoleArn = this.NotificationChannel_RoleArn;
            context.NotificationChannel_SNSTopicArn = this.NotificationChannel_SNSTopicArn;
            context.OutputConfig_S3Bucket = this.OutputConfig_S3Bucket;
            context.OutputConfig_S3Prefix = this.OutputConfig_S3Prefix;
            if (this.QueriesConfig_Query != null)
            {
                context.QueriesConfig_Query = new List<Amazon.Textract.Model.Query>(this.QueriesConfig_Query);
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
            var request = new Amazon.Textract.Model.StartDocumentAnalysisRequest();
            
            
             // populate AdaptersConfig
            var requestAdaptersConfigIsNull = true;
            request.AdaptersConfig = new Amazon.Textract.Model.AdaptersConfig();
            List<Amazon.Textract.Model.Adapter> requestAdaptersConfig_adaptersConfig_Adapter = null;
            if (cmdletContext.AdaptersConfig_Adapter != null)
            {
                requestAdaptersConfig_adaptersConfig_Adapter = cmdletContext.AdaptersConfig_Adapter;
            }
            if (requestAdaptersConfig_adaptersConfig_Adapter != null)
            {
                request.AdaptersConfig.Adapters = requestAdaptersConfig_adaptersConfig_Adapter;
                requestAdaptersConfigIsNull = false;
            }
             // determine if request.AdaptersConfig should be set to null
            if (requestAdaptersConfigIsNull)
            {
                request.AdaptersConfig = null;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate DocumentLocation
            var requestDocumentLocationIsNull = true;
            request.DocumentLocation = new Amazon.Textract.Model.DocumentLocation();
            Amazon.Textract.Model.S3Object requestDocumentLocation_documentLocation_S3Object = null;
            
             // populate S3Object
            var requestDocumentLocation_documentLocation_S3ObjectIsNull = true;
            requestDocumentLocation_documentLocation_S3Object = new Amazon.Textract.Model.S3Object();
            System.String requestDocumentLocation_documentLocation_S3Object_s3Object_Bucket = null;
            if (cmdletContext.S3Object_Bucket != null)
            {
                requestDocumentLocation_documentLocation_S3Object_s3Object_Bucket = cmdletContext.S3Object_Bucket;
            }
            if (requestDocumentLocation_documentLocation_S3Object_s3Object_Bucket != null)
            {
                requestDocumentLocation_documentLocation_S3Object.Bucket = requestDocumentLocation_documentLocation_S3Object_s3Object_Bucket;
                requestDocumentLocation_documentLocation_S3ObjectIsNull = false;
            }
            System.String requestDocumentLocation_documentLocation_S3Object_s3Object_Name = null;
            if (cmdletContext.S3Object_Name != null)
            {
                requestDocumentLocation_documentLocation_S3Object_s3Object_Name = cmdletContext.S3Object_Name;
            }
            if (requestDocumentLocation_documentLocation_S3Object_s3Object_Name != null)
            {
                requestDocumentLocation_documentLocation_S3Object.Name = requestDocumentLocation_documentLocation_S3Object_s3Object_Name;
                requestDocumentLocation_documentLocation_S3ObjectIsNull = false;
            }
            System.String requestDocumentLocation_documentLocation_S3Object_s3Object_Version = null;
            if (cmdletContext.S3Object_Version != null)
            {
                requestDocumentLocation_documentLocation_S3Object_s3Object_Version = cmdletContext.S3Object_Version;
            }
            if (requestDocumentLocation_documentLocation_S3Object_s3Object_Version != null)
            {
                requestDocumentLocation_documentLocation_S3Object.Version = requestDocumentLocation_documentLocation_S3Object_s3Object_Version;
                requestDocumentLocation_documentLocation_S3ObjectIsNull = false;
            }
             // determine if requestDocumentLocation_documentLocation_S3Object should be set to null
            if (requestDocumentLocation_documentLocation_S3ObjectIsNull)
            {
                requestDocumentLocation_documentLocation_S3Object = null;
            }
            if (requestDocumentLocation_documentLocation_S3Object != null)
            {
                request.DocumentLocation.S3Object = requestDocumentLocation_documentLocation_S3Object;
                requestDocumentLocationIsNull = false;
            }
             // determine if request.DocumentLocation should be set to null
            if (requestDocumentLocationIsNull)
            {
                request.DocumentLocation = null;
            }
            if (cmdletContext.FeatureType != null)
            {
                request.FeatureTypes = cmdletContext.FeatureType;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTag = cmdletContext.JobTag;
            }
            if (cmdletContext.KMSKeyId != null)
            {
                request.KMSKeyId = cmdletContext.KMSKeyId;
            }
            
             // populate NotificationChannel
            var requestNotificationChannelIsNull = true;
            request.NotificationChannel = new Amazon.Textract.Model.NotificationChannel();
            System.String requestNotificationChannel_notificationChannel_RoleArn = null;
            if (cmdletContext.NotificationChannel_RoleArn != null)
            {
                requestNotificationChannel_notificationChannel_RoleArn = cmdletContext.NotificationChannel_RoleArn;
            }
            if (requestNotificationChannel_notificationChannel_RoleArn != null)
            {
                request.NotificationChannel.RoleArn = requestNotificationChannel_notificationChannel_RoleArn;
                requestNotificationChannelIsNull = false;
            }
            System.String requestNotificationChannel_notificationChannel_SNSTopicArn = null;
            if (cmdletContext.NotificationChannel_SNSTopicArn != null)
            {
                requestNotificationChannel_notificationChannel_SNSTopicArn = cmdletContext.NotificationChannel_SNSTopicArn;
            }
            if (requestNotificationChannel_notificationChannel_SNSTopicArn != null)
            {
                request.NotificationChannel.SNSTopicArn = requestNotificationChannel_notificationChannel_SNSTopicArn;
                requestNotificationChannelIsNull = false;
            }
             // determine if request.NotificationChannel should be set to null
            if (requestNotificationChannelIsNull)
            {
                request.NotificationChannel = null;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.Textract.Model.OutputConfig();
            System.String requestOutputConfig_outputConfig_S3Bucket = null;
            if (cmdletContext.OutputConfig_S3Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Bucket = cmdletContext.OutputConfig_S3Bucket;
            }
            if (requestOutputConfig_outputConfig_S3Bucket != null)
            {
                request.OutputConfig.S3Bucket = requestOutputConfig_outputConfig_S3Bucket;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3Prefix = null;
            if (cmdletContext.OutputConfig_S3Prefix != null)
            {
                requestOutputConfig_outputConfig_S3Prefix = cmdletContext.OutputConfig_S3Prefix;
            }
            if (requestOutputConfig_outputConfig_S3Prefix != null)
            {
                request.OutputConfig.S3Prefix = requestOutputConfig_outputConfig_S3Prefix;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            
             // populate QueriesConfig
            var requestQueriesConfigIsNull = true;
            request.QueriesConfig = new Amazon.Textract.Model.QueriesConfig();
            List<Amazon.Textract.Model.Query> requestQueriesConfig_queriesConfig_Query = null;
            if (cmdletContext.QueriesConfig_Query != null)
            {
                requestQueriesConfig_queriesConfig_Query = cmdletContext.QueriesConfig_Query;
            }
            if (requestQueriesConfig_queriesConfig_Query != null)
            {
                request.QueriesConfig.Queries = requestQueriesConfig_queriesConfig_Query;
                requestQueriesConfigIsNull = false;
            }
             // determine if request.QueriesConfig should be set to null
            if (requestQueriesConfigIsNull)
            {
                request.QueriesConfig = null;
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
        
        private Amazon.Textract.Model.StartDocumentAnalysisResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.StartDocumentAnalysisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "StartDocumentAnalysis");
            try
            {
                #if DESKTOP
                return client.StartDocumentAnalysis(request);
                #elif CORECLR
                return client.StartDocumentAnalysisAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Textract.Model.Adapter> AdaptersConfig_Adapter { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public List<System.String> FeatureType { get; set; }
            public System.String JobTag { get; set; }
            public System.String KMSKeyId { get; set; }
            public System.String NotificationChannel_RoleArn { get; set; }
            public System.String NotificationChannel_SNSTopicArn { get; set; }
            public System.String OutputConfig_S3Bucket { get; set; }
            public System.String OutputConfig_S3Prefix { get; set; }
            public List<Amazon.Textract.Model.Query> QueriesConfig_Query { get; set; }
            public System.Func<Amazon.Textract.Model.StartDocumentAnalysisResponse, StartTXTDocumentAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
