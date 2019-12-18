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
    /// Returns metadata about all of the versions of objects in a bucket. You can also use
    /// request parameters as selection criteria to return metadata about a subset of all
    /// the object versions. 
    /// 
    ///  <note><para>
    ///  A 200 OK response can contain valid or invalid XML. Make sure to design your application
    /// to parse the contents of the response and handle it appropriately.
    /// </para></note><para>
    /// To use this operation, you must have READ access to the bucket.
    /// </para><para>
    /// The following operations are related to <code>ListObjectVersions</code>:
    /// </para><ul><li><para><a>ListObjectsV2</a></para></li><li><para><a>GetObject</a></para></li><li><para><a>PutObject</a></para></li><li><para><a>DeleteObject</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3Version")]
    [OutputType("Amazon.S3.Model.ListVersionsResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListVersions API operation.", Operation = new[] {"ListVersions"}, SelectReturnType = typeof(Amazon.S3.Model.ListVersionsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.ListVersionsResponse",
        "This cmdlet returns an Amazon.S3.Model.ListVersionsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetS3VersionCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name that contains the objects.</para><para>When using this API with an access point, you must direct requests to the access point hostname. 
        /// The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com. 
        /// When using this operation using an access point through the AWS SDKs, you provide the access point 
        /// ARN in place of the bucket name. For more information about access point ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-access-points.html">Using Access Points</a> 
        /// in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter Encoding
        /// <summary>
        /// <para>
        /// Requests Amazon S3 to encode the object keys in the response and specifies
        /// the encoding method to use. An object key may contain any Unicode character;
        /// however, XML 1.0 parser cannot parse some characters, such as characters
        /// with an ASCII value from 0 to 10. For characters that are not supported in
        /// XML 1.0, you can add this parameter to request that Amazon S3 encode the
        /// keys in the response.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.EncodingType")]
        public Amazon.S3.EncodingType Encoding { get; set; }
        #endregion
        
        #region Parameter KeyMarker
        /// <summary>
        /// <para>
        /// Specifies the key to start with when listing objects in a bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyMarker { get; set; }
        #endregion
        
        #region Parameter VersionIdMarker
        /// <summary>
        /// <para>
        /// Specifies the object version you want to start listing from.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionIdMarker { get; set; }
        #endregion
        
        #region Parameter Delimiter
        /// <summary>
        /// <para>
        /// A delimiter is a character you use to group keys.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Delimiter { get; set; }
        #endregion
        
        #region Parameter MaxKey
        /// <summary>
        /// <para>
        /// Sets the maximum number of keys returned in the response. The response might contain fewer keys but will never contain more.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxKeys")]
        public System.Int32? MaxKey { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// Limits the response to keys that begin with the specified prefix.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListVersionsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListVersionsResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListVersionsResponse, GetS3VersionCmdlet>(Select) ??
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
            context.Delimiter = this.Delimiter;
            context.KeyMarker = this.KeyMarker;
            context.MaxKey = this.MaxKey;
            context.Prefix = this.Prefix;
            context.VersionIdMarker = this.VersionIdMarker;
            context.Encoding = this.Encoding;
            
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
            var request = new Amazon.S3.Model.ListVersionsRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.Delimiter != null)
            {
                request.Delimiter = cmdletContext.Delimiter;
            }
            if (cmdletContext.KeyMarker != null)
            {
                request.KeyMarker = cmdletContext.KeyMarker;
            }
            if (cmdletContext.MaxKey != null)
            {
                request.MaxKeys = cmdletContext.MaxKey.Value;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.VersionIdMarker != null)
            {
                request.VersionIdMarker = cmdletContext.VersionIdMarker;
            }
            if (cmdletContext.Encoding != null)
            {
                request.Encoding = cmdletContext.Encoding;
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
        
        private Amazon.S3.Model.ListVersionsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListVersions");
            try
            {
                #if DESKTOP
                return client.ListVersions(request);
                #elif CORECLR
                return client.ListVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String Delimiter { get; set; }
            public System.String KeyMarker { get; set; }
            public System.Int32? MaxKey { get; set; }
            public System.String Prefix { get; set; }
            public System.String VersionIdMarker { get; set; }
            public Amazon.S3.EncodingType Encoding { get; set; }
            public System.Func<Amazon.S3.Model.ListVersionsResponse, GetS3VersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
