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
    /// Gets the S3 Intelligent-Tiering configuration from the specified bucket.
    /// 
    ///  
    /// <para>
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
    /// Operations related to <code>GetBucketIntelligentTieringConfiguration</code> include:
    /// 
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketIntelligentTieringConfiguration.html">DeleteBucketIntelligentTieringConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketIntelligentTieringConfiguration.html">PutBucketIntelligentTieringConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListBucketIntelligentTieringConfigurations.html">ListBucketIntelligentTieringConfigurations</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3BucketIntelligentTieringConfiguration")]
    [OutputType("Amazon.S3.Model.IntelligentTieringConfiguration")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) GetBucketIntelligentTieringConfiguration API operation.", Operation = new[] {"GetBucketIntelligentTieringConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.IntelligentTieringConfiguration or Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse",
        "This cmdlet returns an Amazon.S3.Model.IntelligentTieringConfiguration object.",
        "The service call response (type Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetS3BucketIntelligentTieringConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the Amazon S3 bucket whose configuration you want to modify or retrieve.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter IntelligentTieringId
        /// <summary>
        /// <para>
        /// The ID used to identify the S3 Intelligent-Tiering configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntelligentTieringId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IntelligentTieringConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IntelligentTieringConfiguration";
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
                context.Select = CreateSelectDelegate<Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse, GetS3BucketIntelligentTieringConfigurationCmdlet>(Select) ??
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
            context.IntelligentTieringId = this.IntelligentTieringId;
            
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
            var request = new Amazon.S3.Model.GetBucketIntelligentTieringConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.IntelligentTieringId != null)
            {
                request.IntelligentTieringId = cmdletContext.IntelligentTieringId;
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
        
        private Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetBucketIntelligentTieringConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "GetBucketIntelligentTieringConfiguration");
            try
            {
                #if DESKTOP
                return client.GetBucketIntelligentTieringConfiguration(request);
                #elif CORECLR
                return client.GetBucketIntelligentTieringConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String IntelligentTieringId { get; set; }
            public System.Func<Amazon.S3.Model.GetBucketIntelligentTieringConfigurationResponse, GetS3BucketIntelligentTieringConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IntelligentTieringConfiguration;
        }
        
    }
}
