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
using Amazon.Textract;
using Amazon.Textract.Model;

namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Starts asynchronous analysis of an input document for relationships between detected
    /// items such as key and value pairs, tables, and selection elements.
    /// 
    ///  
    /// <para><code>StartDocumentAnalysis</code> can analyze text in documents that are in JPG,
    /// PNG, and PDF format. The documents are stored in an Amazon S3 bucket. Use <a>DocumentLocation</a>
    /// to specify the bucket name and file name of the document. 
    /// </para><para><code>StartDocumentAnalysis</code> returns a job identifier (<code>JobId</code>)
    /// that you use to get the results of the operation. When text analysis is finished,
    /// Amazon Textract publishes a completion status to the Amazon Simple Notification Service
    /// (Amazon SNS) topic that you specify in <code>NotificationChannel</code>. To get the
    /// results of the text analysis operation, first check that the status value published
    /// to the Amazon SNS topic is <code>SUCCEEDED</code>. If so, call <a>GetDocumentAnalysis</a>,
    /// and pass the job identifier (<code>JobId</code>) from the initial call to <code>StartDocumentAnalysis</code>.
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
        "The service call response (type Amazon.Textract.Model.StartDocumentAnalysisResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartTXTDocumentAnalysisCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket.</para>
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
        /// token with multiple <code>StartDocumentAnalysis</code> requests, the same <code>JobId</code>
        /// is returned. Use <code>ClientRequestToken</code> to prevent the same job from being
        /// accidentally started more than once. </para>
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
        /// fields and the associated text. To perform both types of analysis, add TABLES and
        /// FORMS to <code>FeatureTypes</code>. All selectable elements (<code>SELECTION_ELEMENT</code>)
        /// that are detected are returned, whatever the value of <code>FeatureTypes</code>. </para>
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
        /// <para>An identifier you specify that's included in the completion notification that's published
        /// to the Amazon SNS topic. For example, you can use <code>JobTag</code> to identify
        /// the type of document, such as a tax form or a receipt, that the completion notification
        /// corresponds to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobTag { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>The file name of the input document. It must be an image file (.JPG or .PNG format).
        /// Asynchronous operations also support PDF files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentLocation_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
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
            context.NotificationChannel_RoleArn = this.NotificationChannel_RoleArn;
            context.NotificationChannel_SNSTopicArn = this.NotificationChannel_SNSTopicArn;
            
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
            public System.String ClientRequestToken { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public List<System.String> FeatureType { get; set; }
            public System.String JobTag { get; set; }
            public System.String NotificationChannel_RoleArn { get; set; }
            public System.String NotificationChannel_SNSTopicArn { get; set; }
            public System.Func<Amazon.Textract.Model.StartDocumentAnalysisResponse, StartTXTDocumentAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
