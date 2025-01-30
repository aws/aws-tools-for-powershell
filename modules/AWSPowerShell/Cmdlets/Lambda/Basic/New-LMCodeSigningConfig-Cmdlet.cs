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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Creates a code signing configuration. A <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-codesigning.html">code
    /// signing configuration</a> defines a list of allowed signing profiles and defines the
    /// code-signing validation policy (action to be taken if deployment validation checks
    /// fail).
    /// </summary>
    [Cmdlet("New", "LMCodeSigningConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CreateCodeSigningConfigResponse")]
    [AWSCmdlet("Calls the AWS Lambda CreateCodeSigningConfig API operation.", Operation = new[] {"CreateCodeSigningConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.CreateCodeSigningConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateCodeSigningConfigResponse",
        "This cmdlet returns an Amazon.Lambda.Model.CreateCodeSigningConfigResponse object containing multiple properties."
    )]
    public partial class NewLMCodeSigningConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Descriptive name for this code signing configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AllowedPublishers_SigningProfileVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for each of the signing profiles. A signing profile
        /// defines a trusted user who can sign a code package. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AllowedPublishers_SigningProfileVersionArns")]
        public System.String[] AllowedPublishers_SigningProfileVersionArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to add to the code signing configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter CodeSigningPolicies_UntrustedArtifactOnDeployment
        /// <summary>
        /// <para>
        /// <para>Code signing configuration policy for deployment validation failure. If you set the
        /// policy to <c>Enforce</c>, Lambda blocks the deployment request if signature validation
        /// checks fail. If you set the policy to <c>Warn</c>, Lambda allows the deployment and
        /// creates a CloudWatch log. </para><para>Default value: <c>Warn</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.CodeSigningPolicy")]
        public Amazon.Lambda.CodeSigningPolicy CodeSigningPolicies_UntrustedArtifactOnDeployment { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.CreateCodeSigningConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.CreateCodeSigningConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Description), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMCodeSigningConfig (CreateCodeSigningConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.CreateCodeSigningConfigResponse, NewLMCodeSigningConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedPublishers_SigningProfileVersionArn != null)
            {
                context.AllowedPublishers_SigningProfileVersionArn = new List<System.String>(this.AllowedPublishers_SigningProfileVersionArn);
            }
            #if MODULAR
            if (this.AllowedPublishers_SigningProfileVersionArn == null && ParameterWasBound(nameof(this.AllowedPublishers_SigningProfileVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AllowedPublishers_SigningProfileVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CodeSigningPolicies_UntrustedArtifactOnDeployment = this.CodeSigningPolicies_UntrustedArtifactOnDeployment;
            context.Description = this.Description;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Lambda.Model.CreateCodeSigningConfigRequest();
            
            
             // populate AllowedPublishers
            var requestAllowedPublishersIsNull = true;
            request.AllowedPublishers = new Amazon.Lambda.Model.AllowedPublishers();
            List<System.String> requestAllowedPublishers_allowedPublishers_SigningProfileVersionArn = null;
            if (cmdletContext.AllowedPublishers_SigningProfileVersionArn != null)
            {
                requestAllowedPublishers_allowedPublishers_SigningProfileVersionArn = cmdletContext.AllowedPublishers_SigningProfileVersionArn;
            }
            if (requestAllowedPublishers_allowedPublishers_SigningProfileVersionArn != null)
            {
                request.AllowedPublishers.SigningProfileVersionArns = requestAllowedPublishers_allowedPublishers_SigningProfileVersionArn;
                requestAllowedPublishersIsNull = false;
            }
             // determine if request.AllowedPublishers should be set to null
            if (requestAllowedPublishersIsNull)
            {
                request.AllowedPublishers = null;
            }
            
             // populate CodeSigningPolicies
            var requestCodeSigningPoliciesIsNull = true;
            request.CodeSigningPolicies = new Amazon.Lambda.Model.CodeSigningPolicies();
            Amazon.Lambda.CodeSigningPolicy requestCodeSigningPolicies_codeSigningPolicies_UntrustedArtifactOnDeployment = null;
            if (cmdletContext.CodeSigningPolicies_UntrustedArtifactOnDeployment != null)
            {
                requestCodeSigningPolicies_codeSigningPolicies_UntrustedArtifactOnDeployment = cmdletContext.CodeSigningPolicies_UntrustedArtifactOnDeployment;
            }
            if (requestCodeSigningPolicies_codeSigningPolicies_UntrustedArtifactOnDeployment != null)
            {
                request.CodeSigningPolicies.UntrustedArtifactOnDeployment = requestCodeSigningPolicies_codeSigningPolicies_UntrustedArtifactOnDeployment;
                requestCodeSigningPoliciesIsNull = false;
            }
             // determine if request.CodeSigningPolicies should be set to null
            if (requestCodeSigningPoliciesIsNull)
            {
                request.CodeSigningPolicies = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Lambda.Model.CreateCodeSigningConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateCodeSigningConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "CreateCodeSigningConfig");
            try
            {
                #if DESKTOP
                return client.CreateCodeSigningConfig(request);
                #elif CORECLR
                return client.CreateCodeSigningConfigAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedPublishers_SigningProfileVersionArn { get; set; }
            public Amazon.Lambda.CodeSigningPolicy CodeSigningPolicies_UntrustedArtifactOnDeployment { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Lambda.Model.CreateCodeSigningConfigResponse, NewLMCodeSigningConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
