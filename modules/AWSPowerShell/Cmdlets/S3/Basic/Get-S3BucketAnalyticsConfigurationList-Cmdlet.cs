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
    /// <note><para>
    /// This operation is not supported by directory buckets.
    /// </para></note><para>
    /// Lists the analytics configurations for the bucket. You can have up to 1,000 analytics
    /// configurations per bucket.
    /// </para><para>
    /// This action supports list pagination and does not return more than 100 configurations
    /// at a time. You should always check the <c>IsTruncated</c> element in the response.
    /// If there are no more configurations to list, <c>IsTruncated</c> is set to false. If
    /// there are more configurations to list, <c>IsTruncated</c> is set to true, and there
    /// will be a value in <c>NextContinuationToken</c>. You use the <c>NextContinuationToken</c>
    /// value to continue the pagination of the list by passing the value in continuation-token
    /// in the request to <c>GET</c> the next page.
    /// </para><para>
    /// To use this operation, you must have permissions to perform the <c>s3:GetAnalyticsConfiguration</c>
    /// action. The bucket owner has this permission by default. The bucket owner can grant
    /// this permission to others. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-with-s3-actions.html#using-with-s3-actions-related-to-bucket-subresources">Permissions
    /// Related to Bucket Subresource Operations</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a>.
    /// </para><para>
    /// For information about Amazon S3 analytics feature, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/analytics-storage-class.html">Amazon
    /// S3 Analytics – Storage Class Analysis</a>. 
    /// </para><para>
    /// The following operations are related to <c>ListBucketAnalyticsConfigurations</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketAnalyticsConfiguration.html">GetBucketAnalyticsConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketAnalyticsConfiguration.html">DeleteBucketAnalyticsConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketAnalyticsConfiguration.html">PutBucketAnalyticsConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3BucketAnalyticsConfigurationList")]
    [OutputType("Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListBucketAnalyticsConfigurations API operation.", Operation = new[] {"ListBucketAnalyticsConfigurations"}, SelectReturnType = typeof(Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse",
        "This cmdlet returns an Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse object containing multiple properties."
    )]
    public partial class GetS3BucketAnalyticsConfigurationListCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket containing the analytics configurations to retrieve.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// The <code>ContinuationToken</code> that represents a placeholder from where this request
        /// should begin.
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
        /// <code>403 Forbidden</code> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse, GetS3BucketAnalyticsConfigurationListCmdlet>(Select) ??
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
            context.ContinuationToken = this.ContinuationToken;
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
            var request = new Amazon.S3.Model.ListBucketAnalyticsConfigurationsRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ContinuationToken != null)
            {
                request.ContinuationToken = cmdletContext.ContinuationToken;
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
        
        private Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListBucketAnalyticsConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListBucketAnalyticsConfigurations");
            try
            {
                #if DESKTOP
                return client.ListBucketAnalyticsConfigurations(request);
                #elif CORECLR
                return client.ListBucketAnalyticsConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.String ContinuationToken { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.ListBucketAnalyticsConfigurationsResponse, GetS3BucketAnalyticsConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
