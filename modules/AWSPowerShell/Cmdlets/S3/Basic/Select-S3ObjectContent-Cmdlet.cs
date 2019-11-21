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
    /// This operation filters the contents of an Amazon S3 object based on a simple Structured
    /// Query Language (SQL) statement. In the request, along with the SQL expression, you
    /// must also specify a data serialization format (JSON or CSV) of the object. Amazon
    /// S3 uses this to parse object data into records, and returns only records that match
    /// the specified SQL expression. You must also specify the data serialization format
    /// for the response.
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
        
        #region Parameter Bucket
        /// <summary>
        /// <para>
        /// The S3 Bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Bucket { get; set; }
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
            context.Bucket = this.Bucket;
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
            
            if (cmdletContext.Bucket != null)
            {
                request.Bucket = cmdletContext.Bucket;
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
            public System.String Bucket { get; set; }
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
            public System.Func<Amazon.S3.Model.SelectObjectContentResponse, SelectS3ObjectContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Payload;
        }
        
    }
}
