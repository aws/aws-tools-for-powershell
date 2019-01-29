/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates an <a href="http://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">AWS
    /// Lambda layer</a> from a ZIP archive. Each time you call <code>PublishLayerVersion</code>
    /// with the same version name, a new version is created.
    /// 
    ///  
    /// <para>
    /// Add layers to your function with <a>CreateFunction</a> or <a>UpdateFunctionConfiguration</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "LMLayerVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.PublishLayerVersionResponse")]
    [AWSCmdlet("Calls the AWS Lambda PublishLayerVersion API operation.", Operation = new[] {"PublishLayerVersion"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.PublishLayerVersionResponse",
        "This cmdlet returns a Amazon.Lambda.Model.PublishLayerVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class PublishLMLayerVersionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter CompatibleRuntime
        /// <summary>
        /// <para>
        /// <para>A list of compatible <a href="http://docs.aws.amazon.com/lambda/latest/dg/lambda-runtimes.html">function
        /// runtimes</a>. Used for filtering with <a>ListLayers</a> and <a>ListLayerVersions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CompatibleRuntimes")]
        public System.String[] CompatibleRuntime { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LayerName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String LayerName { get; set; }
        #endregion
        
        #region Parameter LicenseInfo
        /// <summary>
        /// <para>
        /// <para>The layer's software license. It can be any of the following:</para><ul><li><para>An <a href="https://spdx.org/licenses/">SPDX license identifier</a>. For example,
        /// <code>MIT</code>.</para></li><li><para>The URL of a license hosted on the internet. For example, <code>https://opensource.org/licenses/MIT</code>.</para></li><li><para>The full text of the license.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LicenseInfo { get; set; }
        #endregion
        
        #region Parameter Content_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket of the layer archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Content_S3Bucket { get; set; }
        #endregion
        
        #region Parameter Content_S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key of the layer archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Content_S3Key { get; set; }
        #endregion
        
        #region Parameter Content_S3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>For versioned objects, the version of the layer archive object to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Content_S3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter Content_ZipFile
        /// <summary>
        /// <para>
        /// <para>The base64-encoded contents of the layer archive. AWS SDK and AWS CLI clients handle
        /// the encoding for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] Content_ZipFile { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LayerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-LMLayerVersion (PublishLayerVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.CompatibleRuntime != null)
            {
                context.CompatibleRuntimes = new List<System.String>(this.CompatibleRuntime);
            }
            context.Content_S3Bucket = this.Content_S3Bucket;
            context.Content_S3Key = this.Content_S3Key;
            context.Content_S3ObjectVersion = this.Content_S3ObjectVersion;
            context.Content_ZipFile = this.Content_ZipFile;
            context.Description = this.Description;
            context.LayerName = this.LayerName;
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
                
                if (cmdletContext.CompatibleRuntimes != null)
                {
                    request.CompatibleRuntimes = cmdletContext.CompatibleRuntimes;
                }
                
                 // populate Content
                bool requestContentIsNull = true;
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
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response,
                        Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PublishLayerVersionAsync(request);
                return task.Result;
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
            public List<System.String> CompatibleRuntimes { get; set; }
            public System.String Content_S3Bucket { get; set; }
            public System.String Content_S3Key { get; set; }
            public System.String Content_S3ObjectVersion { get; set; }
            public byte[] Content_ZipFile { get; set; }
            public System.String Description { get; set; }
            public System.String LayerName { get; set; }
            public System.String LicenseInfo { get; set; }
        }
        
    }
}
