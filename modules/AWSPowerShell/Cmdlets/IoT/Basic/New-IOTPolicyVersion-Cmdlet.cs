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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a new version of the specified IoT policy. To update a policy, create a new
    /// policy version. A managed policy can have up to five versions. If the policy has five
    /// versions, you must use <a>DeletePolicyVersion</a> to delete an existing version before
    /// you create a new one.
    /// 
    ///  
    /// <para>
    /// Optionally, you can set the new version as the policy's default version. The default
    /// version is the operative version (that is, the version that is in effect for the certificates
    /// to which the policy is attached).
    /// </para><para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreatePolicyVersion</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTPolicyVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreatePolicyVersionResponse")]
    [AWSCmdlet("Calls the AWS IoT CreatePolicyVersion API operation.", Operation = new[] {"CreatePolicyVersion"}, SelectReturnType = typeof(Amazon.IoT.Model.CreatePolicyVersionResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreatePolicyVersionResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreatePolicyVersionResponse object containing multiple properties."
    )]
    public partial class NewIOTPolicyVersionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>The JSON document that describes the policy. Minimum length of 1. Maximum length of
        /// 2048, excluding whitespace.</para>
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
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The policy name.</para>
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
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter SetAsDefault
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy version is set as the default. When this parameter is
        /// true, the new policy version becomes the operative version (that is, the version that
        /// is in effect for the certificates to which the policy is attached).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SetAsDefault { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreatePolicyVersionResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreatePolicyVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTPolicyVersion (CreatePolicyVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreatePolicyVersionResponse, NewIOTPolicyVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PolicyDocument = this.PolicyDocument;
            #if MODULAR
            if (this.PolicyDocument == null && ParameterWasBound(nameof(this.PolicyDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyName = this.PolicyName;
            #if MODULAR
            if (this.PolicyName == null && ParameterWasBound(nameof(this.PolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SetAsDefault = this.SetAsDefault;
            
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
            var request = new Amazon.IoT.Model.CreatePolicyVersionRequest();
            
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.SetAsDefault != null)
            {
                request.SetAsDefault = cmdletContext.SetAsDefault.Value;
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
        
        private Amazon.IoT.Model.CreatePolicyVersionResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreatePolicyVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreatePolicyVersion");
            try
            {
                #if DESKTOP
                return client.CreatePolicyVersion(request);
                #elif CORECLR
                return client.CreatePolicyVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String PolicyDocument { get; set; }
            public System.String PolicyName { get; set; }
            public System.Boolean? SetAsDefault { get; set; }
            public System.Func<Amazon.IoT.Model.CreatePolicyVersionResponse, NewIOTPolicyVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
