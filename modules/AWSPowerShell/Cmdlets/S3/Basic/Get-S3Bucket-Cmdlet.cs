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
using Amazon.S3;
using Amazon.S3.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Returns a list of all buckets owned by the authenticated sender of the request. To
    /// grant IAM permission to use this operation, you must add the <c>s3:ListAllMyBuckets</c>
    /// policy action. 
    /// </para><para>
    /// For information about Amazon S3 buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html">Creating,
    /// configuring, and working with Amazon S3 buckets</a>.
    /// </para><important><para>
    /// We strongly recommend using only paginated <c>ListBuckets</c> requests. Unpaginated
    /// <c>ListBuckets</c> requests are only supported for Amazon Web Services accounts set
    /// to the default general purpose bucket quota of 10,000. If you have an approved general
    /// purpose bucket quota above 10,000, you must send paginated <c>ListBuckets</c> requests
    /// to list your account’s buckets. All unpaginated <c>ListBuckets</c> requests will be
    /// rejected for Amazon Web Services accounts with a general purpose bucket quota greater
    /// than 10,000. 
    /// </para></important><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "S3Bucket")]
    [OutputType("Amazon.S3.Model.S3Bucket")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListBuckets API operation.", Operation = new[] {"ListBuckets"}, SelectReturnType = typeof(Amazon.S3.Model.ListBucketsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.S3Bucket or Amazon.S3.Model.ListBucketsResponse",
        "This cmdlet returns a collection of Amazon.S3.Model.S3Bucket objects.",
        "The service call response (type Amazon.S3.Model.ListBucketsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketRegion
        /// <summary>
        /// <para>
        /// <para>Limits the response to buckets that are located in the specified Amazon Web Services
        /// Region. The Amazon Web Services Region must be expressed according to the Amazon Web
        /// Services Region code, such as <c>us-west-2</c> for the US West (Oregon) Region. For
        /// a list of the valid values for all of the Amazon Web Services Regions, see <a href="https://docs.aws.amazon.com/general/latest/gr/rande.html#s3_region">Regions
        /// and Endpoints</a>.</para><note><para>Requests made to a Regional endpoint that is different from the <c>bucket-region</c>
        /// parameter are not supported. For example, if you want to limit the response to your
        /// buckets in Region <c>us-west-2</c>, the request must be made to an endpoint in Region
        /// <c>us-west-2</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BucketRegion { get; set; }
        #endregion
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// <para><c>ContinuationToken</c> indicates to Amazon S3 that the list is being continued
        /// on this bucket with a token. <c>ContinuationToken</c> is obfuscated and is not a real
        /// key. You can use this <c>ContinuationToken</c> for pagination of the list results.
        /// </para><para>Length Constraints: Minimum length of 0. Maximum length of 1024.</para><para>Required: No.</para><note><para>If you specify the <c>bucket-region</c>, <c>prefix</c>, or <c>continuation-token</c>
        /// query parameters without using <c>max-buckets</c> to set the maximum number of buckets
        /// returned in the response, Amazon S3 applies a default page size of 10,000 and provides
        /// a continuation token if there are more buckets.</para></note>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'ContinuationToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-ContinuationToken' to null for the first call then set the 'ContinuationToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String ContinuationToken { get; set; }
        #endregion
        
        #region Parameter MaxBucket
        /// <summary>
        /// <para>
        /// <para>Maximum number of buckets to be returned in response. When the number is more than
        /// the count of buckets that are owned by an Amazon Web Services account, return all
        /// the buckets in response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxBuckets","MaxItems")]
        public int? MaxBucket { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>Limits the response to bucket names that begin with the specified bucket name prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Buckets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListBucketsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListBucketsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Buckets";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of ContinuationToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListBucketsResponse, GetS3BucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketRegion = this.BucketRegion;
            context.ContinuationToken = this.ContinuationToken;
            context.MaxBucket = this.MaxBucket;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxBucket)) && this.MaxBucket.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxBucket parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxBucket" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.Prefix = this.Prefix;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.S3.Model.ListBucketsRequest();
            
            if (cmdletContext.BucketRegion != null)
            {
                request.BucketRegion = cmdletContext.BucketRegion;
            }
            if (cmdletContext.MaxBucket != null)
            {
                request.MaxBuckets = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxBucket.Value);
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.ContinuationToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ContinuationToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.ContinuationToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.ContinuationToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.S3.Model.ListBucketsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListBucketsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListBuckets");
            try
            {
                return client.ListBucketsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BucketRegion { get; set; }
            public System.String ContinuationToken { get; set; }
            public int? MaxBucket { get; set; }
            public System.String Prefix { get; set; }
            public System.Func<Amazon.S3.Model.ListBucketsResponse, GetS3BucketCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Buckets;
        }
        
    }
}
