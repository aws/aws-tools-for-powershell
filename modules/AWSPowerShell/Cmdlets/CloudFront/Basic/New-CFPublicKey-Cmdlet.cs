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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Add a new public key to CloudFront to use, for example, for field-level encryption.
    /// You can add a maximum of 10 public keys with one AWS account.
    /// </summary>
    [Cmdlet("New", "CFPublicKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreatePublicKeyResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreatePublicKey API operation.", Operation = new[] {"CreatePublicKey"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreatePublicKeyResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreatePublicKeyResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreatePublicKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFPublicKeyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter PublicKeyConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique number that ensures that the request can't be replayed.</para>
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
        public System.String PublicKeyConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter PublicKeyConfig_Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment about a public key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PublicKeyConfig_Comment { get; set; }
        #endregion
        
        #region Parameter PublicKeyConfig_EncodedKey
        /// <summary>
        /// <para>
        /// <para>The encoded public key that you want to add to CloudFront to use with features like
        /// field-level encryption.</para>
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
        public System.String PublicKeyConfig_EncodedKey { get; set; }
        #endregion
        
        #region Parameter PublicKeyConfig_Name
        /// <summary>
        /// <para>
        /// <para>The name for a public key you add to CloudFront to use with features like field-level
        /// encryption.</para>
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
        public System.String PublicKeyConfig_Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreatePublicKeyResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreatePublicKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PublicKeyConfig_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PublicKeyConfig_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PublicKeyConfig_Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PublicKeyConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFPublicKey (CreatePublicKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreatePublicKeyResponse, NewCFPublicKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PublicKeyConfig_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PublicKeyConfig_CallerReference = this.PublicKeyConfig_CallerReference;
            #if MODULAR
            if (this.PublicKeyConfig_CallerReference == null && ParameterWasBound(nameof(this.PublicKeyConfig_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter PublicKeyConfig_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicKeyConfig_Comment = this.PublicKeyConfig_Comment;
            context.PublicKeyConfig_EncodedKey = this.PublicKeyConfig_EncodedKey;
            #if MODULAR
            if (this.PublicKeyConfig_EncodedKey == null && ParameterWasBound(nameof(this.PublicKeyConfig_EncodedKey)))
            {
                WriteWarning("You are passing $null as a value for parameter PublicKeyConfig_EncodedKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicKeyConfig_Name = this.PublicKeyConfig_Name;
            #if MODULAR
            if (this.PublicKeyConfig_Name == null && ParameterWasBound(nameof(this.PublicKeyConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter PublicKeyConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudFront.Model.CreatePublicKeyRequest();
            
            
             // populate PublicKeyConfig
            var requestPublicKeyConfigIsNull = true;
            request.PublicKeyConfig = new Amazon.CloudFront.Model.PublicKeyConfig();
            System.String requestPublicKeyConfig_publicKeyConfig_CallerReference = null;
            if (cmdletContext.PublicKeyConfig_CallerReference != null)
            {
                requestPublicKeyConfig_publicKeyConfig_CallerReference = cmdletContext.PublicKeyConfig_CallerReference;
            }
            if (requestPublicKeyConfig_publicKeyConfig_CallerReference != null)
            {
                request.PublicKeyConfig.CallerReference = requestPublicKeyConfig_publicKeyConfig_CallerReference;
                requestPublicKeyConfigIsNull = false;
            }
            System.String requestPublicKeyConfig_publicKeyConfig_Comment = null;
            if (cmdletContext.PublicKeyConfig_Comment != null)
            {
                requestPublicKeyConfig_publicKeyConfig_Comment = cmdletContext.PublicKeyConfig_Comment;
            }
            if (requestPublicKeyConfig_publicKeyConfig_Comment != null)
            {
                request.PublicKeyConfig.Comment = requestPublicKeyConfig_publicKeyConfig_Comment;
                requestPublicKeyConfigIsNull = false;
            }
            System.String requestPublicKeyConfig_publicKeyConfig_EncodedKey = null;
            if (cmdletContext.PublicKeyConfig_EncodedKey != null)
            {
                requestPublicKeyConfig_publicKeyConfig_EncodedKey = cmdletContext.PublicKeyConfig_EncodedKey;
            }
            if (requestPublicKeyConfig_publicKeyConfig_EncodedKey != null)
            {
                request.PublicKeyConfig.EncodedKey = requestPublicKeyConfig_publicKeyConfig_EncodedKey;
                requestPublicKeyConfigIsNull = false;
            }
            System.String requestPublicKeyConfig_publicKeyConfig_Name = null;
            if (cmdletContext.PublicKeyConfig_Name != null)
            {
                requestPublicKeyConfig_publicKeyConfig_Name = cmdletContext.PublicKeyConfig_Name;
            }
            if (requestPublicKeyConfig_publicKeyConfig_Name != null)
            {
                request.PublicKeyConfig.Name = requestPublicKeyConfig_publicKeyConfig_Name;
                requestPublicKeyConfigIsNull = false;
            }
             // determine if request.PublicKeyConfig should be set to null
            if (requestPublicKeyConfigIsNull)
            {
                request.PublicKeyConfig = null;
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
        
        private Amazon.CloudFront.Model.CreatePublicKeyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreatePublicKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreatePublicKey");
            try
            {
                #if DESKTOP
                return client.CreatePublicKey(request);
                #elif CORECLR
                return client.CreatePublicKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String PublicKeyConfig_CallerReference { get; set; }
            public System.String PublicKeyConfig_Comment { get; set; }
            public System.String PublicKeyConfig_EncodedKey { get; set; }
            public System.String PublicKeyConfig_Name { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreatePublicKeyResponse, NewCFPublicKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
