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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Lists table buckets for your account. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-buckets.html">S3
    /// Table buckets</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:ListTableBuckets</c> permission to use this operation.
    /// 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3TTableBucketList")]
    [OutputType("Amazon.S3Tables.Model.ListTableBucketsResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables ListTableBuckets API operation.", Operation = new[] {"ListTableBuckets"}, SelectReturnType = typeof(Amazon.S3Tables.Model.ListTableBucketsResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.ListTableBucketsResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.ListTableBucketsResponse object containing multiple properties."
    )]
    public partial class GetS3TTableBucketListCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// <para><c>ContinuationToken</c> indicates to Amazon S3 that the list is being continued
        /// on this bucket with a token. <c>ContinuationToken</c> is obfuscated and is not a real
        /// key. You can use this <c>ContinuationToken</c> for pagination of the list results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContinuationToken { get; set; }
        #endregion
        
        #region Parameter MaxBucket
        /// <summary>
        /// <para>
        /// <para>The maximum number of table buckets to return in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxBuckets")]
        public System.Int32? MaxBucket { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the table buckets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of table buckets to filter by in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.TableBucketType")]
        public Amazon.S3Tables.TableBucketType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.ListTableBucketsResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.ListTableBucketsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.ListTableBucketsResponse, GetS3TTableBucketListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContinuationToken = this.ContinuationToken;
            context.MaxBucket = this.MaxBucket;
            context.Prefix = this.Prefix;
            context.Type = this.Type;
            
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
            var request = new Amazon.S3Tables.Model.ListTableBucketsRequest();
            
            if (cmdletContext.ContinuationToken != null)
            {
                request.ContinuationToken = cmdletContext.ContinuationToken;
            }
            if (cmdletContext.MaxBucket != null)
            {
                request.MaxBuckets = cmdletContext.MaxBucket.Value;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.S3Tables.Model.ListTableBucketsResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.ListTableBucketsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "ListTableBuckets");
            try
            {
                #if DESKTOP
                return client.ListTableBuckets(request);
                #elif CORECLR
                return client.ListTableBucketsAsync(request).GetAwaiter().GetResult();
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
            public System.String ContinuationToken { get; set; }
            public System.Int32? MaxBucket { get; set; }
            public System.String Prefix { get; set; }
            public Amazon.S3Tables.TableBucketType Type { get; set; }
            public System.Func<Amazon.S3Tables.Model.ListTableBucketsResponse, GetS3TTableBucketListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
