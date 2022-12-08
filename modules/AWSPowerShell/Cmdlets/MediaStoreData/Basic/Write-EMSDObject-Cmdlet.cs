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
using Amazon.MediaStoreData;
using Amazon.MediaStoreData.Model;

namespace Amazon.PowerShell.Cmdlets.EMSD
{
    /// <summary>
    /// Uploads an object to the specified path. Object sizes are limited to 25 MB for standard
    /// upload availability and 10 MB for streaming upload availability.
    /// </summary>
    [Cmdlet("Write", "EMSDObject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaStoreData.Model.PutObjectResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaStore Data Plane PutObject API operation.", Operation = new[] {"PutObject"}, SelectReturnType = typeof(Amazon.MediaStoreData.Model.PutObjectResponse))]
    [AWSCmdletOutput("Amazon.MediaStoreData.Model.PutObjectResponse",
        "This cmdlet returns an Amazon.MediaStoreData.Model.PutObjectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEMSDObjectCmdlet : AmazonMediaStoreDataClientCmdlet, IExecutor
    {
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>The bytes to be stored. </para>
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public object Body { get; set; }
        #endregion
        
        #region Parameter CacheControl
        /// <summary>
        /// <para>
        /// <para>An optional <code>CacheControl</code> header that allows the caller to control the
        /// object's cache behavior. Headers can be passed in as specified in the HTTP at <a href="https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9">https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9</a>.</para><para>Headers with a custom user-defined value are also accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheControl { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The path (including the file name) where the object is stored in the container. Format:
        /// &lt;folder name&gt;/&lt;folder name&gt;/&lt;file name&gt;</para><para>For example, to upload the file <code>mlaw.avi</code> to the folder path <code>premium\canada</code>
        /// in the container <code>movies</code>, enter the path <code>premium/canada/mlaw.avi</code>.</para><para>Do not include the container name in this path.</para><para>If the path includes any folders that don't exist yet, the service creates them. For
        /// example, suppose you have an existing <code>premium/usa</code> subfolder. If you specify
        /// <code>premium/canada</code>, the service creates a <code>canada</code> subfolder in
        /// the <code>premium</code> folder. You then have two subfolders, <code>usa</code> and
        /// <code>canada</code>, in the <code>premium</code> folder. </para><para>There is no correlation between the path to the source and the path (folders) in the
        /// container in AWS Elemental MediaStore.</para><para>For more information about folders and how they exist in a container, see the <a href="http://docs.aws.amazon.com/mediastore/latest/ug/">AWS
        /// Elemental MediaStore User Guide</a>.</para><para>The file name is the name that is assigned to the file that you upload. The file can
        /// have the same name inside and outside of AWS Elemental MediaStore, or it can have
        /// the same name. The file name can include or omit an extension. </para>
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
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter StorageClass
        /// <summary>
        /// <para>
        /// <para>Indicates the storage class of a <code>Put</code> request. Defaults to high-performance
        /// temporal storage class, and objects are persisted into durable storage shortly after
        /// being received.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaStoreData.StorageClass")]
        public Amazon.MediaStoreData.StorageClass StorageClass { get; set; }
        #endregion
        
        #region Parameter UploadAvailability
        /// <summary>
        /// <para>
        /// <para>Indicates the availability of an object while it is still uploading. If the value
        /// is set to <code>streaming</code>, the object is available for downloading after some
        /// initial buffering but before the object is uploaded completely. If the value is set
        /// to <code>standard</code>, the object is available for downloading only when it is
        /// uploaded completely. The default value for this header is <code>standard</code>.</para><para>To use this header, you must also set the HTTP <code>Transfer-Encoding</code> header
        /// to <code>chunked</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaStoreData.UploadAvailability")]
        public Amazon.MediaStoreData.UploadAvailability UploadAvailability { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaStoreData.Model.PutObjectResponse).
        /// Specifying the name of a property of type Amazon.MediaStoreData.Model.PutObjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Path parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Path), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMSDObject (PutObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaStoreData.Model.PutObjectResponse, WriteEMSDObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Path;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Body = this.Body;
            #if MODULAR
            if (this.Body == null && ParameterWasBound(nameof(this.Body)))
            {
                WriteWarning("You are passing $null as a value for parameter Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CacheControl = this.CacheControl;
            context.ContentType = this.ContentType;
            context.Path = this.Path;
            #if MODULAR
            if (this.Path == null && ParameterWasBound(nameof(this.Path)))
            {
                WriteWarning("You are passing $null as a value for parameter Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageClass = this.StorageClass;
            context.UploadAvailability = this.UploadAvailability;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.Stream _BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.MediaStoreData.Model.PutObjectRequest();
                
                if (cmdletContext.Body != null)
                {
                    _BodyStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.Body);
                    request.Body = _BodyStream;
                }
                if (cmdletContext.CacheControl != null)
                {
                    request.CacheControl = cmdletContext.CacheControl;
                }
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.Path != null)
                {
                    request.Path = cmdletContext.Path;
                }
                if (cmdletContext.StorageClass != null)
                {
                    request.StorageClass = cmdletContext.StorageClass;
                }
                if (cmdletContext.UploadAvailability != null)
                {
                    request.UploadAvailability = cmdletContext.UploadAvailability;
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
                if( _BodyStream != null)
                {
                    _BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MediaStoreData.Model.PutObjectResponse CallAWSServiceOperation(IAmazonMediaStoreData client, Amazon.MediaStoreData.Model.PutObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaStore Data Plane", "PutObject");
            try
            {
                #if DESKTOP
                return client.PutObject(request);
                #elif CORECLR
                return client.PutObjectAsync(request).GetAwaiter().GetResult();
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
            public object Body { get; set; }
            public System.String CacheControl { get; set; }
            public System.String ContentType { get; set; }
            public System.String Path { get; set; }
            public Amazon.MediaStoreData.StorageClass StorageClass { get; set; }
            public Amazon.MediaStoreData.UploadAvailability UploadAvailability { get; set; }
            public System.Func<Amazon.MediaStoreData.Model.PutObjectResponse, WriteEMSDObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
