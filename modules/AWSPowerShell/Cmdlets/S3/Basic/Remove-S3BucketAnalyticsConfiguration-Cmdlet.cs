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
    /// Deletes an analytics configuration for the bucket (specified by the analytics configuration
    /// ID).
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have permissions to perform the <code>s3:PutAnalyticsConfiguration</code>
    /// action. The bucket owner has this permission by default. The bucket owner can grant
    /// this permission to others. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-with-s3-actions.html#using-with-s3-actions-related-to-bucket-subresources">Permissions
    /// Related to Bucket Subresource Operations</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a>.
    /// </para><para>
    /// For information about the Amazon S3 analytics feature, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/analytics-storage-class.html">Amazon
    /// S3 Analytics – Storage Class Analysis</a>. 
    /// </para><para>
    /// The following operations are related to <code>DeleteBucketAnalyticsConfiguration</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketAnalyticsConfiguration.html">GetBucketAnalyticsConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListBucketAnalyticsConfigurations.html">ListBucketAnalyticsConfigurations</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketAnalyticsConfiguration.html">PutBucketAnalyticsConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "S3BucketAnalyticsConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) DeleteBucketAnalyticsConfiguration API operation.", Operation = new[] {"DeleteBucketAnalyticsConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.DeleteBucketAnalyticsConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.DeleteBucketAnalyticsConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.DeleteBucketAnalyticsConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveS3BucketAnalyticsConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter AnalyticsId
        /// <summary>
        /// <para>
        /// The identifier used to represent an analytics configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsId { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket from which an analytics configuration is deleted.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account id of the expected bucket owner. 
        /// If the bucket is owned by a different account, the request will fail with an HTTP 403 (Access Denied) error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.DeleteBucketAnalyticsConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-S3BucketAnalyticsConfiguration (DeleteBucketAnalyticsConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.DeleteBucketAnalyticsConfigurationResponse, RemoveS3BucketAnalyticsConfigurationCmdlet>(Select) ??
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
            context.AnalyticsId = this.AnalyticsId;
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
            var request = new Amazon.S3.Model.DeleteBucketAnalyticsConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.AnalyticsId != null)
            {
                request.AnalyticsId = cmdletContext.AnalyticsId;
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
        
        private Amazon.S3.Model.DeleteBucketAnalyticsConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.DeleteBucketAnalyticsConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "DeleteBucketAnalyticsConfiguration");
            try
            {
                #if DESKTOP
                return client.DeleteBucketAnalyticsConfiguration(request);
                #elif CORECLR
                return client.DeleteBucketAnalyticsConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String AnalyticsId { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.DeleteBucketAnalyticsConfigurationResponse, RemoveS3BucketAnalyticsConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
