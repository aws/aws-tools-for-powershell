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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Searches for UserIDs using a supplied image. It first detects the largest face in
    /// the image, and then searches a specified collection for matching UserIDs. 
    /// 
    ///  
    /// <para>
    /// The operation returns an array of UserIDs that match the face in the supplied image,
    /// ordered by similarity score with the highest similarity first. It also returns a bounding
    /// box for the face found in the input image. 
    /// </para><para>
    /// Information about faces detected in the supplied image, but not used for the search,
    /// is returned in an array of <code>UnsearchedFace</code> objects. If no valid face is
    /// detected in the image, the response will contain an empty <code>UserMatches</code>
    /// list and no <code>SearchedFace</code> object. 
    /// </para>
    /// </summary>
    [Cmdlet("Search", "REKUsersByImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.SearchUsersByImageResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition SearchUsersByImage API operation.", Operation = new[] {"SearchUsersByImage"}, SelectReturnType = typeof(Amazon.Rekognition.Model.SearchUsersByImageResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.SearchUsersByImageResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.SearchUsersByImageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchREKUsersByImageCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Image_Byte
        /// <summary>
        /// <para>
        /// <para>Blob of image bytes up to 5 MBs. Note that the maximum image size you can pass to
        /// <code>DetectCustomLabels</code> is 4MB. </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Image_Byte { get; set; }
        #endregion
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing collection containing the UserID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter MaxUser
        /// <summary>
        /// <para>
        /// <para>Maximum number of UserIDs to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxUsers")]
        public System.Int32? MaxUser { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter QualityFilter
        /// <summary>
        /// <para>
        /// <para>A filter that specifies a quality bar for how much filtering is done to identify faces.
        /// Filtered faces aren't searched for in the collection. The default value is NONE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Rekognition.QualityFilter")]
        public Amazon.Rekognition.QualityFilter QualityFilter { get; set; }
        #endregion
        
        #region Parameter UserMatchThreshold
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence in the UserID match to return. Default value is 80.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? UserMatchThreshold { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.SearchUsersByImageResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.SearchUsersByImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CollectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CollectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CollectionId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-REKUsersByImage (SearchUsersByImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.SearchUsersByImageResponse, SearchREKUsersByImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CollectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CollectionId = this.CollectionId;
            #if MODULAR
            if (this.CollectionId == null && ParameterWasBound(nameof(this.CollectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Image_Byte = this.Image_Byte;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            context.MaxUser = this.MaxUser;
            context.QualityFilter = this.QualityFilter;
            context.UserMatchThreshold = this.UserMatchThreshold;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Image_ByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Rekognition.Model.SearchUsersByImageRequest();
                
                if (cmdletContext.CollectionId != null)
                {
                    request.CollectionId = cmdletContext.CollectionId;
                }
                
                 // populate Image
                var requestImageIsNull = true;
                request.Image = new Amazon.Rekognition.Model.Image();
                System.IO.MemoryStream requestImage_image_Byte = null;
                if (cmdletContext.Image_Byte != null)
                {
                    _Image_ByteStream = new System.IO.MemoryStream(cmdletContext.Image_Byte);
                    requestImage_image_Byte = _Image_ByteStream;
                }
                if (requestImage_image_Byte != null)
                {
                    request.Image.Bytes = requestImage_image_Byte;
                    requestImageIsNull = false;
                }
                Amazon.Rekognition.Model.S3Object requestImage_image_S3Object = null;
                
                 // populate S3Object
                var requestImage_image_S3ObjectIsNull = true;
                requestImage_image_S3Object = new Amazon.Rekognition.Model.S3Object();
                System.String requestImage_image_S3Object_s3Object_Bucket = null;
                if (cmdletContext.S3Object_Bucket != null)
                {
                    requestImage_image_S3Object_s3Object_Bucket = cmdletContext.S3Object_Bucket;
                }
                if (requestImage_image_S3Object_s3Object_Bucket != null)
                {
                    requestImage_image_S3Object.Bucket = requestImage_image_S3Object_s3Object_Bucket;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_s3Object_Name = null;
                if (cmdletContext.S3Object_Name != null)
                {
                    requestImage_image_S3Object_s3Object_Name = cmdletContext.S3Object_Name;
                }
                if (requestImage_image_S3Object_s3Object_Name != null)
                {
                    requestImage_image_S3Object.Name = requestImage_image_S3Object_s3Object_Name;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_s3Object_Version = null;
                if (cmdletContext.S3Object_Version != null)
                {
                    requestImage_image_S3Object_s3Object_Version = cmdletContext.S3Object_Version;
                }
                if (requestImage_image_S3Object_s3Object_Version != null)
                {
                    requestImage_image_S3Object.Version = requestImage_image_S3Object_s3Object_Version;
                    requestImage_image_S3ObjectIsNull = false;
                }
                 // determine if requestImage_image_S3Object should be set to null
                if (requestImage_image_S3ObjectIsNull)
                {
                    requestImage_image_S3Object = null;
                }
                if (requestImage_image_S3Object != null)
                {
                    request.Image.S3Object = requestImage_image_S3Object;
                    requestImageIsNull = false;
                }
                 // determine if request.Image should be set to null
                if (requestImageIsNull)
                {
                    request.Image = null;
                }
                if (cmdletContext.MaxUser != null)
                {
                    request.MaxUsers = cmdletContext.MaxUser.Value;
                }
                if (cmdletContext.QualityFilter != null)
                {
                    request.QualityFilter = cmdletContext.QualityFilter;
                }
                if (cmdletContext.UserMatchThreshold != null)
                {
                    request.UserMatchThreshold = cmdletContext.UserMatchThreshold.Value;
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
            finally
            {
                if( _Image_ByteStream != null)
                {
                    _Image_ByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.SearchUsersByImageResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.SearchUsersByImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "SearchUsersByImage");
            try
            {
                #if DESKTOP
                return client.SearchUsersByImage(request);
                #elif CORECLR
                return client.SearchUsersByImageAsync(request).GetAwaiter().GetResult();
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
            public System.String CollectionId { get; set; }
            public byte[] Image_Byte { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public System.Int32? MaxUser { get; set; }
            public Amazon.Rekognition.QualityFilter QualityFilter { get; set; }
            public System.Single? UserMatchThreshold { get; set; }
            public System.Func<Amazon.Rekognition.Model.SearchUsersByImageResponse, SearchREKUsersByImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
