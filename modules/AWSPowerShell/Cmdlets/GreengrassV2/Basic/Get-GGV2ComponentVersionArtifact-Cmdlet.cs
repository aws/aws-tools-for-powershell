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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Gets the pre-signed URL to download a public or a Lambda component artifact. Core
    /// devices call this operation to identify the URL that they can use to download an artifact
    /// to install.
    /// </summary>
    [Cmdlet("Get", "GGV2ComponentVersionArtifact")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS GreengrassV2 GetComponentVersionArtifact API operation.", Operation = new[] {"GetComponentVersionArtifact"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse))]
    [AWSCmdletOutput("System.String or Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGGV2ComponentVersionArtifactCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the component version. Specify the ARN of a public or a Lambda component version.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ArtifactName
        /// <summary>
        /// <para>
        /// <para>The name of the artifact.</para><para>You can use the <a href="https://docs.aws.amazon.com/greengrass/v2/APIReference/API_GetComponent.html">GetComponent</a>
        /// operation to download the component recipe, which includes the URI of the artifact.
        /// The artifact name is the section of the URI after the scheme. For example, in the
        /// artifact URI <c>greengrass:SomeArtifact.zip</c>, the artifact name is <c>SomeArtifact.zip</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ArtifactName { get; set; }
        #endregion
        
        #region Parameter IotEndpointType
        /// <summary>
        /// <para>
        /// <para>Determines if the Amazon S3 URL returned is a FIPS pre-signed URL endpoint. Specify
        /// <c>fips</c> if you want the returned Amazon S3 pre-signed URL to point to an Amazon
        /// S3 FIPS endpoint. If you don't specify a value, the default is <c>standard</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GreengrassV2.IotEndpointType")]
        public Amazon.GreengrassV2.IotEndpointType IotEndpointType { get; set; }
        #endregion
        
        #region Parameter S3EndpointType
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint to use when getting Amazon S3 pre-signed URLs.</para><para>All Amazon Web Services Regions except US East (N. Virginia) use <c>REGIONAL</c> in
        /// all cases. In the US East (N. Virginia) Region the default is <c>GLOBAL</c>, but you
        /// can change it to <c>REGIONAL</c> with this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GreengrassV2.S3EndpointType")]
        public Amazon.GreengrassV2.S3EndpointType S3EndpointType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PreSignedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PreSignedUrl";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse, GetGGV2ComponentVersionArtifactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ArtifactName = this.ArtifactName;
            #if MODULAR
            if (this.ArtifactName == null && ParameterWasBound(nameof(this.ArtifactName)))
            {
                WriteWarning("You are passing $null as a value for parameter ArtifactName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IotEndpointType = this.IotEndpointType;
            context.S3EndpointType = this.S3EndpointType;
            
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
            var request = new Amazon.GreengrassV2.Model.GetComponentVersionArtifactRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ArtifactName != null)
            {
                request.ArtifactName = cmdletContext.ArtifactName;
            }
            if (cmdletContext.IotEndpointType != null)
            {
                request.IotEndpointType = cmdletContext.IotEndpointType;
            }
            if (cmdletContext.S3EndpointType != null)
            {
                request.S3EndpointType = cmdletContext.S3EndpointType;
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
        
        private Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.GetComponentVersionArtifactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "GetComponentVersionArtifact");
            try
            {
                #if DESKTOP
                return client.GetComponentVersionArtifact(request);
                #elif CORECLR
                return client.GetComponentVersionArtifactAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String ArtifactName { get; set; }
            public Amazon.GreengrassV2.IotEndpointType IotEndpointType { get; set; }
            public Amazon.GreengrassV2.S3EndpointType S3EndpointType { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.GetComponentVersionArtifactResponse, GetGGV2ComponentVersionArtifactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PreSignedUrl;
        }
        
    }
}
