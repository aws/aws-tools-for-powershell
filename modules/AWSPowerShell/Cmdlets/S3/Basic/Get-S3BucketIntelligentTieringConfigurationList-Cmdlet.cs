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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Lists the S3 Intelligent-Tiering configuration from the specified bucket.
    /// </para><para>
    /// The S3 Intelligent-Tiering storage class is designed to optimize storage costs by
    /// automatically moving data to the most cost-effective storage access tier, without
    /// performance impact or operational overhead. S3 Intelligent-Tiering delivers automatic
    /// cost savings in three low latency and high throughput access tiers. To get the lowest
    /// storage cost on data that can be accessed in minutes to hours, you can choose to activate
    /// additional archiving capabilities.
    /// </para><para>
    /// The S3 Intelligent-Tiering storage class is the ideal storage class for data with
    /// unknown, changing, or unpredictable access patterns, independent of object size or
    /// retention period. If the size of an object is less than 128 KB, it is not monitored
    /// and not eligible for auto-tiering. Smaller objects can be stored, but they are always
    /// charged at the Frequent Access tier rates in the S3 Intelligent-Tiering storage class.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/storage-class-intro.html#sc-dynamic-data-access">Storage
    /// class for automatically optimizing frequently and infrequently accessed objects</a>.
    /// </para><para>
    /// Operations related to <c>ListBucketIntelligentTieringConfigurations</c> include: 
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketIntelligentTieringConfiguration.html">DeleteBucketIntelligentTieringConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketIntelligentTieringConfiguration.html">PutBucketIntelligentTieringConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketIntelligentTieringConfiguration.html">GetBucketIntelligentTieringConfiguration</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "S3BucketIntelligentTieringConfigurationList")]
    [OutputType("Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListBucketIntelligentTieringConfigurations API operation.", Operation = new[] {"ListBucketIntelligentTieringConfigurations"}, SelectReturnType = typeof(Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse",
        "This cmdlet returns an Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse object containing multiple properties."
    )]
    public partial class GetS3BucketIntelligentTieringConfigurationListCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the Amazon S3 bucket whose configuration you want to modify or retrieve.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// The ContinuationToken that represents a placeholder from where this request should begin.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContinuationToken { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <c>403 Forbidden</c> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse, GetS3BucketIntelligentTieringConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.ContinuationToken = this.ContinuationToken;
            
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
            var request = new Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.ContinuationToken != null)
            {
                request.ContinuationToken = cmdletContext.ContinuationToken;
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
        
        private Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListBucketIntelligentTieringConfigurations");
            try
            {
                #if DESKTOP
                return client.ListBucketIntelligentTieringConfigurations(request);
                #elif CORECLR
                return client.ListBucketIntelligentTieringConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String ContinuationToken { get; set; }
            public System.Func<Amazon.S3.Model.ListBucketIntelligentTieringConfigurationsResponse, GetS3BucketIntelligentTieringConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
