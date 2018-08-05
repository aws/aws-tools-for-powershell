/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon Simple Storage Service SelectObjectContent API operation.", Operation = new[] {"SelectObjectContent"})]
    [AWSCmdletOutput("Amazon.S3.Model.ISelectObjectContentEventStream",
        "This cmdlet returns a ISelectObjectContentEventStream object.",
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
        [System.Management.Automation.Parameter]
        public System.String Bucket { get; set; }
        #endregion
        
        #region Parameter Expression
        /// <summary>
        /// <para>
        /// The expression that is used to query the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Expression { get; set; }
        #endregion
        
        #region Parameter ExpressionType
        /// <summary>
        /// <para>
        /// The type of the provided expression (e.g., SQL).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.ExpressionType")]
        public Amazon.S3.ExpressionType ExpressionType { get; set; }
        #endregion
        
        #region Parameter InputSerialization
        /// <summary>
        /// <para>
        /// Describes the format of the data in the object that is being queried.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public Amazon.S3.Model.OutputSerialization OutputSerialization { get; set; }
        #endregion
        
        #region Parameter RequestProgress
        /// <summary>
        /// <para>
        /// Specifies if periodic request progress information should be enabled.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RequestProgress { get; set; }
        #endregion
        
        #region Parameter ServerSideCustomerEncryptionMethod
        /// <summary>
        /// <para>
        /// The SSE Algorithm used to encrypt the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideCustomerEncryptionMethod { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// <para>
        /// The SSE Customer Key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// <para>
        /// The SSE Customer Key MD5.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }
        
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Bucket = this.Bucket;
            context.Key = this.Key;
            context.ServerSideCustomerEncryptionMethod = this.ServerSideCustomerEncryptionMethod;
            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;
            context.Expression = this.Expression;
            context.ExpressionType = this.ExpressionType;
            if (ParameterWasBound("RequestProgress"))
                context.RequestProgress = this.RequestProgress;
            context.InputSerialization = this.InputSerialization;
            context.OutputSerialization = this.OutputSerialization;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Payload;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service", "SelectObjectContent");
            try
            {
                #if DESKTOP
                return client.SelectObjectContent(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SelectObjectContentAsync(request);
                return task.Result;
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
        }
        
    }
}
