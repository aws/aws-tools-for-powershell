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
    /// Update the code signing configuration. Changes to the code signing configuration take
    /// effect the next time a user tries to deploy a code package to the function.
    /// </summary>
    [Cmdlet("Update", "LMCodeSigningConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateCodeSigningConfigResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateCodeSigningConfig API operation.", Operation = new[] {"UpdateCodeSigningConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateCodeSigningConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateCodeSigningConfigResponse",
        "This cmdlet returns an Amazon.Lambda.Model.UpdateCodeSigningConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMCodeSigningConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter CodeSigningConfigArn
        /// <summary>
        /// <para>
        /// <para>The The Amazon Resource Name (ARN) of the code signing configuration.</para>
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
        public System.String CodeSigningConfigArn { get; set; }
        #endregion
        
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedPublishers_SigningProfileVersionArns")]
        public System.String[] AllowedPublishers_SigningProfileVersionArn { get; set; }
        #endregion
        
        #region Parameter CodeSigningPolicies_UntrustedArtifactOnDeployment
        /// <summary>
        /// <para>
        /// <para>Code signing configuration policy for deployment validation failure. If you set the
        /// policy to <code>Enforce</code>, Lambda blocks the deployment request if signature
        /// validation checks fail. If you set the policy to <code>Warn</code>, Lambda allows
        /// the deployment and creates a CloudWatch log. </para><para>Default value: <code>Warn</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.CodeSigningPolicy")]
        public Amazon.Lambda.CodeSigningPolicy CodeSigningPolicies_UntrustedArtifactOnDeployment { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateCodeSigningConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateCodeSigningConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CodeSigningConfigArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CodeSigningConfigArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CodeSigningConfigArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CodeSigningConfigArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMCodeSigningConfig (UpdateCodeSigningConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateCodeSigningConfigResponse, UpdateLMCodeSigningConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CodeSigningConfigArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AllowedPublishers_SigningProfileVersionArn != null)
            {
                context.AllowedPublishers_SigningProfileVersionArn = new List<System.String>(this.AllowedPublishers_SigningProfileVersionArn);
            }
            context.CodeSigningConfigArn = this.CodeSigningConfigArn;
            #if MODULAR
            if (this.CodeSigningConfigArn == null && ParameterWasBound(nameof(this.CodeSigningConfigArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CodeSigningConfigArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CodeSigningPolicies_UntrustedArtifactOnDeployment = this.CodeSigningPolicies_UntrustedArtifactOnDeployment;
            context.Description = this.Description;
            
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
            var request = new Amazon.Lambda.Model.UpdateCodeSigningConfigRequest();
            
            
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
            if (cmdletContext.CodeSigningConfigArn != null)
            {
                request.CodeSigningConfigArn = cmdletContext.CodeSigningConfigArn;
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
        
        private Amazon.Lambda.Model.UpdateCodeSigningConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateCodeSigningConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateCodeSigningConfig");
            try
            {
                #if DESKTOP
                return client.UpdateCodeSigningConfig(request);
                #elif CORECLR
                return client.UpdateCodeSigningConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String CodeSigningConfigArn { get; set; }
            public Amazon.Lambda.CodeSigningPolicy CodeSigningPolicies_UntrustedArtifactOnDeployment { get; set; }
            public System.String Description { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateCodeSigningConfigResponse, UpdateLMCodeSigningConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
