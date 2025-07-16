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
using Amazon.MediaPackageV2;
using Amazon.MediaPackageV2.Model;

namespace Amazon.PowerShell.Cmdlets.MPV2
{
    /// <summary>
    /// Attaches an IAM policy to the specified origin endpoint. You can attach only one policy
    /// with each request.
    /// </summary>
    [Cmdlet("Write", "MPV2OriginEndpointPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage v2 PutOriginEndpointPolicy API operation.", Operation = new[] {"PutOriginEndpointPolicy"}, SelectReturnType = typeof(Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteMPV2OriginEndpointPolicyCmdlet : AmazonMediaPackageV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CdnAuthConfiguration_CdnIdentifierSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the secret in Secrets Manager that your CDN uses for authorization to
        /// access the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CdnAuthConfiguration_CdnIdentifierSecretArns")]
        public System.String[] CdnAuthConfiguration_CdnIdentifierSecretArn { get; set; }
        #endregion
        
        #region Parameter ChannelGroupName
        /// <summary>
        /// <para>
        /// <para>The name that describes the channel group. The name is the primary identifier for
        /// the channel group, and must be unique for your account in the AWS Region.</para>
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
        public System.String ChannelGroupName { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name that describes the channel. The name is the primary identifier for the channel,
        /// and must be unique for your account in the AWS Region and channel group. </para>
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
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter OriginEndpointName
        /// <summary>
        /// <para>
        /// <para>The name that describes the origin endpoint. The name is the primary identifier for
        /// the origin endpoint, and and must be unique for your account in the AWS Region and
        /// channel. </para>
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
        public System.String OriginEndpointName { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The policy to attach to the specified origin endpoint.</para>
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
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter CdnAuthConfiguration_SecretsRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that gives MediaPackage read access to Secrets Manager and
        /// KMS for CDN authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CdnAuthConfiguration_SecretsRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OriginEndpointName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OriginEndpointName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OriginEndpointName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-MPV2OriginEndpointPolicy (PutOriginEndpointPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyResponse, WriteMPV2OriginEndpointPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OriginEndpointName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CdnAuthConfiguration_CdnIdentifierSecretArn != null)
            {
                context.CdnAuthConfiguration_CdnIdentifierSecretArn = new List<System.String>(this.CdnAuthConfiguration_CdnIdentifierSecretArn);
            }
            context.CdnAuthConfiguration_SecretsRoleArn = this.CdnAuthConfiguration_SecretsRoleArn;
            context.ChannelGroupName = this.ChannelGroupName;
            #if MODULAR
            if (this.ChannelGroupName == null && ParameterWasBound(nameof(this.ChannelGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginEndpointName = this.OriginEndpointName;
            #if MODULAR
            if (this.OriginEndpointName == null && ParameterWasBound(nameof(this.OriginEndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginEndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyRequest();
            
            
             // populate CdnAuthConfiguration
            var requestCdnAuthConfigurationIsNull = true;
            request.CdnAuthConfiguration = new Amazon.MediaPackageV2.Model.CdnAuthConfiguration();
            List<System.String> requestCdnAuthConfiguration_cdnAuthConfiguration_CdnIdentifierSecretArn = null;
            if (cmdletContext.CdnAuthConfiguration_CdnIdentifierSecretArn != null)
            {
                requestCdnAuthConfiguration_cdnAuthConfiguration_CdnIdentifierSecretArn = cmdletContext.CdnAuthConfiguration_CdnIdentifierSecretArn;
            }
            if (requestCdnAuthConfiguration_cdnAuthConfiguration_CdnIdentifierSecretArn != null)
            {
                request.CdnAuthConfiguration.CdnIdentifierSecretArns = requestCdnAuthConfiguration_cdnAuthConfiguration_CdnIdentifierSecretArn;
                requestCdnAuthConfigurationIsNull = false;
            }
            System.String requestCdnAuthConfiguration_cdnAuthConfiguration_SecretsRoleArn = null;
            if (cmdletContext.CdnAuthConfiguration_SecretsRoleArn != null)
            {
                requestCdnAuthConfiguration_cdnAuthConfiguration_SecretsRoleArn = cmdletContext.CdnAuthConfiguration_SecretsRoleArn;
            }
            if (requestCdnAuthConfiguration_cdnAuthConfiguration_SecretsRoleArn != null)
            {
                request.CdnAuthConfiguration.SecretsRoleArn = requestCdnAuthConfiguration_cdnAuthConfiguration_SecretsRoleArn;
                requestCdnAuthConfigurationIsNull = false;
            }
             // determine if request.CdnAuthConfiguration should be set to null
            if (requestCdnAuthConfigurationIsNull)
            {
                request.CdnAuthConfiguration = null;
            }
            if (cmdletContext.ChannelGroupName != null)
            {
                request.ChannelGroupName = cmdletContext.ChannelGroupName;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.OriginEndpointName != null)
            {
                request.OriginEndpointName = cmdletContext.OriginEndpointName;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
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
        
        private Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyResponse CallAWSServiceOperation(IAmazonMediaPackageV2 client, Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage v2", "PutOriginEndpointPolicy");
            try
            {
                #if DESKTOP
                return client.PutOriginEndpointPolicy(request);
                #elif CORECLR
                return client.PutOriginEndpointPolicyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CdnAuthConfiguration_CdnIdentifierSecretArn { get; set; }
            public System.String CdnAuthConfiguration_SecretsRoleArn { get; set; }
            public System.String ChannelGroupName { get; set; }
            public System.String ChannelName { get; set; }
            public System.String OriginEndpointName { get; set; }
            public System.String Policy { get; set; }
            public System.Func<Amazon.MediaPackageV2.Model.PutOriginEndpointPolicyResponse, WriteMPV2OriginEndpointPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
