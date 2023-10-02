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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Creates an <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">Lambda
    /// layer</a> from a ZIP archive. Each time you call <code>PublishLayerVersion</code>
    /// with the same layer name, a new version is created.
    /// 
    ///  
    /// <para>
    /// Add layers to your function with <a>CreateFunction</a> or <a>UpdateFunctionConfiguration</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "LMLayerVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.PublishLayerVersionResponse")]
    [AWSCmdlet("Calls the AWS Lambda PublishLayerVersion API operation.", Operation = new[] {"PublishLayerVersion"}, SelectReturnType = typeof(Amazon.Lambda.Model.PublishLayerVersionResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.PublishLayerVersionResponse",
        "This cmdlet returns an Amazon.Lambda.Model.PublishLayerVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class PublishLMLayerVersionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CompatibleArchitecture
        /// <summary>
        /// <para>
        /// <para>A list of compatible <a href="https://docs.aws.amazon.com/lambda/latest/dg/foundation-arch.html">instruction
        /// set architectures</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompatibleArchitectures")]
        public System.String[] CompatibleArchitecture { get; set; }
        #endregion
        
        #region Parameter CompatibleRuntime
        /// <summary>
        /// <para>
        /// <para>A list of compatible <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-runtimes.html">function
        /// runtimes</a>. Used for filtering with <a>ListLayers</a> and <a>ListLayerVersions</a>.</para><para>The following list includes deprecated runtimes. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-runtimes.html#runtime-support-policy">Runtime
        /// deprecation policy</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompatibleRuntimes")]
        public System.String[] CompatibleRuntime { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LayerName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the layer.</para>
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
        public System.String LayerName { get; set; }
        #endregion
        
        #region Parameter LicenseInfo
        /// <summary>
        /// <para>
        /// <para>The layer's software license. It can be any of the following:</para><ul><li><para>An <a href="https://spdx.org/licenses/">SPDX license identifier</a>. For example,
        /// <code>MIT</code>.</para></li><li><para>The URL of a license hosted on the internet. For example, <code>https://opensource.org/licenses/MIT</code>.</para></li><li><para>The full text of the license.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseInfo { get; set; }
        #endregion
        
        #region Parameter Content_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket of the layer archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_S3Bucket { get; set; }
        #endregion
        
        #region Parameter Content_S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key of the layer archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_S3Key { get; set; }
        #endregion
        
        #region Parameter Content_S3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>For versioned objects, the version of the layer archive object to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_S3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter Content_ZipFile
        /// <summary>
        /// <para>
        /// <para>The base64-encoded contents of the layer archive. Amazon Web Services SDK and Amazon
        /// Web Services CLI clients handle the encoding for you.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Content_ZipFile { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.PublishLayerVersionResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.PublishLayerVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LayerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LayerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LayerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LayerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-LMLayerVersion (PublishLayerVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.PublishLayerVersionResponse, PublishLMLayerVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LayerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CompatibleArchitecture != null)
            {
                context.CompatibleArchitecture = new List<System.String>(this.CompatibleArchitecture);
            }
            if (this.CompatibleRuntime != null)
            {
                context.CompatibleRuntime = new List<System.String>(this.CompatibleRuntime);
            }
            context.Content_S3Bucket = this.Content_S3Bucket;
            context.Content_S3Key = this.Content_S3Key;
            context.Content_S3ObjectVersion = this.Content_S3ObjectVersion;
            context.Content_ZipFile = this.Content_ZipFile;
            context.Description = this.Description;
            context.LayerName = this.LayerName;
            #if MODULAR
            if (this.LayerName == null && ParameterWasBound(nameof(this.LayerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LayerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LicenseInfo = this.LicenseInfo;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Content_ZipFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Lambda.Model.PublishLayerVersionRequest();
                
                if (cmdletContext.CompatibleArchitecture != null)
                {
                    request.CompatibleArchitectures = cmdletContext.CompatibleArchitecture;
                }
                if (cmdletContext.CompatibleRuntime != null)
                {
                    request.CompatibleRuntimes = cmdletContext.CompatibleRuntime;
                }
                
                 // populate Content
                var requestContentIsNull = true;
                request.Content = new Amazon.Lambda.Model.LayerVersionContentInput();
                System.String requestContent_content_S3Bucket = null;
                if (cmdletContext.Content_S3Bucket != null)
                {
                    requestContent_content_S3Bucket = cmdletContext.Content_S3Bucket;
                }
                if (requestContent_content_S3Bucket != null)
                {
                    request.Content.S3Bucket = requestContent_content_S3Bucket;
                    requestContentIsNull = false;
                }
                System.String requestContent_content_S3Key = null;
                if (cmdletContext.Content_S3Key != null)
                {
                    requestContent_content_S3Key = cmdletContext.Content_S3Key;
                }
                if (requestContent_content_S3Key != null)
                {
                    request.Content.S3Key = requestContent_content_S3Key;
                    requestContentIsNull = false;
                }
                System.String requestContent_content_S3ObjectVersion = null;
                if (cmdletContext.Content_S3ObjectVersion != null)
                {
                    requestContent_content_S3ObjectVersion = cmdletContext.Content_S3ObjectVersion;
                }
                if (requestContent_content_S3ObjectVersion != null)
                {
                    request.Content.S3ObjectVersion = requestContent_content_S3ObjectVersion;
                    requestContentIsNull = false;
                }
                System.IO.MemoryStream requestContent_content_ZipFile = null;
                if (cmdletContext.Content_ZipFile != null)
                {
                    _Content_ZipFileStream = new System.IO.MemoryStream(cmdletContext.Content_ZipFile);
                    requestContent_content_ZipFile = _Content_ZipFileStream;
                }
                if (requestContent_content_ZipFile != null)
                {
                    request.Content.ZipFile = requestContent_content_ZipFile;
                    requestContentIsNull = false;
                }
                 // determine if request.Content should be set to null
                if (requestContentIsNull)
                {
                    request.Content = null;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                if (cmdletContext.LayerName != null)
                {
                    request.LayerName = cmdletContext.LayerName;
                }
                if (cmdletContext.LicenseInfo != null)
                {
                    request.LicenseInfo = cmdletContext.LicenseInfo;
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
                if( _Content_ZipFileStream != null)
                {
                    _Content_ZipFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.PublishLayerVersionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.PublishLayerVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "PublishLayerVersion");
            try
            {
                #if DESKTOP
                return client.PublishLayerVersion(request);
                #elif CORECLR
                return client.PublishLayerVersionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CompatibleArchitecture { get; set; }
            public List<System.String> CompatibleRuntime { get; set; }
            public System.String Content_S3Bucket { get; set; }
            public System.String Content_S3Key { get; set; }
            public System.String Content_S3ObjectVersion { get; set; }
            public byte[] Content_ZipFile { get; set; }
            public System.String Description { get; set; }
            public System.String LayerName { get; set; }
            public System.String LicenseInfo { get; set; }
            public System.Func<Amazon.Lambda.Model.PublishLayerVersionResponse, PublishLMLayerVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
