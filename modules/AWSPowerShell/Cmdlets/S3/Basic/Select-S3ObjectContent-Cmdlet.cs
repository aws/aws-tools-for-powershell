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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// This action filters the contents of an Amazon S3 object based on a simple structured
    /// query language (SQL) statement. In the request, along with the SQL expression, you
    /// must also specify a data serialization format (JSON, CSV, or Apache Parquet) of the
    /// object. Amazon S3 uses this format to parse object data into records, and returns
    /// only records that match the specified SQL expression. You must also specify the data
    /// serialization format for the response.
    /// 
    ///  
    /// <para>
    /// This action is not supported by Amazon S3 on Outposts.
    /// </para><para>
    /// For more information about Amazon S3 Select, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/selecting-content-from-objects.html">Selecting
    /// Content from Objects</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-glacier-select-sql-reference-select.html">SELECT
    /// Command</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><dl><dt>Permissions</dt><dd><para>
    /// You must have <code>s3:GetObject</code> permission for this operation. Amazon S3 Select
    /// does not support anonymous access. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-with-s3-actions.html">Specifying
    /// Permissions in a Policy</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></dd><dt>Object Data Formats</dt><dd><para>
    /// You can use Amazon S3 Select to query objects that have the following format properties:
    /// </para><ul><li><para><i>CSV, JSON, and Parquet</i> - Objects must be in CSV, JSON, or Parquet format.
    /// </para></li><li><para><i>UTF-8</i> - UTF-8 is the only encoding type Amazon S3 Select supports.
    /// </para></li><li><para><i>GZIP or BZIP2</i> - CSV and JSON files can be compressed using GZIP or BZIP2.
    /// GZIP and BZIP2 are the only compression formats that Amazon S3 Select supports for
    /// CSV and JSON files. Amazon S3 Select supports columnar compression for Parquet using
    /// GZIP or Snappy. Amazon S3 Select does not support whole-object compression for Parquet
    /// objects.
    /// </para></li><li><para><i>Server-side encryption</i> - Amazon S3 Select supports querying objects that are
    /// protected with server-side encryption.
    /// </para><para>
    /// For objects that are encrypted with customer-provided encryption keys (SSE-C), you
    /// must use HTTPS, and you must use the headers that are documented in the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a>.
    /// For more information about SSE-C, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/ServerSideEncryptionCustomerKeys.html">Server-Side
    /// Encryption (Using Customer-Provided Encryption Keys)</a> in the <i>Amazon S3 User
    /// Guide</i>.
    /// </para><para>
    /// For objects that are encrypted with Amazon S3 managed keys (SSE-S3) and Amazon Web
    /// Services KMS keys (SSE-KMS), server-side encryption is handled transparently, so you
    /// don't need to specify anything. For more information about server-side encryption,
    /// including SSE-S3 and SSE-KMS, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/serv-side-encryption.html">Protecting
    /// Data Using Server-Side Encryption</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></li></ul></dd><dt>Working with the Response Body</dt><dd><para>
    /// Given the response size is unknown, Amazon S3 Select streams the response as a series
    /// of messages and includes a <code>Transfer-Encoding</code> header with <code>chunked</code>
    /// as its value in the response. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/RESTSelectObjectAppendix.html">Appendix:
    /// SelectObjectContent Response</a>.
    /// </para></dd><dt>GetObject Support</dt><dd><para>
    /// The <code>SelectObjectContent</code> action does not support the following <code>GetObject</code>
    /// functionality. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a>.
    /// </para><ul><li><para><code>Range</code>: Although you can specify a scan range for an Amazon S3 Select
    /// request (see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_SelectObjectContent.html#AmazonS3-SelectObjectContent-request-ScanRange">SelectObjectContentRequest
    /// - ScanRange</a> in the request parameters), you cannot specify the range of bytes
    /// of an object to return. 
    /// </para></li><li><para>
    /// The <code>GLACIER</code>, <code>DEEP_ARCHIVE</code>, and <code>REDUCED_REDUNDANCY</code>
    /// storage classes, or the <code>ARCHIVE_ACCESS</code> and <code>DEEP_ARCHIVE_ACCESS</code>
    /// access tiers of the <code>INTELLIGENT_TIERING</code> storage class: You cannot query
    /// objects in the <code>GLACIER</code>, <code>DEEP_ARCHIVE</code>, or <code>REDUCED_REDUNDANCY</code>
    /// storage classes, nor objects in the <code>ARCHIVE_ACCESS</code> or <code>DEEP_ARCHIVE_ACCESS</code>
    /// access tiers of the <code>INTELLIGENT_TIERING</code> storage class. For more information
    /// about storage classes, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/storage-class-intro.html">Using
    /// Amazon S3 storage classes</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></li></ul></dd><dt>Special Errors</dt><dd><para>
    /// For a list of special errors for this operation, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/ErrorResponses.html#SelectObjectContentErrorCodeList">List
    /// of SELECT Object Content Error Codes</a></para></dd></dl><para>
    /// The following operations are related to <code>SelectObjectContent</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketLifecycleConfiguration.html">GetBucketLifecycleConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketLifecycleConfiguration.html">PutBucketLifecycleConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("Select", "S3ObjectContent")]
    [OutputType("Amazon.S3.Model.ISelectObjectContentEventStream")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) SelectObjectContent API operation.", Operation = new[] {"SelectObjectContent"}, SelectReturnType = typeof(Amazon.S3.Model.SelectObjectContentResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.ISelectObjectContentEventStream or Amazon.S3.Model.SelectObjectContentResponse",
        "This cmdlet returns an Amazon.S3.Model.ISelectObjectContentEventStream object.",
        "The service call response (type Amazon.S3.Model.SelectObjectContentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SelectS3ObjectContentCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The S3 Bucket name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ScanRange_End
        /// <summary>
        /// <para>
        /// Specifies the end of the byte range. This parameter is optional. Valid values: non-negative integers. The default value is one less than the size of the object being queried.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ScanRange_End { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account ID of the expected bucket owner. 
        /// If the bucket is owned by a different account, the request will fail with an HTTP 403 (Access Denied) error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Expression
        /// <summary>
        /// <para>
        /// The expression that is used to query the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Expression { get; set; }
        #endregion
        
        #region Parameter ExpressionType
        /// <summary>
        /// <para>
        /// The type of the provided expression (e.g., SQL).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ExpressionType")]
        public Amazon.S3.ExpressionType ExpressionType { get; set; }
        #endregion
        
        #region Parameter InputSerialization
        /// <summary>
        /// <para>
        /// Describes the format of the data in the object that is being queried.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.Model.InputSerialization InputSerialization { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// The Object Key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter OutputSerialization
        /// <summary>
        /// <para>
        /// Describes the format of the data that you want Amazon S3 to return in response.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.Model.OutputSerialization OutputSerialization { get; set; }
        #endregion
        
        #region Parameter RequestProgress
        /// <summary>
        /// <para>
        /// Specifies if periodic request progress information should be enabled.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RequestProgress { get; set; }
        #endregion
        
        #region Parameter ServerSideCustomerEncryptionMethod
        /// <summary>
        /// <para>
        /// The SSE Algorithm used to encrypt the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideCustomerEncryptionMethod { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// <para>
        /// The SSE Customer Key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// <para>
        /// The SSE Customer Key MD5.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion
        
        #region Parameter ScanRange_Start
        /// <summary>
        /// <para>
        /// Specifies the start of the byte range. This parameter is optional. Valid values: non-negative integers. The default value is 0.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ScanRange_Start { get; set; }
        #endregion
        
        #region Parameter Bucket
        /// <summary>
        /// <para>
        /// The S3 Bucket.
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use BucketName instead")]
        public System.String Bucket { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Payload'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.SelectObjectContentResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.SelectObjectContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Payload";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Expression parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Expression' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Expression' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.SelectObjectContentResponse, SelectS3ObjectContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Expression;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Bucket = this.Bucket;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.Key = this.Key;
            context.ServerSideCustomerEncryptionMethod = this.ServerSideCustomerEncryptionMethod;
            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;
            context.Expression = this.Expression;
            context.ExpressionType = this.ExpressionType;
            context.RequestProgress = this.RequestProgress;
            context.InputSerialization = this.InputSerialization;
            context.OutputSerialization = this.OutputSerialization;
            context.ScanRange_Start = this.ScanRange_Start;
            context.ScanRange_End = this.ScanRange_End;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            
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
            var request = new Amazon.S3.Model.SelectObjectContentRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Bucket != null)
            {
                request.Bucket = cmdletContext.Bucket;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.ServerSideCustomerEncryptionMethod != null)
            {
                request.ServerSideCustomerEncryptionMethod = cmdletContext.ServerSideCustomerEncryptionMethod;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKey != null)
            {
                request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5 != null)
            {
                request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
            }
            if (cmdletContext.Expression != null)
            {
                request.Expression = cmdletContext.Expression;
            }
            if (cmdletContext.ExpressionType != null)
            {
                request.ExpressionType = cmdletContext.ExpressionType;
            }
            if (cmdletContext.RequestProgress != null)
            {
                request.RequestProgress = cmdletContext.RequestProgress.Value;
            }
            if (cmdletContext.InputSerialization != null)
            {
                request.InputSerialization = cmdletContext.InputSerialization;
            }
            if (cmdletContext.OutputSerialization != null)
            {
                request.OutputSerialization = cmdletContext.OutputSerialization;
            }
            
             // populate ScanRange
            var requestScanRangeIsNull = true;
            request.ScanRange = new Amazon.S3.Model.ScanRange();
            System.Int64? requestScanRange_scanRange_Start = null;
            if (cmdletContext.ScanRange_Start != null)
            {
                requestScanRange_scanRange_Start = cmdletContext.ScanRange_Start.Value;
            }
            if (requestScanRange_scanRange_Start != null)
            {
                request.ScanRange.Start = requestScanRange_scanRange_Start.Value;
                requestScanRangeIsNull = false;
            }
            System.Int64? requestScanRange_scanRange_End = null;
            if (cmdletContext.ScanRange_End != null)
            {
                requestScanRange_scanRange_End = cmdletContext.ScanRange_End.Value;
            }
            if (requestScanRange_scanRange_End != null)
            {
                request.ScanRange.End = requestScanRange_scanRange_End.Value;
                requestScanRangeIsNull = false;
            }
             // determine if request.ScanRange should be set to null
            if (requestScanRangeIsNull)
            {
                request.ScanRange = null;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
        
        private Amazon.S3.Model.SelectObjectContentResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.SelectObjectContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "SelectObjectContent");
            try
            {
                #if DESKTOP
                return client.SelectObjectContent(request);
                #elif CORECLR
                return client.SelectObjectContentAsync(request).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public System.String Bucket { get; set; }
            public System.String BucketName { get; set; }
            public System.String Key { get; set; }
            public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideCustomerEncryptionMethod { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
            public System.String Expression { get; set; }
            public Amazon.S3.ExpressionType ExpressionType { get; set; }
            public System.Boolean? RequestProgress { get; set; }
            public Amazon.S3.Model.InputSerialization InputSerialization { get; set; }
            public Amazon.S3.Model.OutputSerialization OutputSerialization { get; set; }
            public System.Int64? ScanRange_Start { get; set; }
            public System.Int64? ScanRange_End { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.SelectObjectContentResponse, SelectS3ObjectContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Payload;
        }
        
    }
}
